using UnityEngine;

public class ContactDetector : MonoBehaviour
{
    private bool _contactDetected = false;
    public bool ContactDectected => _contactDetected;
    
    //Both methods will verify if the player is on the ground or not
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Contact")) _contactDetected = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Contact")) _contactDetected = false;
    }
}
