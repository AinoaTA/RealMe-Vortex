using UnityEngine;

[CreateAssetMenu(fileName = "Relationship", menuName = "Relations / Settings", order = 1)]
public class StatusRelationship : ScriptableObject
{
    public enum CharacterType { CHAR1, CHAR2, CHAR3 }

    public CharacterType Character { get => _character; }
    [SerializeField]private CharacterType _character;
}
