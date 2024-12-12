using UnityEngine;

public class WallContactDetector : MonoBehaviour
{
    private bool _wallContactDetected = false;
    public bool WallContactDectected => _wallContactDetected;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Contact")) _wallContactDetected = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Wall Contact");
        if (other.CompareTag("Contact")) _wallContactDetected = false;
    }
}
