using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideSceneSwitcher : MonoBehaviour
{
    public string scene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //you should use this one 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            //this one is just for loop to main menu
            Debug.Log("Collided - Switching Scene");
            SceneManager.LoadScene(scene);
        }
    }
}
