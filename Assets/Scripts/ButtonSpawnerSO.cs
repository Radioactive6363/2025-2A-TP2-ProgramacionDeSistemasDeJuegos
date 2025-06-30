using UnityEngine;

[CreateAssetMenu(menuName = "SpawnerButton")]
public class ButtonSpawnerSO : ScriptableObject
{
    public string text;
    public InterfaceRef<ICharacterSetup> characterSetup;
}

