using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scratchAttack : MonoBehaviour
{
    [SerializeField] Player player_;
    [SerializeField] float attackRadius;
    [SerializeField] float originOffest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U)){
            Collider2D[] overlappedColliders = Physics2D.OverlapCircleAll(new Vector2(gameObject.transform.position.x + (originOffest * player_.player_dir), gameObject.transform.position.y),attackRadius);
            foreach (Collider2D objects in overlappedColliders){
                if(objects.gameObject.tag == "enemy"){
                    objects.GetComponent<EnemyHealth>().TakeDamage(10);
                }
            }

        }
    }
}
