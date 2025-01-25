using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] private int _numberOfRooms = 7;
    [SerializeField] private GameObject[] _playerOneRooms = new GameObject[7];
    [SerializeField] private GameObject[] _playerTwoRooms = new GameObject[7];
    private bool _playerOneWon = false;
    private bool _playerTwoWon = false;

    private void Update()
    {
        _playerOneWon = true;
        _playerTwoWon = true;

        for (int i = 0; i < _numberOfRooms; ++i)
        {
            if (_playerOneRooms[i].GetComponent<Room>().IsDirty)
            {
                _playerOneWon = false;
            }
            
            if (_playerTwoRooms[i].GetComponent<Room>().IsDirty)
            {
                _playerTwoWon = false;
            }
        }

        if (_playerOneWon)
        {
            Debug.Log("Player One Won!");
        }
        else if (_playerTwoWon)
        {
            Debug.Log("Player Two Won!");
        }
    }
}
