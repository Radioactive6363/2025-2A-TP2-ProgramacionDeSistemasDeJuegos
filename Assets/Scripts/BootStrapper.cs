using System;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    /// <summary>
    /// Initializes the game, adding all necessary services to the ServiceLocator.
    /// </summary>
    private void Awake()
    {
        ServiceLocator.Register<ISetupFactory>(new SetupFactory());
        ServiceLocator.Register<ICommandRegistry>(new CommandRegistry());
        var logService = new ConsoleLogService();
        ServiceLocator.Register<IConsoleLogService>(logService);
        logService.Initialize();
    }

    private void OnDestroy()
    {
        ServiceLocator.Unregister<ISetupFactory>();
    }
}