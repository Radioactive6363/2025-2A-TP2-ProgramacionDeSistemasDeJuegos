using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spawner/ButtonSpawner")]
public class ButtonSpawnerSO : ScriptableObject, IGameObjectSetup
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private List<InterfaceRef<ISetup>> _setups;

    public GameObject prefab => _prefab;
    public List<InterfaceRef<ISetup>> setups => _setups;
}