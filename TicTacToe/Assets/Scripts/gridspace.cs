using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gridspace : MonoBehaviour
{
    public Button button=null;
    public Text buttonText=null;
    private GameController gameController=null;

    public void SetGameControllerReference(GameController controller)
    {
        gameController = controller;
    }
    public void SetSpace()
    {
        buttonText.text = gameController.GetPlayerSide();
        button.interactable = false;
        gameController.EndTurn();   
    }
}
