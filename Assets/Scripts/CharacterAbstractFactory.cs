    using UnityEngine;
using UnityEngine.UIElements;

using Unity.VisualScripting;
using UnityEngine;

public class CharacterFactory : IUnityFactory
{
    public GameObject CreateCharacter<T>(ICharacterSetup config, Vector3 position, Quaternion rotation, out GameObject character)
    {
        var result = Object.Instantiate(config.prefab, position, rotation);

        foreach (var setupRef in config.characterSetups)
        {
            var setupInstance = setupRef.Ref;
            if (setupInstance == null)
                continue;

            if (setupInstance is ISetup<T> setup)
            {
                var component = result.GetComponent<T>();
                if (component != null)
                    setup.Setup(component);
            }
        }
        var animator = result.GetComponentInChildren<Animator>();
        if (!animator)
            animator = result.AddComponent<Animator>();
        animator.runtimeAnimatorController = config.animatorController;

        character = result;
        return result;
    }
}