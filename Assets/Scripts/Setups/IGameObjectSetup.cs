using System.Collections.Generic;
using UnityEngine;

public interface IGameObjectSetup
{
    GameObject prefab { get; }
    List<InterfaceRef<ISetup>> setups { get; }
}