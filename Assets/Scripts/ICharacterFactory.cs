using UnityEngine;

public interface ICharacterFactory
{
    GameObject CreateCharacter<T>(ICharacterSetup config, Vector3 position, Quaternion rotation, out GameObject character);
}
