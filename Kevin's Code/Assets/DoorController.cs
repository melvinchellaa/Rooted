using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class DoorController : MonoBehaviour
{
    public int indexDoorUp;
    public int indexDoorDown;
    public bool isTop;
    public bool isBottom;

    private bool nearDoor;

    // Start is called before the first frame update
    void Update()
    {
        if(!isTop && nearDoor && Input.GetKey(KeyCode.W))
        {
            SceneManager.LoadScene(indexDoorUp); 
        }

        if(!isBottom && nearDoor && Input.GetKey(KeyCode.S))
        {
            SceneManager.LoadScene(indexDoorDown); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            nearDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            nearDoor = false;
        }
    }
}
