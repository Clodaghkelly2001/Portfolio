using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class PlayerMovement : MonoBehaviour
{
    private Scene scene;
    public Rigidbody2D PortalOff;
    public Rigidbody2D EndPortal;
    public Rigidbody2D enemy;
    public Rigidbody2D boss;
    public GameObject orbPrefab;
    public bool right = false;
    public bool left = false;
    public bool up = false;
    public bool down = false;


    public float orbSpeed = 20.0f;
    public Transform orbLocation;


    // Move player in 2D space
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    public Camera mainCamera;

    bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    Vector3 cameraPos;
    Rigidbody2D r2d;
    Collider2D mainCollider;
    // Check every collider except Player and Ignore Raycast
    LayerMask layerMask = ~(1 << 2 | 1 << 8);
    Transform t;

    public int LivesLeft = 5;


    // Use this for initialization
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<Collider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;
        gameObject.layer = 8;

        if(mainCamera)
            cameraPos = mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D orbInstance;
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject orb = Instantiate(orbPrefab, orbLocation.position, orbLocation.rotation);
            Rigidbody2D rb = orb.GetComponent<Rigidbody2D>();
            rb.AddForce(orbLocation.up * orbSpeed, ForceMode2D.Impulse);
        }

        // Movement controls
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && (isGrounded || r2d.velocity.x > 0.01f))
        {
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
        }
        else
        {
            if (isGrounded || r2d.velocity.magnitude < 0.01f)
            {
                moveDirection = 0;
            }   
        }

        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
        }

        // Camera follow
        if(mainCamera)
            mainCamera.transform.position = new Vector3(t.position.x, cameraPos.y, cameraPos.z);
    }

    void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, 0.1f, 0);
        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheckPos, 0.23f, layerMask);

        // Apply movement velocity
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);

        // Simple debug
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, 0.23f, 0), isGrounded ? Color.green : Color.red);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Destroy" || (collision.gameObject.name == "Enemy") || (collision.gameObject.name == "right") ||
             (collision.gameObject.name == "left") || (collision.gameObject.name == "bottom") ||
            (collision.gameObject.name == "top"))//bullet or bullet clones collide with enemys)
        {
            if (LivesLeft > 0)
            {
                LivesLeft -= 1;
                Time.timeScale = 0;
                Destroy(gameObject);
                SceneManager.LoadScene(scene.name);
            }

            if (LivesLeft == 0)
            {
                Time.timeScale = 0;
                Destroy(gameObject);
                SceneManager.LoadScene("GAMEOVER");
            }
        }

        if (collision.gameObject.name == "Boss")
        {
            if (LivesLeft > 0)
            {
                LivesLeft -= 1;
                Time.timeScale = 1f;
                Destroy(gameObject);
                SceneManager.LoadScene(scene.name);
            }

            if (LivesLeft == 0)
            {
                Time.timeScale = 0;
                Destroy(gameObject);
                SceneManager.LoadScene("GAMEOVER");
            }
        }

            if (collision.gameObject.name == "PortalOff")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (collision.gameObject.name == "EndPortal")
        {
            SceneManager.LoadScene("GAMECOMPLETE");
        }
    }

    public void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 100, 50), " Time: " + Time.time + "\nLives: " + LivesLeft);
    }
}