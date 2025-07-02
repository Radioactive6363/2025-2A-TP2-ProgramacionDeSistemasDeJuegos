using System.Collections.Generic;

public interface ICommandRegistry
{
    void Register(IConsoleCommand command);
    
    IConsoleCommand Find(string name);
    
    IEnumerable<IConsoleCommand> GetAll();
    
    void Unregister(string name);
}