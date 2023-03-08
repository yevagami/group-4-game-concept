using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //assigned through inspector
    [SerializeField] private Rigidbody2D player_rb2d;
    [SerializeField] private GameObject player_camera;
    public GameObject ground_check;

    //player stats
    [SerializeField] private float player_maxSpeed; 
    [SerializeField] private float player_acceleration;
    [SerializeField] private float player_deceleration;

    [SerializeField] private float player_dash_speed;
    [SerializeField] private float player_jumpingSpeed;

    //states
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

        player_camera.transform.position = new Vector3(gameObject.transform.position.x, player_camera.transform.position.y,-10);

    }

    private void FixedUpdate() {
        #region movement

        float moveSpeed = player_movement.x * player_maxSpeed;
        float deltaSpeed = moveSpeed - player_rb2d.velocity.x;
        float force = deltaSpeed * player_rb2d.mass;
        
        //friction
        if(Mathf.Abs(moveSpeed) <= 0 && Mathf.Abs(player_rb2d.velocity.x) - player_deceleration > 0.01f ){
            player_rb2d.velocity = new Vector2 (player_rb2d.velocity.x - (player_deceleration * Mathf.Sign(player_rb2d.velocity.x)), player_rb2d.velocity.y);
        }

        player_rb2d.AddForce(Vector2.right * force);

        Debug.Log("Velocity: " + player_rb2d.velocity.x + ", Movespeed: " + moveSpeed);

        #endregion
    } 
}
