using UnityEngine;

public class HealthController : MonoBehaviour {

    public double playerHealth = 100;
    public double maxHealth = 100;

    public int deathWait = 5;

    public bool underAttack = false;


    public void FixedUpdate() {
        if (playerHealth > 0) {
            if (underAttack) {
                print(playerHealth);
                playerHealth -= 0.8;
            }
        }
        else {
            print("player died.");
            playerHealth = 0;
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.GetType() == typeof(BoxCollider2D) && collision.collider.gameObject.tag == "Hostile") {
            underAttack = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.GetType() == typeof(BoxCollider2D) && collision.collider.gameObject.tag == "Hostile") {
            underAttack = false;
        }
    }

}
