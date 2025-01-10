using UnityEngine;

public class JumpPadManager : MonoBehaviour
{
    // Not really a point for this to be a manager apart to play SFX

    [SerializeField] AudioManager _audioManager;

    public void JumpPadSound()
    {
        _audioManager.PlaySfx(_audioManager.jumppadSFX);
    }
}
