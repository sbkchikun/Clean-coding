using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using Windows;
using System.Windows;
using Windows.Presenters;
using System.Windows.Controls;
using DTOs;
using System.Windows.Interop;
using Assignment_2.Window_Component.Views.ViewMenuViews;
using System.Windows.Markup;
using Windows.Commands;
using System.Diagnostics;


namespace WPF_Client
{
    class MyWPFClient
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private bool clientRunning;
        private TextBox ConsoleBox;
        private ConcurrentQueue<CommandLineViewData> messages;
        private BlockingCollection<RequestDTO> commands;
        private CommandFactory factory;

        public MyWPFClient(TextBox consolebox)
        {
            factory = new CommandFactory();
            tcpClient = new TcpClient();
            messages = new ConcurrentQueue<CommandLineViewData>();
            commands = new BlockingCollection<RequestDTO>();
            ConsoleBox = consolebox;
            
            
        }

        public void Run()
        {
            clientRunning = true;
            
            if (Connect("localhost", 4444))
            {
                

                Task.Factory.StartNew(ReadFromServer);
                Task.Run(DisplayMessages);

                while (clientRunning)
                {
                    RequestDTO userInput = commands.Take();

                     
                    
                    WriteToServer(userInput);
                }
            }
            else
            {
                List<string> exception = new List<string>();
                exception.Add("ERROR: Connection to server not successful");
                ConsoleBoxWriter.WriteStrings(exception, ConsoleBox);
                 
            }
            tcpClient.Close();
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
                List<string> exceptions = new List<string>();
                exceptions.Add("Exception: " + e.Message);
                ConsoleBoxWriter.WriteStrings(exceptions,ConsoleBox);
                return false;
            }
            return true;
        }

        private void WriteToServer(RequestDTO request)
        {
            string JSON = JsonSerializer.Serialize(request);
            writer.WriteLine(JSON);
            writer.Flush();
        }
        
        private void ReadFromServer()
        {
            while (clientRunning)
            {
                string serverResponse = reader.ReadLine();
               
                char code = serverResponse.ToUpper()[0];
                
                if (code == 'B')
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        BookViewData msg = JsonSerializer.Deserialize<BookViewData>(serverResponse.Substring(1));
                        Debug.WriteLine($"msg: {msg.ViewData}");
                        ViewAllBooksWindow window = new ViewAllBooksWindow();
                        window.DataContext = msg;
                        window.Show();
                    });
                     
                }
                else if (code =='M')
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        MemberViewData msg = JsonSerializer.Deserialize<MemberViewData>(serverResponse.Substring(1));
                        ViewAllMembersWindow window = new ViewAllMembersWindow();
                        window.DataContext = msg;
                        window.Show();
                    });
                }
                else if (code == 'L')
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        serverResponse.Trim();
                        CurrentLoansViewData msg = JsonSerializer.Deserialize<CurrentLoansViewData>(serverResponse.Substring(1));
                        ViewCurrentLoansWindow window = new ViewCurrentLoansWindow();
                        window.DataContext = msg;
                        window.Show();
                    });
                }
                else {
                    
                    CommandLineViewData msg = JsonSerializer.Deserialize<CommandLineViewData>(serverResponse);
                    messages.Enqueue(msg); }
            }
        }

        private void DisplayMessages()
        {
            while (clientRunning)
            {
                CommandLineViewData msg;
                if (messages.TryDequeue(out msg))
                {
                     
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                         
                        ConsoleBoxWriter.WriteStrings(msg.ViewData, ConsoleBox);
                    });
                }
            }
        }
        public void AddCommand(RequestDTO command)
        {
            commands.Add(command);
        }

        public void RapidRequests()
        {
            
            
            for (int i = 1; i < 300; i++)
            {
                RequestDTO request1 = factory
                   .CreateCommand(RequestUseCase.RETURN_BOOK, 1, 1)
                   .Execute();
                RequestDTO request2 = factory
                   .CreateCommand(RequestUseCase.BORROW_BOOK, 1, 1)
                   .Execute();
                RequestDTO request3 = factory
                   .CreateCommand(RequestUseCase.BORROW_BOOK, 1, 2)
                   .Execute();
                WriteToServer(request2);
                WriteToServer(request1);
                WriteToServer(request3);
                Task.Yield();
            }
            
        }
    }
}
