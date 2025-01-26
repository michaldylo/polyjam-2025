using System;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] private int _numberOfRooms = 7;
    [SerializeField] private GameObject[] _playerOneRooms = new GameObject[7];
    [SerializeField] private GameObject[] _playerTwoRooms = new GameObject[7];
    [SerializeField] private Sprite[] _toolIcons = new Sprite[5];
    private bool _playerOneWon = false;
    private bool _playerTwoWon = false;

    private void Awake()
    {
        for (int i = 0; i < _playerOneRooms.Length; ++i)
        {
            bool isDirty = Convert.ToBoolean(UnityEngine.Random.Range(0, 3));
            _playerOneRooms[i].GetComponent<Room>().IsDirty = isDirty;
            _playerTwoRooms[i].GetComponent<Room>().IsDirty = isDirty;

            if (isDirty)
            {
                int toolId = UnityEngine.Random.Range(0, 5);

                switch (toolId)
                {
                    case 0:
                        _playerOneRooms[i].GetComponent<Room>().NeededTool = Tool.ToolType.Sponge;
                        _playerTwoRooms[i].GetComponent<Room>().NeededTool = Tool.ToolType.Sponge;
                        break;
                    case 1:
                        _playerOneRooms[i].GetComponent<Room>().NeededTool = Tool.ToolType.Mop;
                        _playerTwoRooms[i].GetComponent<Room>().NeededTool = Tool.ToolType.Mop;
                        break;
                    case 2:
                        _playerOneRooms[i].GetComponent<Room>().NeededTool = Tool.ToolType.VacuumCleaner;
                        _playerTwoRooms[i].GetComponent<Room>().NeededTool = Tool.ToolType.VacuumCleaner;
                        break;
                    case 3:
                        _playerOneRooms[i].GetComponent<Room>().NeededTool = Tool.ToolType.TrashCan;
                        _playerTwoRooms[i].GetComponent<Room>().NeededTool = Tool.ToolType.TrashCan;
                        break;
                    case 4:
                        _playerOneRooms[i].GetComponent<Room>().NeededTool = Tool.ToolType.FeatherDuster;
                        _playerTwoRooms[i].GetComponent<Room>().NeededTool = Tool.ToolType.FeatherDuster;
                        break;
                }

                _playerOneRooms[i].GetComponent<Room>().ToolIconRenderer.sprite = _toolIcons[toolId];
                _playerTwoRooms[i].GetComponent<Room>().ToolIconRenderer.sprite = _toolIcons[toolId];
            }
        }
    }

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
