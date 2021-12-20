using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_UI : MonoBehaviour
{

    public void StartGame()
    {
        //loads main scene
        SceneManager.LoadScene("MainGame");
        //  _GM.ChangeGameState(GameState.Playing);
    }

   
    public void QuitGame()
    {
        //exits game
        Application.Quit();
    }
    public void LoadEndScene()
    {
        SceneManager.LoadScene("EndScreen");
    }

}
