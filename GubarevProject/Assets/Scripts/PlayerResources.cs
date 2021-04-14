using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public int coinsCounter = 0;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Coin")) 
        {
            coinsCounter+=1;
            Destroy(other.gameObject);
        }
    }    
}