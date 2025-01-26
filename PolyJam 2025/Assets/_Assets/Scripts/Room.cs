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

    private void Awake()
    {
        _interact1Action = InputSystem.actions.FindAction("Interact1");
        _interact2Action = InputSystem.actions.FindAction("Interact2");
    }

    private void Update()
    {
        if (_playerIsInRange)
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
                cleanTime = 4f;
                break;
            case Tool.ToolType.Mop:
                cleanTime = 6f;
                break;
            case Tool.ToolType.VacuumCleaner:
                cleanTime = 5f;
                break;
            case Tool.ToolType.TrashCan:
                cleanTime = 3f;
                break;
            case Tool.ToolType.FeatherDuster:
                cleanTime = 2f;
                break;
            default:
                cleanTime = 2f;
                break;
        }

        Debug.Log("Cleaning in progress... (" + cleanTime + " s)");
        yield return new WaitForSeconds(cleanTime);
        IsDirty = false;
        ToolIconRenderer.sprite = null;
        Debug.Log("Cleaning complete!");
    }
}
