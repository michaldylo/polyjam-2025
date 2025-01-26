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

    [SerializeField] private float[] _cleanTime = new float[5];
    public float[] CleanTime => _cleanTime;
}
