using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSetup", menuName = "CharacterSetup")]
public class CharacterSetupSO : ScriptableObject, ICharacterSetup
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private List<InterfaceRef<ISetup>> characterModel;
    [SerializeField] private RuntimeAnimatorController animatorController;

    public GameObject Prefab => prefab;
    public List<InterfaceRef<ISetup>> Setups => characterModel;
    public RuntimeAnimatorController AnimatorController => animatorController;
}
