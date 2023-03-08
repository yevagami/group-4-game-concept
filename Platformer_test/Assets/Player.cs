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
        float acceleration = (Mathf.Abs(moveSpeed) > 0.01f) ? player_acceleration : player_deceleration;
        float movement = Mathf.Pow(Mathf.Abs(deltaSpeed) * acceleration, 0.8f) * Mathf.Sign(moveSpeed);

        player_rb2d.AddForce(Vector2.right * movement);
        
        Debug.Log(player_rb2d.velocity.x);

        #endregion
    }
}
