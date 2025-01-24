using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private string[] _itemTags;
    private bool[] _itemPossesions;

    private void Awake()
    {
        _itemPossesions = new bool[_itemTags.Length];

        for (int i = 0; i < _itemPossesions.Length; ++i)
        {
            _itemPossesions[i] = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i < _itemTags.Length; ++i)
        {
            if (other.CompareTag(_itemTags[i]))
            {
                _itemPossesions[i] = true;
                Destroy(other.gameObject);
            }
        }
    }
}
