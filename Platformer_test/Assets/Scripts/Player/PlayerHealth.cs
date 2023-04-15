using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth = 100.0f;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }


    public void TakeDamage(float amount)

    {
        health -= amount;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
