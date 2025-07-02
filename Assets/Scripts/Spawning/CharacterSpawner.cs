using System;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour, ICharacterSpawnerServ
{
    private ISetupFactory _setupFactory;

    public void Awake()
    {
        ServiceLocator.Register<ICharacterSpawnerServ>(this);
        StartService(ServiceLocator.Get<ISetupFactory>());
    }
    
    public void StartService(ISetupFactory setupFactory)
    {
        _setupFactory = setupFactory;
    }

    public void Spawn(ICharacterSetup config)
    {
        if (_setupFactory == null)
        {
            Debug.LogError("Error Spawning - Character Factory Missing");
            return;
        }
        _setupFactory.TryCreate<ISetup>(config, transform.position, transform.rotation, out GameObject character);
    }
}
