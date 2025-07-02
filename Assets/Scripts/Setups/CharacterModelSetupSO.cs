using UnityEngine;

[CreateAssetMenu(menuName = "Setups/CharacterModel")]
public class CharacterModelSO: ScriptableObject, ISetup<Character>
{
    [SerializeField] private CharacterModel model;

    public void Setup(Character target)
    {
        target.Setup(model);
    }
}