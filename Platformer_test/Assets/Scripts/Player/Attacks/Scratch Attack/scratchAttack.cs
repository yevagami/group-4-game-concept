using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scratchAttack : MonoBehaviour
{
    [SerializeField] Player player_;
    [SerializeField] float attackRadius;
    [SerializeField] float originOffest;
    [SerializeField] GameObject scratchSprite;
    float timer = 0;
    bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U)){
            isAttacking = true;
            Collider2D[] overlappedColliders = Physics2D.OverlapCircleAll(new Vector2(gameObject.transform.position.x + (originOffest * player_.player_dir), gameObject.transform.position.y),attackRadius);
            foreach (Collider2D objects in overlappedColliders){
                if(objects.gameObject.tag == "enemy"){
                    objects.GetComponent<EnemyHealth>().TakeDamage(10);
                }
            }
        }

        if(isAttacking){
            timer += Time.deltaTime;

            scratchSprite.transform.position = new Vector2(
                gameObject.transform.position.x + 1.4f * player_.player_dir,
                gameObject.transform.position.y
            );

            scratchSprite.transform.localScale = new Vector2(
                0.85f * player_.player_dir,                    
                0.85f
            );

            scratchSprite.SetActive(true);

            if(timer >= 0.3){
                timer = 0;
                isAttacking = false;
                scratchSprite.SetActive(false);
            }
        }
    }
}
