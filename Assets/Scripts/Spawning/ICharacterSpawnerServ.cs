using UnityEngine;

public interface ICharacterSpawnerServ
{
    void StartService(ISetupFactory setupFactory);
    void Spawn(ICharacterSetup config);
}
