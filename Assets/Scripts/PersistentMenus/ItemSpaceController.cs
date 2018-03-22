//this was written by Carlos Hernandez
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpaceController : MonoBehaviour {

    public const int numItems = 8;
	public Item[] items = new Item[numItems];
    public bool[] inInventory = new bool[numItems];

    private Inventory inventory;


    // Use this for initialization
    void Start () {

        inventory = FindObjectOfType<Inventory>();

        for (int i = 0; i < numItems; i++)
        {
            inInventory[i] = false;
        }

    }



    void Update () {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (inInventory[0] == false)
                inventory.AddItem(items[0]);
            else
                inventory.RemoveItem(items[0]);

            inInventory[0] = !inInventory[0];
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (inInventory[1] == false)
                inventory.AddItem(items[1]);
            else
                inventory.RemoveItem(items[1]);

            inInventory[1] = !inInventory[1];
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (inInventory[2] == false)
                inventory.AddItem(items[2]);
            else
                inventory.RemoveItem(items[2]);

            inInventory[2] = !inInventory[2];
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (inInventory[3] == false)
                inventory.AddItem(items[3]);
            else
                inventory.RemoveItem(items[3]);

            inInventory[3] = !inInventory[3];
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (inInventory[4] == false)
                inventory.AddItem(items[4]);
            else
                inventory.RemoveItem(items[4]);

            inInventory[4] = !inInventory[4];
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (inInventory[5] == false)
                inventory.AddItem(items[5]);
            else
                inventory.RemoveItem(items[5]);

            inInventory[5] = !inInventory[5];
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (inInventory[6] == false)
                inventory.AddItem(items[6]);
            else
                inventory.RemoveItem(items[6]);

            inInventory[6] = !inInventory[6];
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (inInventory[7] == false)
                inventory.AddItem(items[7]);
            else
                inventory.RemoveItem(items[7]);

            inInventory[7] = !inInventory[7];
        }
    }
}
