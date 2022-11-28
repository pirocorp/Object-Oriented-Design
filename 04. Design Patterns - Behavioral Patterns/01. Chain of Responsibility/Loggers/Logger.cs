namespace ChainOfResponsibility.Loggers
{
    /// <summary>
    /// Abstract Handler in chain of responsibility pattern.
    /// </summary>
    public abstract class Logger
    {
        protected Logger(LogLevel mask)
        {
            this.LogMask = mask;
        }

        // The next Handler in the chain
        protected Logger? Next { get; private set; }

        protected LogLevel LogMask { get; }

        /// <summary>
        /// Sets the Next logger to make a list/chain of Handlers.
        /// </summary>
        public Logger SetNext(Logger nextLogger)
        {
            var lastLogger = this;

            while (lastLogger.Next != null)
            {
                lastLogger = lastLogger.Next;
            }

            lastLogger.Next = nextLogger;
            return this;
        }

        public void Message(string msg, LogLevel severity)
        {
            if ((severity & this.LogMask) != 0) // True only if any of the logMask bits are set in severity
            {
                this.WriteMessage(msg);
            }

            this.Next?.Message(msg, severity);
        }

        protected abstract void WriteMessage(string msg);
    }
}
