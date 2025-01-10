using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] AudioManager _audioManager;
    bool firstDectect;
    private RespawnScript respawn;
    void Awake()
    {
        respawn=GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Checkpoint entered");
            
            //Verify if it is the first time the player went into this checkpoint
            if (firstDectect == false)
            {
                firstDectect = true;
                //Change the respawn point to this one
                respawn.respawnPoint = this.gameObject;
                _audioManager.PlaySfx(_audioManager.checkpointSFX);
            }
        }
    }
    
    public void Activate()
    {
        //Reactivate the checkpoints
        firstDectect = false;
    }
}
