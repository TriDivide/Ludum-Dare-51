using UnityEngine;

public class HostileController : MonoBehaviour {

    [SerializeField] private float health = 20f;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bullet") {
            print(health);
            health -= ModifierManager.Instance.bulletDamage;
            print(health);
            if (health <= 0) {
                print("desteroy");
                Destroy(gameObject);
            }


        }
    }
}