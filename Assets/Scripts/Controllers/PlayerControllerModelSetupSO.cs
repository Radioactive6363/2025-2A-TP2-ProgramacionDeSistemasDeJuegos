using UnityEngine;

[CreateAssetMenu(menuName = "Setups/PlayerController")]
public class PlayerControllerSetupSO : ScriptableObject, ISetup<PlayerController>
{
    [SerializeField] private PlayerControllerModel model;

    public void Setup(PlayerController target)
    {
        target.Setup(model);
    }
}