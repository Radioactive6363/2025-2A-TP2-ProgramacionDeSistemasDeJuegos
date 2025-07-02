using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spawner/ButtonSpawner")]
public class ButtonSpawnerSO : ScriptableObject, IGameObjectSetup
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private List<InterfaceRef<ISetup>> setups;

    public GameObject Prefab => prefab;
    public List<InterfaceRef<ISetup>> Setups => setups;
}