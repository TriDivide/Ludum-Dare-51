using UnityEngine;

public class ModifierController : MonoBehaviour {

    private bool playerOnPad = false;

    private enum Modifier { speed, increasedPlayerDamage, }

    private Modifier currentModifier;


    private void Start() {
        InvokeRepeating("UpdateCurrentModifier", .0001f, 10f);
    }

    private void UpdateCurrentModifier() {
        currentModifier = (Modifier)Random.Range(0, 2);
        print(currentModifier);
    }

    private void Update() {
        if (playerOnPad && Input.GetKeyDown(KeyCode.P)) {
            print(currentModifier);
            print("trying to change");
            switch(currentModifier) {
                case Modifier.speed:
                    ModifierManager.Instance.DoublePlayerSpeed();
                    print("upgrade");
                    break;
                case Modifier.increasedPlayerDamage:
                    ModifierManager.Instance.DoubleBulletDamage();
                    print("upgrade");
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
