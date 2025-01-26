using UnityEngine;

public class Tool : MonoBehaviour
{
    public enum ToolType
    {
        Sponge,
        Mop,
        VacuumCleaner,
        TrashCan,
        FeatherDuster
    }

    [SerializeField] private float[] _cleanTime = { 4f, 6f, 5f, 3f, 2f };
    public float[] CleanTime => _cleanTime;
}
