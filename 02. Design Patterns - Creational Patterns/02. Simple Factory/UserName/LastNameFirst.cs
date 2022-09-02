namespace Simple_Factory.UserName
{
    using System;

    public class LastNameFirst : UserName
    {
        public LastNameFirst(string username)
        {
            var index = username
                .Trim()
                .IndexOf(",", StringComparison.InvariantCultureIgnoreCase);

            if (index <= 0)
            {
                return;
            }

            // Substring(0, index) https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/ranges#systemrange
            this.LastName = username[..index].Trim();

            // Substring(index + 1)
            this.FirstName = username[(index + 1)..].Trim();
        }
    }
}
