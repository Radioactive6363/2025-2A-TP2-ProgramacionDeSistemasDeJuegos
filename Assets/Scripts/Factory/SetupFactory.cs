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
        
        foreach (var setupRef in config.setups)
        {
            var setupInstance = setupRef.Ref;
            if (setupInstance == null)
                continue;
            
            //Tries to find the component that is implementing the ISetup<T> interface.
            var interfaces = setupInstance.GetType().GetInterfaces();
            foreach (var iface in interfaces)
            {
                if (!iface.IsGenericType || iface.GetGenericTypeDefinition() != typeof(ISetup<>))
                    continue;

                var targetType = iface.GetGenericArguments()[0];
                
                var component = result.GetComponentInChildren(targetType);
                //Once found, if the desired component doesn't exist & is valid (uses ISetup<T>), it is created and added to the GameObject.
                if (component == null && typeof(Component).IsAssignableFrom(targetType))
                {
                    component = result.AddComponent(targetType);
                }
                //Initializes the Setup Method from the ISetup<T> interface on the Component via "Reflection".
                var method = iface.GetMethod("Setup");
                method?.Invoke(setupInstance, new[] { component });
            }
        }
        
        if (config is ICharacterSetup characterSetup)
        {
            var animator = result.GetComponentInChildren<Animator>();
            if (!animator)
                animator = result.AddComponent<Animator>();
            result.tag = "Character";
            animator.runtimeAnimatorController = characterSetup.animatorController;
        }

        gameObject = result;
        return result != null;
    }
}