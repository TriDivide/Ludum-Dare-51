using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] private float bulletSpeed = 15f;
    [SerializeField] private float bulletDamage = 10f;

    [SerializeField] private Rigidbody2D rb;


    private void Start() {
        Invoke("Despawn", 2f);
    }


    void Despawn() {
        Destroy(gameObject);
    }

    private void FixedUpdate() {
        rb.velocity = transform.right * bulletSpeed;

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }

}
