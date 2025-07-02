using UnityEngine;

public class MenuGenerator : MonoBehaviour
{
    [SerializeField] private MenuButtonSpawnerSO menuConfig;
    [SerializeField] private Transform buttonContainer;

    private void Start()
    {
        var factory = ServiceLocator.Get<ISetupFactory>();

        foreach (var buttonConfig in menuConfig.buttonSetups)
        {
            factory.TryCreate(buttonConfig, Vector3.zero, Quaternion.identity, out var button, buttonContainer);
        }
    }
}
