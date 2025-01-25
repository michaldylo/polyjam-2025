using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _id = -1;
    public int Id => _id;
}
