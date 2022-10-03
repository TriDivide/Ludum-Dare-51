using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] private float bulletSpeed = 15f;

    [SerializeField] private Rigidbody2D rb;


    private void Start() {
        Invoke("Despawn", 2f);
    }


    void Despawn() {
        Destroy(gameObject);
    }

    private void FixedUpdate() {
        rb.velocity = transform.right * bulletSpeed;

        if (rb.velocity.x >= 0.01f) {
            transform.localScale = new Vector2(-2f, 0.8f);
        }
        else if (rb.velocity.x <= 0.01f) {
            transform.localScale = new Vector2(2f, 0.8f);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }

}
