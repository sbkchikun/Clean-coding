using DTOs;
using System.Net.Sockets;

namespace CommandLineUI.Commands
{
    interface Command
    {
        RequestDTO Execute();
    }
}
