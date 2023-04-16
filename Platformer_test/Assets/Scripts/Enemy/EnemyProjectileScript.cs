using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float power;
    [SerializeField] float speed;
    [SerializeField] float projectileLife;
    Transform player;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 direction = player.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, gameObject.transform.localRotation.z + 0.5f);

        timer += Time.deltaTime;

        if(timer >= projectileLife){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.tag){
            case "Player":
                other.GetComponent<PlayerHealth>().TakeDamage(power);
                break;
            
            case "enemy":
                other.GetComponent<EnemyHealth>().TakeDamage(power);
                break;
        }

        Destroy(gameObject);
    }
}
