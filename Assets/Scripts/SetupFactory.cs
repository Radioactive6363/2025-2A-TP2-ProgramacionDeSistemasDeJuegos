    using UnityEngine;
using UnityEngine.UIElements;

using Unity.VisualScripting;
using UnityEngine;

public class SetupFactory : ISetupFactory
{
    public bool TryCreate<T>(IGameObjectSetup config, Vector3 position, Quaternion rotation, out GameObject gameObject, Transform parent = null)
    {
        var result = Object.Instantiate(config.prefab, position, rotation, parent);

        foreach (var setupRef in config.setups)
        {
            var setupInstance = setupRef.Ref;
            if (setupInstance is not ISetup<T> setup) 
                continue;
            
            var component = result.GetComponentInChildren<T>();
            if (component != null)
                setup.Setup(component);
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