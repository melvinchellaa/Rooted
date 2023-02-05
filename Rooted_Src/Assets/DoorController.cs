using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
     private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "player" && Input.GetKey(KeyCode.Q)){
            SceneManager.LoadScene("Room2"); 
    
        }
        
    }

}
