using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManage gameManager;
    private Button restartButton;
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManage>();
        restartButton = transform.GetComponent<Button>();
        restartButton.onClick.AddListener(taskOnClick);
    }
    void taskOnClick(){
        gameManager.restartGame();
    }
}
