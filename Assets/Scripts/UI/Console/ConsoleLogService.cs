using UnityEngine;

public class ConsoleLogService : IConsoleLogService
{
    private bool _initialized = false;

    public void Initialize()
    {
        if (_initialized) return;

        var currentHandler = Debug.unityLogger.logHandler;
        Debug.unityLogger.logHandler = new ConsoleLogHandler(currentHandler);

        _initialized = true;
    }
}
