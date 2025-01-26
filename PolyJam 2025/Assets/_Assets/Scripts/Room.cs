using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Room : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites = new Sprite[5];
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public bool IsDirty { get; set; }
    public Tool.ToolType NeededTool { get; set; }
    // [SerializeField] private Sprite[] _toolIcons = new Sprite[5];
    [SerializeField] private SpriteRenderer _toolIconRenderer;
    public SpriteRenderer ToolIconRenderer => _toolIconRenderer;
    private bool _playerIsInRange = false;
    private InputAction _interact1Action;
    private InputAction _interact2Action;
    private int _playerId;
    private Tool _tool;
    private bool _didFirstRangeCheck = false;
    private InputAction _changeCharacter1Action;
    private InputAction _changeCharacter2Action;
    private BoxCollider2D _collider;

    private void Awake()
    {
        _interact1Action = InputSystem.actions.FindAction("Interact1");
        _interact2Action = InputSystem.actions.FindAction("Interact2");
        _tool = GameObject.FindWithTag("ToolScript").GetComponent<Tool>();
        _changeCharacter1Action = InputSystem.actions.FindAction("ChangeCharacter1");
        _changeCharacter2Action = InputSystem.actions.FindAction("ChangeCharacter2");
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (IsDirty && _playerIsInRange)
        {
            if (_playerId == 1 && _interact1Action.WasPressedThisFrame())
            {
                StartCoroutine(Clean(NeededTool));
            }
            else if (_playerId == 2 && _interact2Action.WasPressedThisFrame())
            {
                StartCoroutine(Clean(NeededTool));
            }
        }

        if (_changeCharacter1Action.WasPressedThisFrame() || _changeCharacter2Action.WasPressedThisFrame())
        {
            _didFirstRangeCheck = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckIfPlayerIsInRange(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!_didFirstRangeCheck)
        {
            CheckIfPlayerIsInRange(other);
            _didFirstRangeCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _playerIsInRange = false;
    }

    private bool PlayerHasRightTool(ControllableCharacter.CharacterTypeEnum characterType)
    {
        if (NeededTool == Tool.ToolType.Sponge && characterType == ControllableCharacter.CharacterTypeEnum.Son1)
        {
            return true;
        }
        else if (NeededTool == Tool.ToolType.Mop && characterType == ControllableCharacter.CharacterTypeEnum.Mom)
        {
            return true;
        }
        else if (NeededTool == Tool.ToolType.VacuumCleaner && characterType == ControllableCharacter.CharacterTypeEnum.Dad)
        {
            return true;
        }
        else if (NeededTool == Tool.ToolType.TrashCan && characterType == ControllableCharacter.CharacterTypeEnum.Son2)
        {
            return true;
        }
        else if (NeededTool == Tool.ToolType.FeatherDuster && characterType == ControllableCharacter.CharacterTypeEnum.Daughter)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator Clean(Tool.ToolType neededTool)
    {
        float cleanTime;

        switch (neededTool)
        {
            case Tool.ToolType.Sponge:
                cleanTime = _tool.CleanTime[0];
                break;
            case Tool.ToolType.Mop:
                cleanTime = _tool.CleanTime[1];
                break;
            case Tool.ToolType.VacuumCleaner:
                cleanTime = _tool.CleanTime[2];
                break;
            case Tool.ToolType.TrashCan:
                cleanTime = _tool.CleanTime[3];
                break;
            case Tool.ToolType.FeatherDuster:
                cleanTime = _tool.CleanTime[4];
                break;
            default:
                cleanTime = 2f;
                break;
        }

        Debug.Log("Cleaning in progress... (" + cleanTime + " s)");
        yield return new WaitForSeconds(cleanTime);
        IsDirty = false;
        _collider.enabled = false;
        ToolIconRenderer.sprite = null;
        Debug.Log("Cleaning complete!");
    }

    private void CheckIfPlayerIsInRange(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerTag") && other.gameObject.GetComponent<PlayerMovement>().enabled)
        {
            ControllableCharacter.CharacterTypeEnum characterType = other.gameObject.GetComponent<ControllableCharacter>().CharacterType;
            _playerId = other.gameObject.GetComponent<ControllableCharacter>().PlayerId;

            if (PlayerHasRightTool(characterType))
            {
                _playerIsInRange = true;
            }
        }
    }
}
