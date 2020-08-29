using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadNextButton : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManage gameManage;
    private Button loadNext;
    void Start()
    {
        gameManage = GameObject.FindWithTag("GameManager").GetComponent<GameManage>();
        loadNext = transform.GetComponent<Button>();
        loadNext.onClick.AddListener(gameManage.loadNextLevel);
    }

}
