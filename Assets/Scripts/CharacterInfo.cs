using UnityEngine;

[CreateAssetMenu(fileName = "Character Profile", menuName = "Characters/Profile")]
public class CharacterInfo : ScriptableObject
{
    public EnumsData.CharacterProfile Character { get => _character; }
    [SerializeField] private EnumsData.CharacterProfile _character;
}