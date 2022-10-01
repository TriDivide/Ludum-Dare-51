using UnityEngine;

public class PlayerMovement : MonoBehaviour {

     private Rigidbody2D body;
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private float jumpSpeed = 10.0f;

    private float horizontalInput;

    private bool isGrounded;
    private void Awake() {
        body = GetComponent<Rigidbody2D>();


    }

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);    

        if (Input.GetKey(KeyCode.Space) && isGrounded) {
            Jump();
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
