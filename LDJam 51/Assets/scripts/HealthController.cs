using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour {

    public double playerHealth = 100;
    public double maxHealth = 100;

    public int deathWait = 5;

    public bool underAttack = false;

    [SerializeField] private Text playerHealthText;

    public void FixedUpdate() {
        UpdateHealth();
    }

    private void UpdateHealth() {
        playerHealthText.text = "Health: " + playerHealth.ToString("0");
        if (playerHealth > 0) {
            if (underAttack) {
                print(playerHealth);
                playerHealth -= 0.8;
            }
        }
        else {
            print("player died.");
            playerHealth = 0;
            SceneManager.LoadScene("GameOver");
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.gameObject.tag == "Hostile") {
            underAttack = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.gameObject.tag == "Hostile") {
            underAttack = false;
        }
    }

}
