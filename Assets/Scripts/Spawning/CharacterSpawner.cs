using System;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour, ICharacterSpawnerServ
{
    private IUnityFactory _characterFactory;

    public void Start()
    {
        ServiceLocator.Register<ICharacterSpawnerServ>(this);
    }

    public void StartService(IUnityFactory characterFactory)
    {
        _characterFactory = characterFactory;
    }

    public void Spawn(ICharacterSetup config)
    {
        if (_characterFactory == null)
        {
            Debug.LogError("Error Spawning - Character Factory Missing");
            return;
        }
        _characterFactory.CreateCharacter<ISetup>(config, transform.position, transform.rotation, out GameObject character);
    }
}
