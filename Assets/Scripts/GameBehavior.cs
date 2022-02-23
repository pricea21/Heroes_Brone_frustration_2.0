using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//1
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    //1
    public string labelText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;

    public bool showWinScreen = false;
    public bool showLossScreen = false;

    private int _itemsCollected = 0;
    public int Items
    {
        //2
        get { return _itemsCollected; }
        //3
        set
        {
            _itemsCollected = value;
            //2
            if(_itemsCollected >= maxItems)
            {
                labelText = "You've found all the items!";
                //2
                showWinScreen = true;

                //2
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Item found, only" + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }
    private int _playerHP = 10;
    //4
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);
            if(_playerHP <= 0)
            {
                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0;
            }
            else
            {
                labelText = "Ouch... that's gpt tp hurt.";
            }
        }
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
    //3
    void OnGUI()
    {
        //4
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" + _playerHP);
        //5
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " + _itemsCollected);
        //6
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);
        //3
        if (showWinScreen)
        {
            //4
            if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 - 50, 200, 100), "YOU WON!"))
            {
                //3
                SceneManager.LoadScene(0);

                //4
                Time.timeScale = 1.0f;
                RestartLevel();
            }
        }
        if(showLossScreen)
        {
            if (GUI.Button(new Rect(Screen.width /2 -100, Screen.height /2 - 50, 200, 100), "You lose..."))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
                RestartLevel();
            }
        }
    }
}
