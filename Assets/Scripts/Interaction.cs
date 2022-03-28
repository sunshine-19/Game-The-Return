using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]// it embeds the class with sub properties in the inspector
// we need this as the connection class is not derieved form MonoBehaviour
public class Interaction 
{
    public Action action;

    [TextArea]
    public string response;

    public string textMatch;

    public List<Item> itemsToDisable = new List<Item>();
    public List<Item> itemsToEnable = new List<Item>();

    public List<Connection> connectionsToDisable = new List<Connection>();
    public List<Connection> connectionsToEnable = new List<Connection>();

    public Location teleportLocation = null;
}
 