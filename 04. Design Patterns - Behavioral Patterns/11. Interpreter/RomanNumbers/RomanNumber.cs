namespace Interpreter.RomanNumbers;

using System.Collections.Generic;

public class RomanNumber
{
    private readonly Context context;
    private readonly List<Expression> tree;

    private int value;

    public RomanNumber(string romanNumber)
    {
        this.Literal = romanNumber;
        this.context = new Context(romanNumber);
        this.tree = new List<Expression> ();

        this.Init();
    }

    public string Literal { get; }

    public int Value 
        => this.context.Input == string.Empty 
            ? this.value 
            : this.CalculateValue();

    /// <summary>
    /// Interpret expression
    /// </summary>
    /// <returns>Interpreted value</returns>
    private int CalculateValue()
    {
        foreach (var exp in tree)
        {
            exp.Interpret(context);
        }

        this.value = this.context.Output;
        return this.value;
    }

    /// <summary>
    /// Build the 'parse tree'
    /// </summary>
    private void Init()
    {
        tree.Add(new ThousandExpression());
        tree.Add(new HundredExpression());
        tree.Add(new TenExpression());
        tree.Add(new OneExpression());
    }
}
