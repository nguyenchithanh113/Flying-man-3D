using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{   private float executeTime = 1;
    private bool gameIsOver = false;
    private GameObject gameWinUI;
    private GameObject gameOverUI;
    private void Start()
    {
        Transform[] objects = GameObject.FindWithTag("CanvasUI").GetComponentsInChildren<Transform>(true);
        //Find inactive gameObject
        foreach(Transform obj in objects){
            if(obj.name == "Game Over"){
                gameOverUI = obj.gameObject;
            }
            if(obj.name == "Game Win"){
                gameWinUI = obj.gameObject;
            }
        }

    }
    // Start is called before the first frame update
    public void gameOver(){
        if(gameIsOver==false){
            gameIsOver = true;
            Invoke("gameOverMenu",executeTime);
        }
    }
    public void gameWin(){
        if(gameIsOver==false){
            gameIsOver = true;
            Invoke("gameWinMenu",executeTime);
        }        
    }
    public void gameOverMenu(){
        gameOverUI.SetActive(true);
    }
    public void gameWinMenu(){
        gameWinUI.SetActive(true);
    }
    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void loadNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
