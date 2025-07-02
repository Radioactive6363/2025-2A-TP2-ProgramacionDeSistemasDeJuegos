using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationCommand : IConsoleCommand
{
    public string Name => "playanimation";
    public string Description => "Plays Animations on All Characters.";
    public IEnumerable<string> Aliases => new[] { "anim", "pa", "playanim", "startanim", "playanims", "startanims" };

    public void Execute(string[] args)
    {
        if (args.Length == 0)
        {
            Debug.Log("Use: playanimation <name>");
            return;
        }
        
        var name = args[0];
        var characters = GameObject.FindGameObjectsWithTag("Character");

        foreach (var c in characters)
        {
            var anim = c.GetComponentInChildren<Animator>();
            if (anim != null)
                anim.Play(name);
        }
    }
}