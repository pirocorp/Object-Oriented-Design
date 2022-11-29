namespace State.Policies
{
    using System.Collections.Generic;

    public interface IPolicyStateCommands : IPolicyState
    {
        List<string> ListValidOperations();
    }
}
