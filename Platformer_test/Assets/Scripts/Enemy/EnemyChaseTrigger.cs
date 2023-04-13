using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseTrigger : MonoBehaviour
{
    [SerializeField] EnemyStates enemy_script;
    [SerializeField] float chase_duration;
    float timer_chase = 0;
    bool start_timer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(start_timer){
            timer_chase += Time.deltaTime;
            if(timer_chase >= chase_duration){
                start_timer = false;
                enemy_script.switchState("idle");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            timer_chase = 0;
            start_timer = false;
            enemy_script.switchState("chase");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            start_timer = true;
        }
    }
}
