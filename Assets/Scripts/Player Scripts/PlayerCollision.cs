using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{   
    private Rigidbody rigidbody;
    private PlayerMovement playerMovement;
    private GameManage GameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = transform.GetComponent<PlayerMovement>();
        rigidbody = transform.GetComponent<Rigidbody>();
        GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Obstacle")
        {
            playerMovement.canMove = false;
            rigidbody.AddForce(new Vector3(-1000,-10000,-100));
            GameManager.gameOver();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FinishLine"){
            playerMovement.canMove = false;
            GameManager.gameWin();
        }
    }
    
}
