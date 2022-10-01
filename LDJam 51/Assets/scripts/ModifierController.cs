using UnityEngine;

public class ModifierController : MonoBehaviour {

    private bool playerOnPad = false;

    private void FixedUpdate() {
        if (playerOnPad && Input.GetKeyDown(KeyCode.P)) {
            ModifierManager.Instance.DoublePlayerSpeed();
            print("upgrade");
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
