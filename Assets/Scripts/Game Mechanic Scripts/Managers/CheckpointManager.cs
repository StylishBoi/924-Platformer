using UnityEngine;
using System.Collections.Generic;

public class CheckpointManager : MonoBehaviour
{
    private List<Checkpoint> _allCheckpoints = new List<Checkpoint>();
    
    public GameObject player;
    public GameObject respawnPoint;
    void Start()
    {
        LoadCheckpoint();
    }

    public void LoadCheckpoint()
    {
        //Loads all the checkpoints while additionally teleporting the player to the start
        player.transform.position = respawnPoint.transform.position;
        
        Checkpoint[] checkpointsArray = GetComponentsInChildren<Checkpoint>();
        _allCheckpoints = new List<Checkpoint>(checkpointsArray);

        foreach (Checkpoint checkpoint in _allCheckpoints)
        {
            checkpoint.Activate();
        }
    }
}
