using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MenuButtonSpawner")]
public class MenuButtonSpawnerSO : ScriptableObject
{
    public List<ButtonSpawnerSO> buttonSetups;
}

