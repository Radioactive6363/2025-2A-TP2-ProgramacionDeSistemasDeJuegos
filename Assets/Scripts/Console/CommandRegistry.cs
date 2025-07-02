using System.Collections.Generic;
using System.Linq;
/// <summary>
/// Stores and Handles registered commands via a Dictionary.
/// </summary>

public class CommandRegistry : ICommandRegistry
{
    private readonly Dictionary<string, IConsoleCommand> _commands = new();

    public void Register(IConsoleCommand command)
    {
        //Converts to lowercase to avoid inconveniences.
        _commands[command.Name.ToLower()] = command;
        foreach (var alias in command.Aliases)
        {
            _commands[alias.ToLower()] = command;
        }
    }

    public IConsoleCommand Find(string name)
    {
        _commands.TryGetValue(name.ToLower(), out var command);
        return command;
    }

    public IEnumerable<IConsoleCommand> GetAll()
    {
        return _commands.Values.Distinct();
    }

    public void Unregister(string name)
    {
        name = name.ToLower();
        if (_commands.TryGetValue(name, out var command))
        {
            var keysToRemove = _commands
                .Where(kvp => kvp.Value == command)
                .Select(kvp => kvp.Key)
                .ToList();

            foreach (var key in keysToRemove)
                _commands.Remove(key);
        }
    }
}