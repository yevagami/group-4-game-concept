using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //assigned through inspector
    [SerializeField] private Rigidbody2D player_rb2d;
    public GameObject ground_check;

    //player stats
    [SerializeField] private float player_maxSpeed; 
    [SerializeField] private float player_speed;
    [SerializeField] private float player_dash_speed;
    [SerializeField] private float player_jumpingSpeed;

    //states
    private Vector2 player_dir;
    private Vector2 player_movement;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        player_movement.x = Input.GetAxisRaw("Horizontal");
        player_movement.y = Input.GetAxisRaw("Vertical");
        player_dir = getPlayerDir();
        Debug.Log(player_dir.x);
        //Logs();
    }

    private void FixedUpdate() {
        
        //player movement
        player_rb2d.AddForce(new Vector2(player_movement.x * player_speed, player_movement.y));

        //Maxes out the player's speed
        /*
        if(player_rb2d.velocity.x * player_movement.x > player_maxSpeed){
            player_rb2d.velocity = new Vector2(player_maxSpeed * player_movement.x, player_rb2d.velocity.y);
        }
        */

        //player jumping
        if(Input.GetKey(KeyCode.Space) && groundCheck()){
            Debug.Log("JUMPING!");
            player_rb2d.AddForce(new Vector2(0, player_jumpingSpeed));
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            player_rb2d.velocity = new Vector2((player_rb2d.velocity.x + player_dash_speed) * player_dir.x, player_rb2d.velocity.y);
        }
    }

    bool groundCheck(){
        
        if(Physics2D.BoxCast(ground_check.transform.position, new Vector2(0.3f, 0.3f), 0, Vector2.down, 0.1f)){
            //Debug.Log("CAN JUMP");
            return true;
        };
        return false;
    }

    Vector2 getPlayerDir(){
        Vector2 playerDir = new Vector2();
        if(player_movement.x != 0){
            playerDir.x = player_movement.x;
        }
        playerDir.y = player_movement.y;

        return playerDir;
    }

    /*
    void Logs(){
        Debug.Log(player_rb2d.velocity);
    }
    */
}
