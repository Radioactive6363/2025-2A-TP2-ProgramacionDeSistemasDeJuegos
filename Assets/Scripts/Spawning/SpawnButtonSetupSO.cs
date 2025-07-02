using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "Setups/SpawnButtonSetup")]
public class SpawnButtonSetupSO : ScriptableObject, ISetup<SpawnButton>
{
    [SerializeField] private string buttonText;
    [SerializeField] private InterfaceRef<ICharacterSetup> characterToSpawn;

    public void Setup(SpawnButton target)
    {
        if (target == null)
        {
            Debug.LogError("Target es null en SpawnButtonSetupSO");
            return;
        }
        
        var textComponent = target.GetComponentInChildren<TextMeshProUGUI>();
        if (textComponent != null)
            textComponent.text = buttonText;
        else
            Debug.LogWarning("TextMeshProUGUI no encontrado en " + target.name);
        
        target.SetCharacter(characterToSpawn.Ref);
    }
}