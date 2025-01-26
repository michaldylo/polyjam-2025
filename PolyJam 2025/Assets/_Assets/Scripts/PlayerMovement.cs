using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D _controller;
    [SerializeField] private float _moveSpeed = 40f;
    private float _horizontalMove = 0f;
    private bool _jump = false;
    private bool _crouch = false;
    private int _playerId;
    private ControllableCharacter _character;

    private void Awake()
    {
        _playerId = GetComponent<ControllableCharacter>().PlayerId;
        _character = GetComponent<ControllableCharacter>();
    }

    private void Update()
    {
        if (!_character.IsBusy)
        {
            _horizontalMove = Input.GetAxisRaw("Horizontal" + _playerId) * _moveSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                _jump = true;
            }

            if (Input.GetButtonDown("Crouch"))
            {
                _crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                _crouch = false;
            }
        }
    }

    private void FixedUpdate()
    {
        _controller.Move(_horizontalMove * Time.fixedDeltaTime, _crouch, _jump);
        _jump = false;
    }
}
