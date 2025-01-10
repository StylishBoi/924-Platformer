using System;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    [SerializeField] AudioManager _audioManager;
    [SerializeField] ItemManager _itemManager;
    
    public GameObject player;
    public GameObject respawnPoint;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If the player encounters a dangerous element, he will reset to the last checkpoint
        if (other.CompareTag("Danger"))
        {
            _audioManager.PlaySfx(_audioManager.deathSFX);
            player.transform.position = respawnPoint.transform.position;
        }
    }
}