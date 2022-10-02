using UnityEngine;

public class ModifierController : MonoBehaviour {

    private bool playerOnPad = false;

    private enum Modifier { speed, increasedPlayerDamage, reversePlayerGravity, reverseHostileGravity }

    private Modifier currentModifier;


    private void Start() {
        InvokeRepeating("UpdateCurrentModifier", .0001f, 10f);
    }

    private void UpdateCurrentModifier() {
        currentModifier = (Modifier)Random.Range(0, 4);
    }

    private void Update() {
        if (playerOnPad && Input.GetKeyDown(KeyCode.P)) {
            print(currentModifier);
            switch(currentModifier) {
                case Modifier.speed:
                    ModifierManager.Instance.DoublePlayerSpeed();
                    break;
                case Modifier.increasedPlayerDamage:
                    ModifierManager.Instance.DoubleBulletDamage();
                    break;
                case Modifier.reversePlayerGravity:
                    ModifierManager.Instance.ReversePlayerGravity();
                    break;
                case Modifier.reverseHostileGravity:
                    ModifierManager.Instance.ReverseHostileGravity();
                    break;
            }
              
        }
    }


    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            playerOnPad = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            playerOnPad = false;
        }
    }
}
