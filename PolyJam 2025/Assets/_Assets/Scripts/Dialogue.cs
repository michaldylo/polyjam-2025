using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private Image _interactionTextImage;
    [SerializeField] private Image _dialogueImage;
    [SerializeField] private Sprite[] _dialogueSprites;
    private InputAction _interactAction;
    private int _dialogueIndex = 0;
    private bool _isInRange = false;

    private void Awake()
    {
        _interactionTextImage.enabled = false;
        _interactAction = InputSystem.actions.FindAction("Interact");
    }

    private void Update()
    {
        if (_isInRange && _interactAction.WasPressedThisFrame())
        {
            _interactionTextImage.enabled = false;
            _dialogueImage.enabled = true;
            if (_dialogueIndex < _dialogueSprites.Length)
            {
                _dialogueImage.sprite = _dialogueSprites[_dialogueIndex];
            }
            else
            {
                _dialogueImage.enabled = false;
            }

            if (_dialogueIndex < _dialogueSprites.Length)
            {
                ++_dialogueIndex;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerTag"))
        {
            _isInRange = true;
            _interactionTextImage.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerTag"))
        {
            _isInRange = false;
            _interactionTextImage.enabled = false;
            _dialogueImage.enabled = false;
            _dialogueIndex = 0;
        }
    }
}
