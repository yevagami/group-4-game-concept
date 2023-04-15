using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barkProjectileLaunch : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform launchPoint;
    public float shootMeter;
    public float shootMeterMax;
    public float shootCounter;

    // Start is called before the first frame update
    void Start()
    {
        shootMeter = shootMeterMax;
    }

    // Update is called once per frame
    void Update()
    {
        shootMeter += Time.deltaTime;

        if(shootMeter >= shootMeterMax){
            shootMeter = shootMeterMax;
        }

        if(Input.GetKeyDown(KeyCode.I) && shootMeter - shootCounter > 0)
            {
                Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
                shootMeter -= shootCounter;
            }
    }
}
