using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Player player;

    public InputField textEntryField;
    public Text logText;
    public Text currentText;

    public Action[] actions;

    [TextArea]
    public string introText;


    // Start is called before the first frame update
    void Start()
    {
        logText.text = introText;
        DisplayLocation();
        textEntryField.ActivateInputField();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void DisplayLocation(bool additive = false)
    {
        string description = player.currentLocation.description + "\n";
        description += player.currentLocation.GetConnectionsText();
        description += player.currentLocation.GetItemsText();
        if (additive)
            currentText.text = currentText.text + "\n" + description;
        else
            currentText.text = description;
    }

    public void TextEntered()
    {
        LogCurrentText();
        ProcessInput(textEntryField.text);
        textEntryField.text = "";
        textEntryField.ActivateInputField();
    }

    void LogCurrentText()
    {
        logText.text += "\n\n";
        logText.text += currentText.text;

        logText.text += "\n\n";
        logText.text += "<color=#aaccaaff>" + textEntryField.text + "</color>";
    }

    void ProcessInput(string input)
    {
        input = input.ToLower();
        char[] delimiter = { ' ' };
        string[] separatedWords = input.Split(delimiter);

        foreach(Action action in actions)
        {
            // seperatedWords[0] is verb
            // seperatedWords[1] is noun
            if (action.keyword.ToLower() == separatedWords[0])
            {
                if (separatedWords.Length > 1)  // error handling if user inputs only one word
                {
                    action.RespondToInput(this, separatedWords[1]);
                }
                else
                {
                    action.RespondToInput(this, "");
                }
                return;
            }
        }


        currentText.text = "Nothings happens! (stuck? type Help)";
    }
}
