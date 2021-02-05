using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PompoController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject pompoBody;
    private float jumpHold;
    public float jumpLimit;
    public float speed;
    public float jumpSpeed;
    private bool grounded;

    public float jumpCharge;
    
        void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other){
        grounded = true;
    }
    void OnTriggerExit(Collider other){
        grounded = false;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow)){
            if (pompoBody.transform.rotation.y == 0){
                pompoBody.transform.Rotate(0,180,0);
            } else transform.Translate(speed*Time.deltaTime,0,0);
        }
        else if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow)){          
            if (pompoBody.transform.rotation.y == 180){
                pompoBody.transform.Rotate(0,180,0);
            } else transform.Translate(-speed*Time.deltaTime,0,0);
        }
        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.W)){
            jumpHold=(jumpHold+jumpCharge);
            Debug.Log(jumpHold);
        }
        if (Input.GetKeyUp(KeyCode.W)||Input.GetKeyUp(KeyCode.Space)||Input.GetKeyUp(KeyCode.W)){
            if (grounded){
                if (jumpHold>jumpLimit){
                    jumpHold=jumpLimit;
                    rb.AddForce(0,jumpHold*jumpSpeed,0, ForceMode.Impulse);
                } else rb.AddForce(0,jumpHold*jumpSpeed,0, ForceMode.Impulse);
                Debug.Log("jump!" + jumpHold);
            }
            jumpHold = 0; 
        }
    }
}
