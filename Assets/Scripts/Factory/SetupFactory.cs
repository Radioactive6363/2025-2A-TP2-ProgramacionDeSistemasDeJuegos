using UnityEngine;

public class SetupFactory : ISetupFactory
{
    public bool TryCreate(IGameObjectSetup config, Vector3 position, Quaternion rotation, out GameObject gameObject, Transform parent = null)
    {
        var result = Object.Instantiate(config.prefab, position, rotation, parent);

        
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

                var targetType = iface.GetGenericArguments()[0]; // T
                var component = result.GetComponentInChildren(targetType);
                if (component == null)
                    continue;

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