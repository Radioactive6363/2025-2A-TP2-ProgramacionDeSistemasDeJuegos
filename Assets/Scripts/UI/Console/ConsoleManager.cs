using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ConsoleManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text logText;
    [SerializeField] private GameObject panel;
    public static ConsoleManager Instance { get; private set; }
    
    private ICommandRegistry _registry;
    private ConsoleInputActions _toggleAction;
    
    private void Start()
    {
        Instance = this;
        _registry = ServiceLocator.Get<ICommandRegistry>();
        RegisterDefaultCommands();
        panel.SetActive(false);
        _toggleAction = new ConsoleInputActions();
        _toggleAction.Enable();
        _toggleAction.Console.ToggleConsole.performed += ctx => Toggle();
        _toggleAction.Console.Submit.performed += ctx => OnSubmitCommand();
    }
    
    private void OnEnable()
    {
        _toggleAction.Enable();
    }

    private void OnDisable()
    {
        _toggleAction.Disable();
    }

    public void Toggle() => panel.SetActive(!panel.activeSelf);

    public void OnSubmitCommand()
    {
        var input = inputField.text;
        inputField.text = "";

        var parts = input.Split(' ');
        var command = _registry.Find(parts[0]);
        if (command != null)
            command.Execute(parts.Skip(1).ToArray());
        else
            AddLog($"Command not found: {parts[0]}", LogType.Warning);
    }

    public void AddLog(string message, LogType type)
    {
        logText.text += $"\n[{type}] {message}";
    }

    private void RegisterDefaultCommands()
    {
        _registry.Register(new HelpCommand(_registry));
        _registry.Register(new AliasesCommand(_registry));
        _registry.Register(new PlayAnimationCommand());
    }
}