using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    public bool OnTriggerEnter2D(Collider2D collision){
        bool hasStick = false; 
        if(collision.tag == "player" && Input.GetKey(KeyCode.E)){
            Destroy(gameObject); 
            hasStick = true;
        }
            
        return hasStick;
    }
        
}
