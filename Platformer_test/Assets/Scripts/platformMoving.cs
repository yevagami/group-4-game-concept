using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMoving : MonoBehaviour
{
    //moving platform attributes
    [Header("Components")]
    [SerializeField] GameObject pointA;
    [SerializeField] GameObject pointB;
    [SerializeField] GameObject platform;
    Rigidbody2D platform_rb2d;


    [Header("Properties")]
    [SerializeField] float speed;
    [SerializeField] float cooldown;
    float cooldown_timer;
    bool isActive = true;
    Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        platform_rb2d = platform.GetComponent<Rigidbody2D>();
        destination = pointB.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if(isActive){
            Vector3 destination_direction = Vector3.Normalize(destination - platform.transform.position);
            platform_rb2d.velocity = destination_direction * speed;

            if(Mathf.Abs(destination.y - platform.transform.position.y) <= 0.01f && Mathf.Abs(destination.x - platform.transform.position.x) <= 0.01f){
                isActive = false;
                platform_rb2d.velocity = Vector3.zero;
            }
        }

        else{
            cooldown_timer += Time.deltaTime;
            if(cooldown_timer >= cooldown){
                isActive = true;
                cooldown_timer = 0;
                destination = getDestination();
            }
        }
        
    }

    Vector3 getDestination(){
        if(destination == pointA.transform.position){
            return pointB.transform.position;
        }
        else{
            return pointA.transform.position;
        }
    }
}
