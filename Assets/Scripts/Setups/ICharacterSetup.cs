using System.Collections.Generic;
using UnityEngine;

public interface ICharacterSetup : IGameObjectSetup
{
    RuntimeAnimatorController animatorController { get; }
}
