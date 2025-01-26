using UnityEngine;

public class ControllableCharacter : MonoBehaviour
{
    public enum CharacterTypeEnum
    {
        Son1,
        Mom,
        Dad,
        Son2,
        Daughter
    }

    [SerializeField] private int _playerId = -1;
    public int PlayerId => _playerId;
    // [SerializeField] private int _characterId = -1;
    // public int CharacterId => _characterId;
    [SerializeField] private CharacterTypeEnum _characterType;
    public CharacterTypeEnum CharacterType => _characterType;
    public bool IsBusy { get; set; }
}
