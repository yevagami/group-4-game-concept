using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scratchProjectile : MonoBehaviour
{
    public Rigidbody2D projectileRb;
    public float speed;

    public float projectileLife;
    public float projectileCount;
    public int damage = 10;



    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife;
    }

    // Update is called once per frame
    void Update()
    {
      projectileCount -= Time.deltaTime;
        if(projectileCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        projectileRb.velocity = new Vector2(speed, projectileRb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weak Point")
        {
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        else if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("yo");
        }
        else
        {
            Destroy(gameObject);
        }
           
    }

}



