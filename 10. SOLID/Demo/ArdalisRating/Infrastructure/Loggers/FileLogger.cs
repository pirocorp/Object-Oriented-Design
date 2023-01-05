namespace ArdalisRating.Infrastructure.Loggers;

using System.IO;

using ArdalisRating.Core.Interfaces;

public class FileLogger : ILogger
{
    public void Log(string message)
    {
        using var stream = File.AppendText("log.txt");

        stream.WriteLine(message);
        stream.Flush();
    }
}
