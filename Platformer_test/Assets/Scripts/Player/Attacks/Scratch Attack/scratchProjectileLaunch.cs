using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scratchProjectileLaunch : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform launchPoint;

    [Header("Parameters")]
    public float shootTime;
    public float shootCounter;


    // Start is called before the first frame update
    void Start()
    {
        shootCounter = shootTime;
        float player_dir = gameObject.GetComponent<Player>().getPlayerDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U) && shootCounter <= 0){
                Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
                shootCounter = shootTime;
            }
        shootCounter -= Time.deltaTime;
    }
}
