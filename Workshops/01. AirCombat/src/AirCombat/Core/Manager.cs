namespace AirCombat.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AirCombat.Core.Contracts;
using AirCombat.Entities.AirCrafts.Contracts;
using AirCombat.Entities.AirCrafts.Factories;
using AirCombat.Entities.AirCrafts.Factories.Contracts;
using AirCombat.Entities.Parts.Contracts;
using AirCombat.Entities.Parts.Factories;
using AirCombat.Entities.Parts.Factories.Contracts;
using AirCombat.Utils;

public class Manager : IManager
{
    private readonly IDictionary<string, IAirCraft> aircrafts;
    private readonly IDictionary<string, IPart> parts;
    private readonly IList<string> defeatedAircrafts;
    private readonly IBattleOperator battleOperator;

    private readonly IAirCraftFactory aircraftFactory;
    private readonly IPartFactory partFactory;

    public Manager(IBattleOperator battleOperator)
    {
        this.battleOperator = battleOperator;

        this.aircrafts = new Dictionary<string, IAirCraft>();
        this.parts = new Dictionary<string, IPart>();
        this.defeatedAircrafts = new List<string>();

        this.aircraftFactory = new AirCraftFactory();
        this.partFactory = new PartFactory();
    }

    public string AddAircraft(IList<string> arguments)
    {
        var aircraftType = arguments[0];
        var model = arguments[1];
        var weight = double.Parse(arguments[2]);
        var price = decimal.Parse(arguments[3]);
        var attack = int.Parse(arguments[4]);
        var defense = int.Parse(arguments[5]);
        var hitPoints = int.Parse(arguments[6]);

        var aircraft = this.aircraftFactory.CreateAirCraft(
            aircraftType,
            model,
            weight, 
            price,
            attack,
            defense,
            hitPoints);

        this.aircrafts.Add(aircraft.Model, aircraft);

        return string.Format(
            GlobalConstants.AircraftSuccessMessage,
            aircraftType,
            aircraft.Model);
    }

    public string AddPart(IList<string> arguments)
    {
        var aircraftModel = arguments[0];
        var partType = arguments[1];
        var model = arguments[2];
        var weight = double.Parse(arguments[3]);
        var price = decimal.Parse(arguments[4]);
        var additionalParameter = int.Parse(arguments[5]);

        var part = this.partFactory.CreatePart(
            partType, 
            model, 
            weight, 
            price, 
            additionalParameter);

        switch (partType)
        {
            case "Arsenal":
                this.aircrafts[aircraftModel].AddArsenalPart(part);
                break;
            case "Shell":
                this.aircrafts[aircraftModel].AddShellPart(part);
                break;
            case "Endurance":
                this.aircrafts[aircraftModel].AddEndurancePart(part);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        this.parts[partType] = part;

        return string.Format(
            GlobalConstants.PartSuccessMessage,
            partType,
            part.Model,
            aircraftModel);
    }

    public string Inspect(IList<string> arguments)
    {
        var model = arguments[0];

        var result = this.aircrafts.ContainsKey(model) ?
            this.aircrafts[model].ToString() :
            this.parts[model].ToString();

        return result;
    }

    public string Battle(IList<string> arguments)
    {
        var attackerAircraftModel = arguments[0];
        var targetAircraftModel = arguments[1];

        var winnerAircraftModel = this.battleOperator.Battle(this.aircrafts[attackerAircraftModel], this.aircrafts[targetAircraftModel]);

        if (winnerAircraftModel.Equals(attackerAircraftModel))
        {
            this.aircrafts[targetAircraftModel]
                .Parts
                .ToList()
                .ForEach(x => this.parts.Remove(x.Model));

            this.aircrafts.Remove(targetAircraftModel);
            this.defeatedAircrafts.Add(targetAircraftModel);
        }
        else
        {
            this.aircrafts[attackerAircraftModel]
                .Parts
                .ToList()
                .ForEach(x => this.parts.Remove(x.Model));

            this.aircrafts.Remove(attackerAircraftModel);

            this.defeatedAircrafts.Add(attackerAircraftModel);
        }

        return string.Format(
            GlobalConstants.BattleSuccessMessage,
            attackerAircraftModel,
            targetAircraftModel,
            winnerAircraftModel);
    }

    public string Terminate(IList<string> arguments)
    {
        var finalResult = new StringBuilder();

        finalResult.Append("Remaining Aircrafts: ");

        if (this.aircrafts.Count > 0)
        {
            finalResult
                .AppendLine(string.Join(", ",
                    this.aircrafts
                        .Values
                        .Select(v => v.Model)
                        .ToArray()));
        }
        else
        {
            finalResult.AppendLine("None");
        }

        finalResult.Append("Defeated Aircrafts: ");

        var defeatedResult = this.defeatedAircrafts.Count > 0
            ? string.Join(", ", this.defeatedAircrafts)
            : "None";

        finalResult.AppendLine(defeatedResult);

        finalResult
            .Append("Currently Used Parts: ")
            .Append(this.parts.Count);

        return finalResult.ToString();
    }
}