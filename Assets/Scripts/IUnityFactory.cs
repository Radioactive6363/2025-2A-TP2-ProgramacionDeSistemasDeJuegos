using UnityEngine;

public interface IUnityFactory
{
    GameObject CreateCharacter<T>(ICharacterSetup config, Vector3 position, Quaternion rotation, out GameObject character);
}
