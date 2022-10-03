using UnityEngine;

public class PlayerMovement : MonoBehaviour {

     private Rigidbody2D body;
    [SerializeField] private float speed = 0f;
    [SerializeField] private float jumpSpeed = 10.0f;

    private float horizontalInput;

    private bool isGrounded;

    [HideInInspector] public bool isFacingRight = true;

    [SerializeField] private AudioSource jumpSound;


    private void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        speed = ModifierManager.Instance.playerMovementSpeed;
    }

    private void FixedUpdate() {
        speed = ModifierManager.Instance.playerMovementSpeed;
    }

    private void Update() {

        body.gravityScale = ModifierManager.Instance.playerGravityScale;

        horizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);    

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded) {
            Jump();
        }

        if (horizontalInput > 0f) {
            isFacingRight = true;
            transform.localScale = new Vector3(0.8f, 0.8f, 1f);
        }
        else if (horizontalInput < 0f) {
            isFacingRight = false;
            transform.localScale = new Vector3(-0.8f, 0.8f, 1f);
        }
    }

    private void Jump() {
        jumpSound.Play();
        body.velocity = new Vector2(body.velocity.x, ModifierManager.Instance.playerGravityScale > 0 ? jumpSpeed : -jumpSpeed);
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
