using System;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    private void Awake()
    {
        ServiceLocator.Register<ISetupFactory>(new SetupFactory());
        
    }

    private void OnDestroy()
    {
        ServiceLocator.Unregister<ISetupFactory>();
    }
}