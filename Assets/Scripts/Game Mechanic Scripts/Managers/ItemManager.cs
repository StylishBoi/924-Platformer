using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class ItemManager : MonoBehaviour
{

    [SerializeField] private UnityEvent allItemsPickedUp;
    [SerializeField] UIManager _uiManager;
    [SerializeField] CheckpointManager _checkpointManager;
    [SerializeField] AudioManager _audioManager;
    
    //Fill the list with the items
    private List<Item> _itemsToPick = new List<Item>();
    int totalPickedUp = 0;
    
    void Start()
    {
        LoadItems();
    }
    
    public void LoadItems()
    {
        //Will send back a table with all the items
        totalPickedUp = 0;
        Item[] itemsArray = GetComponentsInChildren<Item>();
        _itemsToPick = new List<Item>(itemsArray);

        //Will activate each item present in the table and add it back to the list
        foreach (Item item in _itemsToPick)
        {
            item.Activate();
            item.OnPicked += RemoveItem;
        }
        //Set the UI and checkpoints so they can be reset too
        _uiManager.SetTotal();
        _checkpointManager.LoadCheckpoint();
    }

    private void RemoveItem(Item itemToRemove)
    {
        //Remove an item from the map + Plays SFX + Updates score UI
        itemToRemove.OnPicked -= RemoveItem;
        _audioManager.PlaySfx(_audioManager.gemSFX);
        _uiManager.UpdateTotal(totalPickedUp++);
        
        //Remove an item from the list and checks if there are any items left
        _itemsToPick.Remove(itemToRemove);
        if (_itemsToPick.Count == 0)
        {
            //Display win screen
            allItemsPickedUp?.Invoke();
        }
    }
}

//1 - Make it so player can't move after collecting every item (Pausing the game)
//2 - Include spring item
//3 - Include dash
