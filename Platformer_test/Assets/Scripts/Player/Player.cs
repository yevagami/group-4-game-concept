using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //objects assigned through inspector
    [Header("Objects")]
    [SerializeField] Rigidbody2D player_rb2d;
    [SerializeField] GameObject player_ground_check;

    //player stats
    [Header("Player Stats")]
    [SerializeField] float player_speed; 

    [Header("Horizontal Movement")]
    [SerializeField] float player_horizontal_speed; 
    [SerializeField] float player_acceleration;
    [SerializeField] float player_deceleration;

    private Animator anim;



    [Header("Dashing")]
    [SerializeField] float player_dash_speed;
    [SerializeField] float player_dash_duration;
    [SerializeField] float player_dash_cooldown;
    [SerializeField] float player_dash_post_dash_multiplier;
    float player_dash_duration_timer = 0;
    float player_dash_cooldown_timer = 0;
    float dash_vertical_lock;
    float dash_horizontal_lock;
    

    [Header("Jumping")]
    [SerializeField] float player_jump_speed;
    [SerializeField] float player_tap_jump_multiplier;
    [SerializeField] float player_air_jumps;
    int player_jumps = 0;


    [Header("Hovering")]
    [SerializeField] float player_hover_duration;
    [SerializeField] float player_hover_multiplier;
    [SerializeField] float player_hover_speed;
    float player_hover_timer;
    int hoverKeyPresses = 0;

    //states
    Vector2 player_movement;
    bool isGrounded = true;
    bool isJumping = false;
    bool canDash = true;
    bool isDashing = false;
    bool isHovering = false;


    //for calculating the player's direction
    float current_horizontal_input;
    float last_horizontal_input;
    float player_dir;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        player_speed = player_horizontal_speed;
    }

    // Update is called once per frame
    void Update()
    {
        //Returns the player's direction
        player_dir = getPlayerDirection();

        //Receives the input and stores it in the player_movement vector
        player_movement.x = Input.GetAxisRaw("Horizontal");
        player_movement.y = Input.GetAxisRaw("Vertical");

        //Flips the Player's X axis
        if (player_dir == 1.0 )
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (player_dir == -1.0)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }
        else
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }


        //Set animator parameters
        anim.SetBool("Run", current_horizontal_input != 0.0);

        //Method to check if the player is grounded
        isGrounded = groundCheck();

        //Change the player's speed if they are hovering
        player_speed = (isHovering) ? player_hover_speed : player_horizontal_speed;


        #region horizontal movement

            float moveSpeed = player_movement.x * player_speed;
            float deltaSpeed = moveSpeed - player_rb2d.velocity.x; //caps the player's speed
            float force = deltaSpeed * player_rb2d.mass;
            
            //deceleration
            if(Mathf.Abs(moveSpeed) <= 0 && Mathf.Abs(player_rb2d.velocity.x) - player_deceleration > 0.01f && isGrounded ){
                player_rb2d.velocity = new Vector2 (player_rb2d.velocity.x + (-player_deceleration * Mathf.Sign(player_rb2d.velocity.x)), player_rb2d.velocity.y);
            }
            player_rb2d.AddForce(Vector2.right * force);

        #endregion


        #region jumping

            //Player can only jump when the space key is pressed and they are grounded
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                if(isGrounded){
                    isJumping = true;
                    player_jumps = 0; //Reset the air jump counter when the player hits the ground
                    player_rb2d.AddForce(Vector2.up * player_jump_speed, ForceMode2D.Impulse);
                }

                //Starts an air jump if the player is not grouned and not in the middle of a jump
                if(!isGrounded && !isJumping && player_jumps < player_air_jumps){
                    player_jumps += 1;
                    player_rb2d.AddForce(Vector2.up * player_jump_speed, ForceMode2D.Impulse);
                }
            }
            
            //Lowers the vertical velocity if the jump button was released while the player is still jumping
            //If the player is in the middle of jumping and the spacebar was released
            //The vertical velocity is multiplied by a the 'player_tap_jump_multiplier'
            if((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W)) && isJumping ){
                isJumping = false;
                player_rb2d.velocity = new Vector2(player_rb2d.velocity.x, player_rb2d.velocity.y * player_tap_jump_multiplier);
            }

        #endregion


        #region dashing

            //Dash by pressing K
            if(Input.GetKeyDown(KeyCode.K) && canDash){
                dash_vertical_lock = gameObject.transform.position.y;
                dash_horizontal_lock = player_dir;
                isDashing = true;
                canDash = false;
                isHovering = false;
            }

            if(isDashing){
                player_rb2d.velocity = new Vector2(player_dash_speed * dash_horizontal_lock, 0);

                //Locks the player's vertical position while dashing
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, dash_vertical_lock, gameObject.transform.position.z);

                player_dash_duration_timer += Time.deltaTime;

                if(player_dash_duration_timer >= player_dash_duration){
                    //Reset the player's velocity at the end of the dash
                    player_rb2d.velocity = new Vector2((player_rb2d.velocity.x * player_dash_post_dash_multiplier), player_rb2d.velocity.y);

                    player_dash_duration_timer = 0;
                    isDashing = false;
                }
            }


            //Originially the dash has an internal cooldown, but can be reset if the player touches the ground
            if(!canDash && !isDashing){
                player_dash_cooldown_timer += Time.deltaTime;
                if(player_dash_cooldown_timer >= player_dash_cooldown || isGrounded){
                    canDash = true;
                    player_dash_cooldown_timer = 0;
                }
            }
            
        #endregion


        #region hovering

        if(Input.GetKeyDown(KeyCode.J) && hoverKeyPresses <= 2){
            isHovering = !isHovering;
            isDashing = false;
            hoverKeyPresses += 1;
        }

        if(isHovering){
            if(player_rb2d.velocity.y <= 0.01){
                player_hover_timer += Time.deltaTime; //Timer only goes up when the player is in the hovering state
                player_rb2d.velocity = new Vector2(player_rb2d.velocity.x, player_rb2d.velocity.y + (player_rb2d.velocity.y * -player_hover_multiplier));
            }

            if(player_hover_timer >= player_hover_duration){;
                isHovering = false;
            }
        }
        
        if(!isHovering && isGrounded){
            player_hover_timer = 0;
            hoverKeyPresses = 0;
        }

        #endregion

        //Debug logs for testing
        //Debug.Log(getPlayerDirection());
    }

    //Check if the player is on the ground
    bool groundCheck(){
        //create a overlap circle and check if it is overlapping with the floor
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

    //Float to get the player's direction based on the last input
    public float getPlayerDirection(){
        /*
        - 1 means right
        - -1 means left
        */

        current_horizontal_input = Input.GetAxisRaw("Horizontal");

        if(current_horizontal_input != 0){
            last_horizontal_input = current_horizontal_input;
        }
        
        if(last_horizontal_input != 0){
            return last_horizontal_input;
        }
        else{
            return 1;
        }

    }
}
