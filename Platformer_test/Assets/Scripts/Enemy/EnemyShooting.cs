using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] EnemyStates enemy;
    [SerializeField] float cooldown;

    private float timer;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > cooldown){
            timer = 0;
            shoot(new Vector2(
                player.position.x - gameObject.transform.position.x, 
                player.position.y - gameObject.transform.position.y
            ).normalized);
        }
    }

    void shoot(Vector2 targetDir){
        Instantiate(projectile, new Vector3(
            gameObject.transform.position.x + 1.5f * (Mathf.Sign(targetDir.x)),
            gameObject.transform.position.y,
            gameObject.transform.position.z
        ), Quaternion.identity);
    }
}
