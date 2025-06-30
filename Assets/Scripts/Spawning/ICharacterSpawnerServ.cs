using UnityEngine;

public interface ICharacterSpawnerServ
{
    void StartService(ICharacterFactory characterFactory);
    void Spawn(ICharacterSetup config);
}
