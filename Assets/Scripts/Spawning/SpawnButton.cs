using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButton : MonoBehaviour
{
    [SerializeField] private Button button;
    private ICharacterSetup _character;
    private ICharacterSpawnerServ _spawnerServ; 

    private void Reset()
        => button = GetComponent<Button>();
    
    private void Awake()
    {
        if (!button)
            button = GetComponent<Button>();
        _spawnerServ = ServiceLocator.Get<ICharacterSpawnerServ>();
    }

    private void OnEnable()
    {
        if (!button)
        {
            Debug.LogError($"{name} <color=grey>({GetType().Name})</color>: {nameof(button)} is null!");
            enabled = false;
            return;
        }
        button.onClick.AddListener(HandleClick);
    }

    private void OnDisable()
    {
        button?.onClick?.RemoveListener(HandleClick);
    }

    private void HandleClick()
    {
        if (_character == null)
        {
            Debug.LogError("Setup is null");
            return;
        }
        _spawnerServ.Spawn(_character);
    }
    
    public void SetCharacter(ICharacterSetup character)
    {
        _character = character;
    }
}