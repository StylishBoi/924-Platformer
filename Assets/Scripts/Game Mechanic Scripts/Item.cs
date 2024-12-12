using UnityEngine;
using System;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject _gem;
    
    public event Action<Item> OnPicked;
    
    void Start()
    {
        //Activates every gem at the start
        Activate();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Verfify that the item collides the player hitbox
        if (other.CompareTag("Player"))
        {
            Deactivate();
            
            //Checks if the item is picked or not
            //ASK ABOUT THIS
            OnPicked?.Invoke(this);
        }
    }
    
    //Deactivate an individual gem 
    public void Deactivate()
    {
        _gem.SetActive(false);
    }

    //Activate an individual gem 
    public void Activate()
    {
        _gem.SetActive(true);
    }

}
