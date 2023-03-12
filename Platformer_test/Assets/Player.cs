using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //objects assigned through inspector
    [SerializeField] private Rigidbody2D player_rb2d;
    [SerializeField] private GameObject player_camera;
    [SerializeField] private GameObject player_ground_check;

    //player stats
    [SerializeField] private float player_maxSpeed; 
    [SerializeField] private float player_acceleration;
    [SerializeField] private float player_deceleration;
    [SerializeField] private float player_dash_speed;
    [SerializeField] private float player_jump_speed;

    //states
    private Vector2 player_movement;
    bool isJumping = false;
    bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Receives the input and stores it in the player_movement vector
        player_movement.x = Input.GetAxisRaw("Horizontal");
        player_movement.y = Input.GetAxisRaw("Vertical");

        //Moves the camera with the player
        player_camera.transform.position = new Vector3(gameObject.transform.position.x, player_camera.transform.position.y,-10);

        //Method to check if the player is grounded
        isGrounded = groundCheck();

        #region jumping
            //Player can only jump when the space key is pressed and they are grounded
            if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                isJumping = true;
                player_rb2d.AddForce(Vector2.up * player_jump_speed, ForceMode2D.Impulse);
            }
            
            //Lowers the vertical velocity if the jump button was released while the player is still jumping
            if(Input.GetKeyUp(KeyCode.Space) && isJumping){
                isJumping = false;
                player_rb2d.velocity = new Vector2(player_rb2d.velocity.x, player_rb2d.velocity.y * 0.5f);
            }
        #endregion

        //Debug logs for testing
        Debug.Log(isGrounded);
    }

    private void FixedUpdate() {
        #region horizontal movement

        float moveSpeed = player_movement.x * player_maxSpeed;
        float deltaSpeed = moveSpeed - player_rb2d.velocity.x; //caps the player's speed
        float force = deltaSpeed * player_rb2d.mass;
        
        //deceleration
        if(Mathf.Abs(moveSpeed) <= 0 && Mathf.Abs(player_rb2d.velocity.x) - player_deceleration > 0.01f && isGrounded ){
            player_rb2d.velocity = new Vector2 (player_rb2d.velocity.x - (player_deceleration * Mathf.Sign(player_rb2d.velocity.x)), player_rb2d.velocity.y);
        }

        player_rb2d.AddForce(Vector2.right * force);

        #endregion
    } 

    bool groundCheck(){
        //creates a overlap circle and check if it is overlapping with the floor
        float ground_check_radius = 0.14f;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player_ground_check.transform.position, ground_check_radius);
        
        foreach (Collider2D item in colliders)
        {
            if(item.gameObject.tag == "floor"){
                return true;
            }
        }
        return false;
    }
}
