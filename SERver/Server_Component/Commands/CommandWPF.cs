using Presenters;

namespace CommandLineUI.Commands
{
    interface CommandWPF
    {
        Task<string> Execute();
    }
}
