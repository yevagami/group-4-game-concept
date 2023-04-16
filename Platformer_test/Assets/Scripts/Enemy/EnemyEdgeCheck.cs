using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEdgeCheck : MonoBehaviour
{
    [SerializeField] Collider2D edgeCollider;
    [SerializeField] EnemyStates enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        if(enemy.currentState != "chase"){
            switch (other.tag)
            {
                case "floor":
                    enemy.isGrounded = true;
                    break;

                case "wall":
                    enemy.isTouchingWall = true;
                    break;
                
                case "enemy":
                    enemy.flip();
                    break;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(enemy.currentState != "chase"){
             switch (other.tag)
            {
                case "floor":
                    enemy.isGrounded = false;
                    break;

                case "wall":
                    enemy.isTouchingWall = false;
                    break;
            }
        }
    }
}
