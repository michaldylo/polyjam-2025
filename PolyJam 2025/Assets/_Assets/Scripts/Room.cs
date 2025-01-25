using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Room : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites = new Sprite[5];
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public bool IsDirty { get; set; }
    private Tool.ToolType _neededTool;
    [SerializeField] private Sprite[] _toolIcons = new Sprite[5];
    [SerializeField] private SpriteRenderer _toolIconRenderer;
    private bool _playerIsInRange = false;
    private InputAction _interact1Action;
    private InputAction _interact2Action;
    private int _playerId;

    private void Awake()
    {
        IsDirty = Convert.ToBoolean(UnityEngine.Random.Range(0, 2));

        if (IsDirty)
        {
            _interact1Action = InputSystem.actions.FindAction("Interact1");
            _interact2Action = InputSystem.actions.FindAction("Interact2");

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
            if (_playerId == 1 && _interact1Action.WasPressedThisFrame())
            {
                Debug.Log("Cleaning in progress...");
            }
            else if (_playerId == 2 && _interact2Action.WasPressedThisFrame())
            {
                Debug.Log("Cleaning in progress...");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerTag"))
        {
            ControllableCharacter.CharacterTypeEnum characterType = other.gameObject.GetComponent<ControllableCharacter>().CharacterType;
            _playerId = other.gameObject.GetComponent<ControllableCharacter>().PlayerId;

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
