using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public string locationName;

    [TextArea]
    public string description;

    public Connection[] connections;

    public List<Item> items = new List<Item>();   // since the no of items vary at different locations, we have used list

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetItemsText()
    {
        if (items.Count == 0) return "";
        string result = "You see ";
        bool firstItem = true;
        foreach(Item item in items)
        {
            if (item.itemEnabled) // to check the availability of the item
            {
                if (!firstItem) result += " and "; // Display text formatting
                result += item.description;
                firstItem = false;
            }       

        }
        result += "\n";
        return result;
    }

    internal bool HasItem(Item itemToCheck)
    {
        foreach (Item item in items)
        {
            if (item == itemToCheck && item.itemEnabled)
            {
                return true;
            }
        }
        return false;
    }

    public string GetConnectionsText()
    {
        string result = "";
        foreach (Connection connection in connections)
        {
            if (connection.connectionEnabled)
                result += connection.description + "\n";

        }
        return result;
    }

    public Connection GetConnection(string connectionNoun)
    {
        foreach(Connection connection in connections)
        {
            if (connection.connectionName.ToLower() == connectionNoun.ToLower())
                return connection;
        }
        return null;
    }

}
