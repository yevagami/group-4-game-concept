using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformDropping : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] GameObject platform;
    [SerializeField] Collider2D platform_trigger;

    [Header("Properties")]
    [SerializeField] float duration;
    [SerializeField] float drop_speed;
    [SerializeField] float drop_time;
    [SerializeField] float cooldown;

    float timer_cooldown;
    float timer_duration;
    float timer_drop_time;
    Rigidbody2D platform_rb2d;


    bool isActive;
    bool isDropping;
    bool isCooldown;


    // Start is called before the first frame update
    void Start()
    {
        platform_rb2d = platform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Run when the platform is sitting in idle 
        if(isActive){
            timer_duration += Time.deltaTime;
            if(timer_duration >= duration){
                isActive = false;
                isDropping = true;

                timer_duration = 0;
            }
        }
        

        //Run when the platform is dropping
        if(isDropping){
            timer_drop_time += Time.deltaTime;
            platform_rb2d.velocity = new Vector2(0, -drop_speed);

            if(timer_drop_time >= drop_time){
                isDropping = false;
                isCooldown = true;

                timer_drop_time = 0;
                platform.SetActive(false);
            }
        }


        //Run when platform is on cooldown
        if(isCooldown){
            timer_cooldown += Time.deltaTime;
            if(timer_cooldown >= cooldown){
                isActive = false;
                isCooldown = false;
                timer_cooldown = 0;

                platform.SetActive(true);
                platform.transform.position = gameObject.transform.position;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            isActive = true;
        }
    }
}
