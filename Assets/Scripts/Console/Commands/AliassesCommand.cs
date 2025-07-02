using System.Collections.Generic;
using UnityEngine;

public class AliasesCommand : IConsoleCommand
{
    private readonly ICommandRegistry _registry;

    public AliasesCommand(ICommandRegistry registry)
    {
        _registry = registry;
    }

    public string Name => "aliases";
    public string Description => "Shows Aliases of Command.";
    public IEnumerable<string> Aliases => new[] { "alias", "a", "alia" };

    public void Execute(string[] args)
    {
        if (args.Length == 0)
        {
            Debug.Log("Use: aliases <comando>");
            return;
        }

        var command = _registry.Find(args[0]);
        if (command != null)
        {
            var aliasList = string.Join(", ", command.Aliases);
            Debug.Log($"Alias of '{command.Name}': {aliasList}");
        }
        else
        {
            Debug.Log($"Command '{args[0]}' not Found.");
        }
    }
}