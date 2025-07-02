using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSetup", menuName = "CharacterSetup")]
public class CharacterSetupSO : ScriptableObject, ICharacterSetup
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private List<InterfaceRef<ISetup>> _characterModel;
    [SerializeField] private RuntimeAnimatorController _animatorController;

    public GameObject prefab => _prefab;
    public List<InterfaceRef<ISetup>> setups => _characterModel;
    public RuntimeAnimatorController animatorController => _animatorController;
}
