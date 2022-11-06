using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public string name;
    public int amount;
    public Item(string name, int amount) {
        this.name = name;
        this.amount = amount;
    }
}

// Write an inventory for the player.

public class InventoryManager : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();
    public int maxSlots = 10;

    // Start is called before the first frame update
    void Start()
    {
        // Add a few items to the inventory.
        inventory.Add(new Item("Sword", 1));
        inventory.Add(new Item("Shield", 1));
        inventory.Add(new Item("Potion", 3));
    }

    // Update is called once per frame
    void Update()
    {
        // If the player presses the I key, print the inventory.
        if (Input.GetKeyDown(KeyCode.I))
        {
            PrintInventory();
        }
    }

    // Print the inventory.
    void PrintInventory()
    {
        // Loop through the inventory.
        for (int i = 0; i < inventory.Count; i++)
        {
            // Print the item name and quantity.
            Debug.Log(inventory[i].name + ": " + inventory[i].amount);
        }
    }
}
