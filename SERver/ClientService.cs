using Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using UseCase;
using DTOs;

using Presenters;
using CommandLineUI.Commands;
using Org.BouncyCastle.Security;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Ocsp;

namespace ServerSide
{
    class ClientService
    {
        CommandFactory factory = new CommandFactory();
        CommandFactoryWPF WPFfactory = new CommandFactoryWPF();

        private Socket socket;
        private NetworkStream stream;
        
        public StreamReader reader { get; private set; }
        public StreamWriter writer { get; private set; }
        private ConcurrentQueue<(RequestDTO, ClientService)> RequestsQueue;
        private RemoveClient removeMe;
 
        public ClientService(Socket socket, RemoveClient rc, ConcurrentQueue<(RequestDTO, ClientService)> RequestsQueue)
        {
            this.socket = socket;
            removeMe = rc;
            this.RequestsQueue = RequestsQueue;
            stream = new NetworkStream(socket);
            reader = new StreamReader(stream, System.Text.Encoding.UTF8);
            writer = new StreamWriter(stream, System.Text.Encoding.UTF8);
        }
        
        public void InteractWithClient()
        {
            
            try
            {
                Console.WriteLine("recieving");
               
                while (true)
                {
                    
                    RequestDTO clientMessage = JsonSerializer.Deserialize<RequestDTO>(reader.ReadLine());
                    RequestsQueue.Enqueue((clientMessage, this));

                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            } 

            Console.WriteLine("Goodbye from " + socket.RemoteEndPoint.ToString());
            Close();
        }
        
        public void ProcessServerResponse(string response)
        {

            lock (writer)
            {

                writer.WriteLine(response);
                writer.Flush();

            }
        }
        
        public void ClientReader()
        {
            while (true)
            {
                RequestDTO clientMessage = JsonSerializer.Deserialize<RequestDTO>(reader.ReadLine());
                RequestsQueue.Enqueue((clientMessage, this));
            }
        }

        public void Close()
        {
            try
            {
                removeMe(this);
                socket.Shutdown(SocketShutdown.Both);
            }
            finally
            {
                socket.Close();
            }
        }
    }
}

