using System;
using UnityEngine;

public class DangerDetector : MonoBehaviour
{
    private bool _dangerDetected = false;
    public bool DangerDetected => _dangerDetected;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Danger")) _dangerDetected = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Danger Detected");
        if (other.CompareTag("Danger")) _dangerDetected = false;
    }
}