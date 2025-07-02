using UnityEngine;

public class SetupFactory : ISetupFactory
{
    /// <summary>
    /// Creates a GameObject from a configuration (prefab and configurations),
    /// adds the necessary components if they don't exist,
    /// and applies the corresponding configurations.
    /// Abstract Factory Pattern for GameObjects.
    /// </summary>
    public bool TryCreate(IGameObjectSetup config, Vector3 position, Quaternion rotation, out GameObject gameObject, Transform parent = null)
    {
        var result = Object.Instantiate(config.prefab, position, rotation, parent);
        result.tag = "Character";
        
        foreach (var setupRef in config.setups)
        {
            var setupInstance = setupRef.Ref;
            if (setupInstance == null)
                continue;

            var interfaces = setupInstance.GetType().GetInterfaces();

            foreach (var iface in interfaces)
            {
                if (!iface.IsGenericType || iface.GetGenericTypeDefinition() != typeof(ISetup<>))
                    continue;

                var targetType = iface.GetGenericArguments()[0];
                
                var component = result.GetComponentInChildren(targetType);
                if (component == null && typeof(Component).IsAssignableFrom(targetType))
                {
                    component = result.AddComponent(targetType);
                }
                var method = iface.GetMethod("Setup");
                method?.Invoke(setupInstance, new[] { component });
            }
        }
        
        if (config is ICharacterSetup characterSetup)
        {
            var animator = result.GetComponentInChildren<Animator>();
            if (!animator)
                animator = result.AddComponent<Animator>();

            animator.runtimeAnimatorController = characterSetup.animatorController;
        }

        gameObject = result;
        return result != null;
    }
}