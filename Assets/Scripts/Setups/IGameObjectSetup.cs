using System.Collections.Generic;
using UnityEngine;

public interface IGameObjectSetup
{
    GameObject Prefab { get; }
    List<InterfaceRef<ISetup>> Setups { get; }
}