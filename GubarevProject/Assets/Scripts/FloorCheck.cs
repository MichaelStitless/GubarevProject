using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCheck : MonoBehaviour
{
    GameObject player;    
    void Start()
    {
        player = gameObject.transform.parent.gameObject;
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Ground") {
            player.GetComponent<PlayerControls>().isFloor = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.collider.tag == "Ground") {
            player.GetComponent<PlayerControls>().isFloor = false;
        }
    }
}
