using System.Collections.Generic;
using UnityEngine;

public class HelpCommand : IConsoleCommand
{
    private readonly ICommandRegistry _registry;

    public HelpCommand(ICommandRegistry registry) => _registry = registry;

    public string Name => "help";
    public string Description => "Shows Info of Command.";
    public IEnumerable<string> Aliases => new[] { "?" };

    public void Execute(string[] args)
    {
        if (args.Length == 0)
        {
            Debug.Log("Use: help <Command>");
            return;
        }

        var command = _registry.Find(args[0]);
        if (command != null)
            Debug.Log($"{command.Name}: {command.Description}");
        else
            Debug.Log("Command not found.");
    }
}