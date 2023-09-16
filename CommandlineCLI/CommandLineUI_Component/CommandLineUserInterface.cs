using CommandLineUI.Commands;
using CommandLineUI.Menu;
using Presenters;
using DTOs;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
namespace CommandLineUI
{
    // This class is in the frameworks and drivers circle of the Clean Architecture model
    public class CommandLineUserInterface
    {   CommandFactory factory = new CommandFactory();
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private bool clientRunning = true;
        private ConcurrentQueue<CommandLineViewData> messages;
        private BlockingCollection<RequestDTO> commands;
        public CommandLineUserInterface()
        {
            tcpClient = new TcpClient();
            messages = new ConcurrentQueue<CommandLineViewData>();
            commands = new BlockingCollection<RequestDTO>();
        }
        
        public void Start()
        {

            if (Connect("localhost", 4444))
            {
                Task.Run(ReadFromServer);
                Task.Run(DisplayMessages);
                int rapidrequests = ConsoleReader.ReadInt("\nRun rapid requests? type 0 if no");
                if (rapidrequests > 0) { Task.Run(RapidRequests); }
                MenuFactory.INSTANCE.Create().Print("");
                RequestDTO command = factory
                                .CreateCommand(GetMenuChoice())
                                .Execute();
                while (clientRunning)
                {

                    try
                    {


                        int choice = command.Command;
                        if (choice != RequestUseCase.EXIT)
                        {   
                           
                            WriteToServer(command);
                            MenuFactory.INSTANCE.Create().Print("");
                            command = factory
                                            .CreateCommand(GetMenuChoice())
                                            .Execute();
                            
                        }
                        else
                        {
                            clientRunning = false;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\nERROR: " + e.Message);
                    } 
                }
            }
            else
            {
                Console.WriteLine("ERROR: Connection to server not successful");
            }
            tcpClient.Close();
 
                
            }


        private void WriteToServer(RequestDTO request)
        {
            lock (writer)
            {
                string JSON = JsonSerializer.Serialize(request);
                writer.WriteLine(JSON);
                writer.Flush();
            }
        }
        private bool Connect(string url, int portNumber)
        {
            try
            {
                tcpClient.Connect(url, portNumber);
                stream = tcpClient.GetStream();
                reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                writer = new StreamWriter(stream, System.Text.Encoding.UTF8);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return false;
            }
            return true;
        }
        private int GetMenuChoice()
        {
            
            int option = ConsoleReader.ReadInt("\nOption");
            while (option < 1 || option > 7)
            {
                Console.WriteLine("\nChoice not recognised. Please try again");
                option = ConsoleReader.ReadInt("\nOption");
            }
            return option;
        }
        private void ReadFromServer()
        {
            while (clientRunning)
            {
                string serverResponse = reader.ReadLine();
                    messages.Enqueue(
                        JsonSerializer.Deserialize<CommandLineViewData>(serverResponse)); 
            }
        }

        private void DisplayMessages()
        {
            while (clientRunning)
            {
                CommandLineViewData msg;
                
                if (messages.TryDequeue(out msg))
                {
                    ConsoleWriter.WriteStrings(msg.ViewData);
                    
                }
            }
        }
        public void RapidRequests()
        {
            for (int i = 1; i < 975; i++)
            {
                RequestDTO request1 = factory
                   .CreateCommand(4)
                   .Execute();
                RequestDTO request2 = factory
                   .CreateCommand(5)
                   .Execute();
                RequestDTO request3 = factory
                   .CreateCommand(6)
                   .Execute();
                WriteToServer(request1);
                WriteToServer(request2);
                WriteToServer(request3);
                Task.Yield();
            }
        }
    }
}
