using UnityEngine;

public class SetupFactory : ISetupFactory
{
    /// <summary>
    /// Crea un GameObject a partir de una configuración (prefab + setups),
    /// agrega los componentes necesarios si no existen,
    /// y aplica configuraciones usando los setups correspondientes.
    /// Abstract Factory de GameObjects.
    /// </summary>
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