using System;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites = new Sprite[5];
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private bool _isDirty;

    // private bool _needsSponge = false;
    // private bool _needsMop = false;
    // private bool _needsVacuumCleaner = false;
    // private bool _needsTrashCan = false;
    // private bool _needsFeatherDuster = false;
    private bool[] _needsTool = { false, false, false, false, false };

    [SerializeField] private Sprite[] _toolIcons = new Sprite[5];
    [SerializeField] private SpriteRenderer _toolIconRenderer;
    private int _toolId;

    private void Awake()
    {
        _isDirty = Convert.ToBoolean(UnityEngine.Random.Range(0, 2));

        if (_isDirty)
        {
            _toolId = UnityEngine.Random.Range(0, 5);

            _needsTool[_toolId] = true;
            // switch (toolId)
            // {
            //     case 0:
            //         _needsSponge = true;
            //         break;
            //     case 1:
            //         _needsMop = true;
            //         break;
            //     case 2:
            //         _needsVacuumCleaner = true;
            //         break;
            //     case 3:
            //         _needsTrashCan = true;
            //         break;
            //     case 4:
            //         _needsFeatherDuster = true;
            //         break;
            // }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerTag"))
        {
            ControllableCharacter.CharacterTypeEnum characterType = other.gameObject.GetComponent<ControllableCharacter>().CharacterType;

            if (_toolId == 0 && characterType == ControllableCharacter.CharacterTypeEnum.Son1)
            {

            }
            else if (_toolId == 1 && characterType == ControllableCharacter.CharacterTypeEnum.Mom)
            {

            }
            else if (_toolId == 2 && characterType == ControllableCharacter.CharacterTypeEnum.Dad)
            {

            }
            else if (_toolId == 3 && characterType == ControllableCharacter.CharacterTypeEnum.Son2)
            {

            }
            else if (_toolId == 4 && characterType == ControllableCharacter.CharacterTypeEnum.Daughter)
            {
                
            }
        }
    }
}
