using UnityEngine;

public class HostileController : MonoBehaviour {


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float health = 20f;


    private void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();    
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bullet") {
            health -= ModifierManager.Instance.bulletDamage;
            if (health <= 0) {
                ScoreModel.Instance.AddToScore(ModifierManager.Instance.scoreValue);
                Destroy(gameObject);
            }


        }
    }

    private void Update() {
        rb.gravityScale = ModifierManager.Instance.hostileGravityScale;
    }
}