using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    GameObject AstroWalk;
    public GameObject Enemy;
    public Animator bossAnimator;
    public bool bossRight = false;
    public bool bossLeft = false;
    public float Speed = 2f;
    public int health = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bossMove();
    }

    private void bossMove()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "collision")
        {
            bossAnimator.SetBool("enemyLeft", false);
            bossAnimator.SetBool("enemyRight", true);
            bossLeft = false;
            bossRight = true;
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }

        if (collision.gameObject.name == "orb(Clone)")
        {
            if(health > 0)
            {
                health -= 1;
            }
            if (health == 0)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
