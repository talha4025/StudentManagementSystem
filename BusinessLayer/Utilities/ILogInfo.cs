namespace BusinessLayer.Utilities
{
    // <summary>
    // Interface for log message save methods
    // <summary>

    public interface ILogInfo
    {
        void Log(string logMessage);
        void LogToFile(string logMessage, string fileName);
    }
}