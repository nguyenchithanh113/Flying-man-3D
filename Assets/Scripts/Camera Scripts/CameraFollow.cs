using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float defaultX = 25f;
    private Transform playerTransform;
    private Vector3 target;
    private void Awake() {
        
    }
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }
    void followPlayer(){
        target = new Vector3(playerTransform.position.x,playerTransform.position.y,playerTransform.position.z);
        transform.position = target;
    }
}
