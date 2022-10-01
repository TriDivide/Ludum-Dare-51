using UnityEngine;

public class PlayerMovement : MonoBehaviour {

     private Rigidbody2D body;
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private float jumpSpeed = 10.0f;

    private float horizontalInput;

    private bool isGrounded;

    [HideInInspector] public bool isFacingRight = true;



    private void Awake() {
        body = GetComponent<Rigidbody2D>();


    }

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);    

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded) {
            Jump();
        }

        if (horizontalInput > 0f) {
            isFacingRight = true;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (horizontalInput < 0f) {
            isFacingRight = false;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void Jump() {
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        isGrounded = false;
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }


    public bool CanAttack() {
        return horizontalInput == 0 && isGrounded;
    }
}
