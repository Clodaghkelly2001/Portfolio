using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemy : MonoBehaviour
{

    GameObject AstroWalk;
    public GameObject Enemy;
    public Animator EnemyAnimator;
    public bool enemyRight = false;
    public bool enemyLeft = false;
    public float Speed = 2f;
  
    void Start()
    {
        Speed = 0.5f;
    }


    void Update()
    {
        enemyMove();
    }

    private void enemyMove()
    {
        EnemyAnimator = GetComponent<Animator>();
        EnemyAnimator.SetBool("enemyLeft", true);
        EnemyAnimator.SetBool("enemyRight", false);
        enemyLeft = true;
        enemyRight = false;
        transform.Translate(Vector3.left * Speed * Time.deltaTime);

    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "collision")
        {
            EnemyAnimator.SetBool("enemyLeft", false);
            EnemyAnimator.SetBool("enemyRight", true);
            enemyLeft = false;
            enemyRight = true;
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }

        if (collision.gameObject.name == "orb(Clone)")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
