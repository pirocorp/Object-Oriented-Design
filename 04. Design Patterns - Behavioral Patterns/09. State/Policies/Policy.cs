namespace State.Policies;

using System;

// NOTE: Policy is a partial class - see all the other files for more behavior
public partial class Policy : IPolicyState
{
    private readonly IPolicyStateCommands cancelledState;
    private readonly IPolicyStateCommands closedState;
    private readonly IPolicyStateCommands openState;
    private readonly IPolicyStateCommands unwrittenState;
    private readonly IPolicyStateCommands voidState;

    private Policy()
    { 
        this.cancelledState = new CancelledState(this);
        this.closedState = new ClosedState(this);
        this.openState = new OpenState(this);
        this.unwrittenState = new UnwrittenState(this);
        this.voidState = new VoidState(this);

        this.State = this.unwrittenState;
        this.Number = string.Empty;
    }

    public Policy(string policyNumber) 
        : this()
    {
        this.Number = policyNumber;
    }

    public int Id { get; set; }

    public string Number { get; set; }

    public DateTime? DateOpened { get; private set; }

    public DateTime? DateClosed { get; private set; }

    public IPolicyStateCommands State { get; private set; }

    public void Cancel() => this.State.Cancel();

    public void Close(DateTime closedDate) => this.State.Close(closedDate);

    public void Open(DateTime? writtenDate = null) => this.State.Open(writtenDate);

    public void Update() => this.State.Update();

    public void Void() => this.State.Void();
}
