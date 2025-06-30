using System;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    private void Awake()
    {
        ServiceLocator.Register<IUnityFactory>(new CharacterFactory());
        
    }

    private void OnDestroy()
    {
        ServiceLocator.Unregister<IUnityFactory>();
    }
}