using UnityEngine;

public interface ISetupFactory
{
    bool TryCreate<T>(IGameObjectSetup config, Vector3 position, Quaternion rotation, out GameObject character, Transform parent = null);
}
