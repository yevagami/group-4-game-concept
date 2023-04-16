using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] EnemyStates enemy;
    [SerializeField] float cooldown;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > cooldown){
            timer = 0;
            shoot();
        }
    }

    void shoot(){
        Instantiate(projectile, new Vector3(
            gameObject.transform.position.x + 1 * (enemy.enemy_Dir),
            gameObject.transform.position.y,
            gameObject.transform.position.z
        ), Quaternion.identity);
    }
}
