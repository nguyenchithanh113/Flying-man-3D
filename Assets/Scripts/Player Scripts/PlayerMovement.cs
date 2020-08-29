using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove = true;
    [SerializeField]
    private float moveSpeed = 30f;
    [SerializeField]
    private float sidewaySpeed = 10f;
    [SerializeField]
    private float smoothMovement =50f;
    private Vector3 axis;
    private  new Rigidbody rigidbody;
    private Joystick joystick;
    private float xAxis = 180f ;
    private float yaxis = 0f;
    private Vector3 rotateCheck;

    private Quaternion initialCord;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
        joystick = GameObject.FindGameObjectWithTag("JoyStick").GetComponent<FixedJoystick>();
        initialCord = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        if(canMove){
            moveForward();
        }
        playerRotatation();
    }
    public void FixedUpdate() {
    
    }

    void move(){
        axis = new Vector3(joystick.Horizontal,joystick.Vertical,0);
        axis.Normalize();
        transform.position+= axis*sidewaySpeed*Time.deltaTime;
        rigidbody.MovePosition(transform.position);
        
    }
    void moveForward(){
        rigidbody.velocity = new Vector3(0,0,moveSpeed);
    }
    void playerRotatation(){
        xAxis += joystick.Horizontal;
        yaxis += joystick.Vertical;
        rotateCheck = new Vector3(joystick.Horizontal,joystick.Vertical,0);
        yaxis = Mathf.Clamp(yaxis,-10,10);
        xAxis = Mathf.Clamp(xAxis,150f,210f);
        transform.localRotation = Quaternion.Euler(yaxis,180,xAxis);
        
        if(rotateCheck==Vector3.zero){
            if(xAxis>180f){
                xAxis-=smoothMovement*Time.deltaTime;
                xAxis = Mathf.Clamp(xAxis,180,210);
            }else if(xAxis<180){
                xAxis+=smoothMovement*Time.deltaTime;
                xAxis = Mathf.Clamp(xAxis,150,180);
            }
            if(yaxis>0){
                yaxis-=smoothMovement*Time.deltaTime;
                yaxis = Mathf.Clamp(yaxis,0,10);
            }else if(yaxis<0){
                yaxis+=smoothMovement*Time.deltaTime;
                yaxis = Mathf.Clamp(yaxis,-10,0);
            }

            transform.rotation = Quaternion.Euler(yaxis,180,xAxis);
        }

    }
}
