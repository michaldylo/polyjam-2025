using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterSwitcher : MonoBehaviour
{
    private InputAction _changeCharacter1Action;
    private InputAction _changeCharacter2Action;
    [SerializeField] private PlayerMovement[] _playerOneCharacters = new PlayerMovement[5];
    [SerializeField] private PlayerMovement[] _playerTwoCharacters = new PlayerMovement[5];
    private int[] _currentCharacterIndexes = { 0, 0 };
    [SerializeField] private Image[] _currentCharacterIcons = new Image[2];
    [SerializeField] private Sprite[] _playerOneCharacterIconSprites = new Sprite[5];
    [SerializeField] private Sprite[] _playerTwoCharacterIconSprites = new Sprite[5];
    private AudioSource _audioSource;

    private void Awake()
    {
        _changeCharacter1Action = InputSystem.actions.FindAction("ChangeCharacter1");
        _changeCharacter2Action = InputSystem.actions.FindAction("ChangeCharacter2");
        _audioSource = GetComponent<AudioSource>();
    }
    
    private void Start()
    {
        _playerOneCharacters[0].enabled = true;
        _playerTwoCharacters[0].enabled = true;

        for (int i = 1; i < _playerOneCharacters.Length; ++i)
        {
            _playerOneCharacters[i].enabled = false;
            _playerTwoCharacters[i].enabled = false;
        }
    }

    private void Update()
    {
        if (_changeCharacter1Action.WasPressedThisFrame())
        {
            SwitchCharacter(1);
        }

        if (_changeCharacter2Action.WasPressedThisFrame())
        {
            SwitchCharacter(2);
        }
    }

    private void SwitchCharacter(int playerId)
    {
        _audioSource.Play();

        switch (playerId)
        {
            case 1:
                _playerOneCharacters[_currentCharacterIndexes[playerId - 1]].enabled = false;
                _currentCharacterIndexes[playerId - 1] = (_currentCharacterIndexes[playerId - 1] + 1) % _playerOneCharacters.Length;
                _playerOneCharacters[_currentCharacterIndexes[playerId - 1]].enabled = true;
                _currentCharacterIcons[playerId - 1].sprite = _playerOneCharacterIconSprites[_currentCharacterIndexes[playerId - 1]];
                break;
            case 2:
                _playerTwoCharacters[_currentCharacterIndexes[playerId - 1]].enabled = false;
                _currentCharacterIndexes[playerId - 1] = (_currentCharacterIndexes[playerId - 1] + 1) % _playerTwoCharacters.Length;
                _playerTwoCharacters[_currentCharacterIndexes[playerId - 1]].enabled = true;
                _currentCharacterIcons[playerId - 1].sprite = _playerTwoCharacterIconSprites[_currentCharacterIndexes[playerId - 1]];
                break;
        }

        
    }
}
