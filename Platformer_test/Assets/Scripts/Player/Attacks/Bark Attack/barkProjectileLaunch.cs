using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barkProjectileLaunch : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Player player_;
    [SerializeField] float originOffest;


    [Header("Projectile Parameters")]
    [SerializeField] float projectileSpeed;
    [SerializeField] float projectileLife;
    [SerializeField] float ProjectileDamage;

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

        if(Input.GetKeyDown(KeyCode.I) && shootMeter - shootCounter > 0 && player_.hasBark)
            {
                GameObject projectile = Instantiate(projectilePrefab, new Vector3(
                    gameObject.transform.position.x + (originOffest * player_.player_dir),
                    gameObject.transform.position.y,
                    gameObject.transform.position.z
                    ), Quaternion.identity);

                projectile.gameObject.GetComponent<barkProjectile>().setProjectileParameters(projectileSpeed * player_.player_dir, projectileLife, ProjectileDamage);
                shootMeter -= shootCounter;
            }
    }
}
