using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private Image _interactionTextImage;
    [SerializeField] private Image[] _dialogueImages;

    private void Awake()
    {
        _interactionTextImage.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerTag"))
        {
            _interactionTextImage.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerTag"))
        {
            _interactionTextImage.enabled = false;
        }
    }
}
