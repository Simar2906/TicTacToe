using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public Image panel=null;
    public Text text=null;
    public Button button = null;
} // created like this to prevent messy and complex code. All relevant objects are enclosed in these classes
[System.Serializable]
public class PlayerColour
{
    public Color panelColour;
    public Color textColour;
}
public class GameController : MonoBehaviour
{
    public Text[] buttonList=null;
    private string playerSide=null;
    public GameObject gameOverPanel= null;
    public Text gameOverText=null;
    private bool winner = false;
    public GameObject restartButton= null;
    private int moveCount = 0;

    public Player playerX = null;
    public Player playerO = null;
    public PlayerColour activeplayerColour;
    public PlayerColour inactiveplayerColour;

    public GameObject infoPanel= null;

    void Awake()
    {
        restartButton.SetActive(false); 
        gameOverPanel.SetActive(false);
        SetGameControllerReferenceOnButtons();
        //playerSide = "X"; //removed as we have to allow player to choose X or O
        moveCount = 0;
        //SetPlayerColours(playerX, playerO);

    } //player choosing state
    void startGame() //game start state
        {
            SetBoardInteractable(true);
            SetPlayerButton(false);
            infoPanel.SetActive(false);
        }
    public void SetStartingSide(string startingSide)
    {
        playerSide = startingSide;
        if(playerSide == "X")
        {
            SetPlayerColours(playerX, playerO);
        }
        else
        {
            SetPlayerColours(playerO, playerX);

        }
        startGame();
    }
        
    
    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<gridspace>().SetGameControllerReference(this);
        }
    }
    public string GetPlayerSide()
    {
        return playerSide;
    }
    public void EndTurn()// Hard Coded conditions
    {
        moveCount++;
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver();
        }

        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver();
        }

        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }

        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver();
        }

        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }

        else if (moveCount>=9 && winner==false)
        {
            SetBoardInteractable(false);
            SetGameOverText("Game is a draw!");
            restartButton.SetActive(true);
            SetPlayerColoursInacitve();

        }
        else
            ChangeSides();
    }
    public void GameOver()
    {
        winner = true;
        SetBoardInteractable(false);
        SetGameOverText( playerSide + " Wins!");
        restartButton.SetActive(true);
    }
    
    public void ChangeSides()//checks playerSide string 
    {
        playerSide = (playerSide == "X" ? "O" : "X");
        if(playerSide == "X") // it is X's move
        {
            SetPlayerColours(playerX, playerO);
        }
        else
        {
            SetPlayerColours(playerO, playerX);
        }
    }
    public void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }
    public void RestartGame() //all base conditons reset
    {
        //playerSide = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);
         
        restartButton.SetActive(false);
        for (int i = 0; i < buttonList.Length; i++)
            buttonList[i].text ="";
        winner = false;
        SetPlayerButton(true);
        //SetPlayerColours(playerX, playerO);
        SetPlayerColoursInacitve();
        infoPanel.SetActive(true);
    }

    public void SetPlayerColours(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activeplayerColour.panelColour;
        newPlayer.text.color = activeplayerColour.textColour;
        oldPlayer.panel.color = inactiveplayerColour.panelColour;
        oldPlayer.text.color = inactiveplayerColour.textColour;
    }
    public void SetBoardInteractable(bool cond)
    {
        for (int i = 0; i < buttonList.Length; i++)// iterate through every key
        {
            buttonList[i].GetComponentInParent<Button>().interactable = cond;
        }
    }

    public void SetPlayerButton(bool toggle) 
    {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
    }

    public void SetPlayerColoursInacitve()
    {
        playerX.panel.color = inactiveplayerColour.panelColour;
        playerX.text.color = inactiveplayerColour.textColour;
        playerO.panel.color = inactiveplayerColour.panelColour;
        playerO.text.color = inactiveplayerColour.textColour;
    }
}