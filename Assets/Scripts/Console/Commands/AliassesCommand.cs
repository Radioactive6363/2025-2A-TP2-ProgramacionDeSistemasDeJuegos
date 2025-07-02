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
    public string Description => "Muestra los alias asociados a un comando.";
    public IEnumerable<string> Aliases => new[] { "alias", "a" };

    public void Execute(string[] args)
    {
        if (args.Length == 0)
        {
            Debug.Log("Uso: aliases <comando>");
            return;
        }

        var command = _registry.Find(args[0]);
        if (command != null)
        {
            var aliasList = string.Join(", ", command.Aliases);
            Debug.Log($"Alias de '{command.Name}': {aliasList}");
        }
        else
        {
            Debug.Log($"Comando '{args[0]}' no encontrado.");
        }
    }
}