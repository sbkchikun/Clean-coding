using DTOs;

namespace Windows.Commands
{
    interface Command
    {
        RequestDTO Execute();
    }
}
