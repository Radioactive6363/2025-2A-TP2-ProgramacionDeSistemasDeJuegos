using System.Linq;
using TMPro;
using UnityEngine;

public class ConsoleManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text logText;
    [SerializeField] private GameObject panel;
    public static ConsoleManager Instance { get; private set; }
    private ICommandRegistry registry;
    private void Start()
    {
        Instance = this;
        registry = ServiceLocator.Get<ICommandRegistry>();
        RegisterDefaultCommands();
        panel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            Toggle();
    }

    public void Toggle() => panel.SetActive(!panel.activeSelf);

    public void OnSubmitCommand()
    {
        var input = inputField.text;
        inputField.text = "";

        var parts = input.Split(' ');
        var command = registry.Find(parts[0]);
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
        registry.Register(new HelpCommand(registry));
        registry.Register(new AliasesCommand(registry));
        registry.Register(new PlayAnimationCommand());
    }
}