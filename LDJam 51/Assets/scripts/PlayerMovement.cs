using UnityEngine;

public class PlayerMovement : MonoBehaviour {

     private Rigidbody2D body;
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private float jumpSpeed = 10.0f;
    private bool isGrounded;
    private void Awake() {
        body = GetComponent<Rigidbody2D>();


    }

    private void Update() {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);    

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
}
