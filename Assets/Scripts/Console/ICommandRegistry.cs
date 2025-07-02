using System.Collections.Generic;

/// <summary>
/// Interface for Command Registry.
/// </summary>

public interface ICommandRegistry
{
    void Register(IConsoleCommand command);
    
    IConsoleCommand Find(string name);
    
    IEnumerable<IConsoleCommand> GetAll();
    
    void Unregister(string name);
}