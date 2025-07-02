using UnityEngine;

public class ConsoleLogHandler : ILogHandler
{
    private readonly ILogHandler _defaultHandler;

    public ConsoleLogHandler(ILogHandler defaultHandler)
    {
        _defaultHandler = defaultHandler;
    }

    public void LogFormat(LogType logType, Object context, string format, params object[] args)
    {
        _defaultHandler.LogFormat(logType, context, format, args);
        ConsoleManager.Instance?.AddLog(string.Format(format, args), logType);
    }

    public void LogException(System.Exception exception, Object context)
    {
        _defaultHandler.LogException(exception, context);
        ConsoleManager.Instance?.AddLog(exception.ToString(), LogType.Exception);
    }
}