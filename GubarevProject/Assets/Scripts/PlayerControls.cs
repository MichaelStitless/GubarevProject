using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float movementSpeed = 3f;
    public float shiftY = 0f; //shifting player on Y-axis
    public float shiftZ = 0f; //shifting player on Z-axis
    public float jumpY = 3f; //player jumping distance
    public bool isFloor = false;
    
    void FixedUpdate()
    {
        //controls just work faster and don't lag 
        if (Input.GetButtonDown("Jump") && isFloor == true) 
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpY), ForceMode2D.Impulse);
        } 

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), shiftY, shiftZ);
        transform.position += movement * Time.deltaTime * movementSpeed;
    }
}