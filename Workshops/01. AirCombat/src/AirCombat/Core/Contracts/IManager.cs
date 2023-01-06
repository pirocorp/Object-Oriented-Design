using System.Collections.Generic;

namespace AirCombat.Core.Contracts;

public interface IManager
{
    string AddAircraft(IList<string> arguments);

    string AddPart(IList<string> arguments);

    string Inspect(IList<string> arguments);

    string Battle(IList<string> arguments);

    string Terminate(IList<string> arguments);
}