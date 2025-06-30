using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButton : MonoBehaviour, ISetup<ButtonSpawnerSO>
{
    [SerializeField] private Button button;
    private TextMeshProUGUI title;
    private ICharacterSetup _character;
    private ICharacterSpawnerServ _spawnerServ; 

    private void Reset()
        => button = GetComponent<Button>();
    
    public void Setup(ButtonSpawnerSO model)
    {
        title.text = model.text;
        _character = model.characterSetup.Ref;
        
        GetComponent<Button>().onClick.AddListener(HandleClick);
    }
    
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
}