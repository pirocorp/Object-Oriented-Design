namespace Factory_Method.Documents
{
    using System.Collections.Generic;
    using Pages;

    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>
    public abstract class Document
    {
        private readonly List<IPage> pages = new ();

        // Constructor calls abstract Factory method
        protected Document()
        {
            this.CreatePages();
        }

        public List<IPage> Pages => this.pages;

        // Factory Method
        public abstract void CreatePages();
    }
}
