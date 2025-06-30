using System;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    private void Awake()
    {
        ServiceLocator.Register<ICharacterFactory>(new CharacterFactory());
        
    }

    private void OnDestroy()
    {
        ServiceLocator.Unregister<ICharacterFactory>();
    }
}