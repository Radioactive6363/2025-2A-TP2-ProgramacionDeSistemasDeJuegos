using System.Collections.Generic;
using UnityEngine;

public interface ICharacterSetup
{
    GameObject prefab { get; }
    List<InterfaceRef<ISetup>> characterSetups { get; }
    RuntimeAnimatorController animatorController { get; }
}
