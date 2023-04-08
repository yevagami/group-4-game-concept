using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barkProjectileLaunch : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;

    public float shootTime;
    public float shootCounter;

    float player_direction;

    // Start is called before the first frame update
    void Start()
    {
        shootCounter = shootTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        player_direction = gameObject.GetComponent<Player>().getPlayerDirection();

        if(Input.GetKeyDown(KeyCode.I) && shootCounter <= 0)
            {
                Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
                shootCounter = shootTime;
            }
        shootCounter -= Time.deltaTime;
    }
}