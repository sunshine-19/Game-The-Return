using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Inventory")]

public class Inventory : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (controller.player.inventory.Count == 0)
        {
            controller.currentText.text = "Oops! You have nothing!";
            return;
        }

        string result = "You have ";
        bool firstItem = true;

        foreach(Item item in controller.player.inventory)
        {
            if (firstItem)
            {
                result += "a " + item.itemName; // display text formatting
            }
            else
            {
                result += " and a " + item.itemName;  // display text formatting
                
            }
            firstItem = false;
        }
        controller.currentText.text = result;
    }
}
