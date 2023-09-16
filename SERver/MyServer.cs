using Controllers;
using Presenters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using DTOs;
using CommandLineUI.Commands;
using CommandLineUI;
using System.Collections.Concurrent;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Text.Json;

namespace ServerSide
{
    delegate void RemoveClient(ClientService c);
    

    class MyServer
    {
        
        private TcpListener tcpListener;
        private List<ClientService> clientServices;
        private ConcurrentQueue<(RequestDTO, ClientService)> requestsQueue;
        CommandFactory factory = new CommandFactory();
        CommandFactoryWPF WPFfactory = new CommandFactoryWPF();
        public MyServer()
        {
            
            IPAddress ipAddress = IPAddress.Loopback;
            tcpListener = new TcpListener(ipAddress, 4444);
            requestsQueue = new ConcurrentQueue<(RequestDTO, ClientService)>();
            clientServices = new List<ClientService>();
            Console.WriteLine("Listening....");
        }
        RequestDTO start =  new RequestDTO_Builder().WithCommand(0).Build();
        public void Start()
        {
            tcpListener.Start();
            //Initialise database
            new CommandFactory().CreateCommand(start).Execute();
            Task.Run(ProcessRequests);
            Console.WriteLine("Ready");
            while (true)
            {
                Socket s = tcpListener.AcceptSocket();  //blocks until a connection is made
                ClientService clientService = new ClientService(s, RemoveClient, requestsQueue);
                clientServices.Add(clientService);
                Task.Run(clientService.InteractWithClient);
                /*Task.Run(clientService.ProcessRequests);*/


            }
            
        }
        
        public async Task ProcessRequests()
        {
            int i = 1;
            while (true)
            {

                if (requestsQueue.TryDequeue(out (RequestDTO request, ClientService clientService) request))
                {
                    Console.WriteLine(i);
                    string response = await Task.Run(()=>ProcessClientMessage(request.request));
                    request.clientService.ProcessServerResponse(response);
                    i++;
                    
                }
            }
        }

        private int CommandlineResponses=0;
        public async Task<string> ProcessClientMessage(RequestDTO request)
        {
            string response = "";
            if (request.Client != null)
            {
                response = await WPFfactory.CreateCommand(request).Execute();

            }
            else if (request.Client == null)
            {
                CommandLineViewData unpreppedresponse =  await factory.CreateCommand(request).Execute();
                response = JsonSerializer.Serialize(unpreppedresponse);
                
            }
            
            return response;
        }
        public void Stop()
        {
            tcpListener.Stop();
        }

        private void RemoveClient(ClientService c)
        {
            //Console.WriteLine("REMOVING CLIENT");
            clientServices.Remove(c);
        }

       
    }
}
