using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class ItemManager : MonoBehaviour
{

    [SerializeField] private UnityEvent allItemsPickedUp;
    [SerializeField] UIManager _uiManager;
    [SerializeField] AudioManager _audioManager;
    
    //Fill the list with code
    private List<Item> _itemsToPick = new List<Item>();
    
    void Start()
    {
        LoadItems();
    }
    
    public void LoadItems()
    {
        //Will send back a table with all the items
        Item[] itemsArray = GetComponentsInChildren<Item>();
        _itemsToPick = new List<Item>(itemsArray);

        //Will activate each item present in the table and add it back to the list
        foreach (Item item in _itemsToPick)
        {
            item.Activate();
            item.OnPicked += RemoveItem;
        }
    }

    private void RemoveItem(Item itemToRemove)
    {
        //Remove an item from the map + Plays SFX + Updates score UI
        itemToRemove.OnPicked -= RemoveItem;
        _audioManager.PlaySfx(_audioManager.gemSFX);
        _uiManager.UpdateTotal(_itemsToPick.Count);
        
        //Remove an item from the list and checks if there are any items left
        _itemsToPick.Remove(itemToRemove);
        if (_itemsToPick.Count == 0)
        {
            allItemsPickedUp?.Invoke();
        }
    }
}
