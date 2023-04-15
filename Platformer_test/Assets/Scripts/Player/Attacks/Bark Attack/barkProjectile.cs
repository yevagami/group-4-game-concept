using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barkProjectile : MonoBehaviour
{
    [SerializeField] Rigidbody2D projectileRb;
    float speed;
    float projectileLife;
    float projectileCount = 0;
    float damage = 10;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      projectileCount += Time.deltaTime;
        if(projectileCount >= projectileLife)
        {
            Destroy(gameObject);
        }
    }


    private void FixedUpdate(){
        projectileRb.velocity = new Vector2(speed, projectileRb.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy"){
            Debug.Log("HIT");
            Destroy(gameObject);
        }
    }


    public void setProjectileParameters(float speed_, float projectileLife_, float damage_){
        speed = speed_;
        projectileLife = projectileLife_;
        damage = damage_;
    }

}



