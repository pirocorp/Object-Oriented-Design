namespace Simple_Factory.UserName
{
    /// <summary>
    /// That is the fundamental principle of the Simple Factory Pattern,
    /// to create an abstraction that decides which of the several possible
    /// classes to return. A developer simply calls a method of the class
    /// without knowing the implementation detail or which subclass it actually
    /// uses to implement the logic.
    /// </summary>
    public class UsernameFactory
    {
        public UserName GetUserName(string name)
        {
            if (name.Contains(","))
            {
                return new LastNameFirst(name);
            }

            return new FirstNameFirst(name);
        }
    }
}
