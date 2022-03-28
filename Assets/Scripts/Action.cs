using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject  // ScriptableObject is an asset used to store data and/or execute code 
// abstract class does not have any instance
{
    public string keyword;

    public abstract void RespondToInput(GameController controller, string noun);  // child classes of class Action will must implement this function
    
}
