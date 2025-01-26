using UnityEngine;
using UnityEngine.InputSystem;

public class Stairs : MonoBehaviour
{
    private enum Type
    {
        Up,
        Down
    }

    private InputAction _moveUp1Action;
    private InputAction _moveUp2Action;
    private InputAction _moveDown1Action;
    private InputAction _moveDown2Action;
    private bool _playerIsInRange = false;
    private bool _didFirstRangeCheck = false;
    private Type _type = Type.Up;
    private int _playerId;
    [SerializeField] private Vector3 _destination;
    private GameObject _playerCharacter;

    private void Awake()
    {
        _moveUp1Action = InputSystem.actions.FindAction("MoveUp1");
        _moveUp2Action = InputSystem.actions.FindAction("MoveUp2");
        _moveDown1Action = InputSystem.actions.FindAction("MoveDown1");
        _moveDown2Action = InputSystem.actions.FindAction("MoveDown2");
    }

    private void Update()
    {
        if (_playerIsInRange)
        {
            if (_type == Type.Up)
            {
                if (_playerId == 1 && _moveUp1Action.WasPressedThisFrame())
                {
                    MovePlayerToDestination();
                }
                else if (_playerId == 2 && _moveUp2Action.WasPressedThisFrame())
                {
                    MovePlayerToDestination();
                }
            }
            else
            {
                if (_playerId == 1 && _moveDown1Action.WasPressedThisFrame())
                {
                    MovePlayerToDestination();
                }
                else if (_playerId == 2 && _moveDown2Action.WasPressedThisFrame())
                {
                    MovePlayerToDestination();
                }
            }
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

    private void CheckIfPlayerIsInRange(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerTag") && other.gameObject.GetComponent<PlayerMovement>().enabled)
        {
            _playerId = other.gameObject.GetComponent<ControllableCharacter>().PlayerId;
            _playerIsInRange = true;
            _playerCharacter = other.gameObject;
        }
    }

    private void MovePlayerToDestination()
    {
        _playerCharacter.transform.position = _destination;
    }
}
