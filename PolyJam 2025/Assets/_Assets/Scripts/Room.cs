using System;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites = new Sprite[5];
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private bool _isDirty;
    private Tool.ToolType _neededTool;
    [SerializeField] private Sprite[] _toolIcons = new Sprite[5];
    [SerializeField] private SpriteRenderer _toolIconRenderer;
    private bool _playerIsInRange = false;

    private void Awake()
    {
        _isDirty = Convert.ToBoolean(UnityEngine.Random.Range(0, 2));

        if (_isDirty)
        {
            int toolId = UnityEngine.Random.Range(0, 5);

            switch (toolId)
            {
                case 0:
                    _neededTool = Tool.ToolType.Sponge;
                    break;
                case 1:
                    _neededTool = Tool.ToolType.Mop;
                    break;
                case 2:
                    _neededTool = Tool.ToolType.VacuumCleaner;
                    break;
                case 3:
                    _neededTool = Tool.ToolType.TrashCan;
                    break;
                case 4:
                    _neededTool = Tool.ToolType.FeatherDuster;
                    break;
            }

            _toolIconRenderer.sprite = _toolIcons[toolId];
        }
    }

    private void Update()
    {
        if (_playerIsInRange)
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerTag"))
        {
            ControllableCharacter.CharacterTypeEnum characterType = other.gameObject.GetComponent<ControllableCharacter>().CharacterType;
            
            if (PlayerHasRightTool(characterType))
            {
                _playerIsInRange = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _playerIsInRange = false;
    }

    private bool PlayerHasRightTool(ControllableCharacter.CharacterTypeEnum characterType)
    {
        if (_neededTool == Tool.ToolType.Sponge && characterType == ControllableCharacter.CharacterTypeEnum.Son1)
        {
            return true;
        }
        else if (_neededTool == Tool.ToolType.Mop && characterType == ControllableCharacter.CharacterTypeEnum.Mom)
        {
            return true;
        }
        else if (_neededTool == Tool.ToolType.VacuumCleaner && characterType == ControllableCharacter.CharacterTypeEnum.Dad)
        {
            return true;
        }
        else if (_neededTool == Tool.ToolType.TrashCan && characterType == ControllableCharacter.CharacterTypeEnum.Son2)
        {
            return true;
        }
        else if (_neededTool == Tool.ToolType.FeatherDuster && characterType == ControllableCharacter.CharacterTypeEnum.Daughter)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
