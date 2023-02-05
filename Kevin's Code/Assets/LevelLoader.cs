using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public GameObject player;
    
    void Start()
    {
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > 9.5)
        {
            LoadNextLevel();
        }

        if (player.transform.position.x < -9.5)
        {
            LoadPreviousLevel();
        }
    }

    public void LoadPreviousLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        

        yield return new WaitForSeconds(transitionTime/5);
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(transitionTime*4/5);

        SceneManager.LoadScene(levelIndex);
    }
}