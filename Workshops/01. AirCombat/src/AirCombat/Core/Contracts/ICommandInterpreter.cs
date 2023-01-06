using System.Collections.Generic;

namespace AirCombat.Core.Contracts;

public interface ICommandInterpreter
{
    string ProcessInput(IList<string> inputParameters);
}