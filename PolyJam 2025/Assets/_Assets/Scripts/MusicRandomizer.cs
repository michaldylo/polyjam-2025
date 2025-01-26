using UnityEngine;

public class MusicRandomizer : MonoBehaviour
{
    [SerializeField] private AudioSource[] _audioSoruces = new AudioSource[2];
    
    private void Start()
    {
        int musicId = UnityEngine.Random.Range(0, 2);

        _audioSoruces[musicId].Play();
    }
}
