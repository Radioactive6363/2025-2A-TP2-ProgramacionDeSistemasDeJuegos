using System.Collections.Generic;

    /// <summary>
    /// Base interface for all console commands.
    /// </summary>
public interface IConsoleCommand
{
    string Name { get; }
    string Description { get; }
    IEnumerable<string> Aliases { get; }

    void Execute(string[] args);
}
