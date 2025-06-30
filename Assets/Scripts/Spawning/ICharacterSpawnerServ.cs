using UnityEngine;

public interface ICharacterSpawnerServ
{
    void StartService(IUnityFactory characterFactory);
    void Spawn(ICharacterSetup config);
}
