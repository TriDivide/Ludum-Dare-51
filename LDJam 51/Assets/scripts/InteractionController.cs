using UnityEngine;

public class InteractionController : MonoBehaviour {

    private bool enteredDoorRange = false;
    private GameObject currentInteractable;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.P) && enteredDoorRange && currentInteractable != null) {
            print("trying to open door");
            if (ScoreModel.Instance.score >= 5) {
                print("opened door");
                Destroy(currentInteractable);
                ScoreModel.Instance.AddToScore(-5);
                currentInteractable = null;
                enteredDoorRange = false;
            }
            else {
                print("not got the funds. Get rid of more hostiles.");
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Door") {
            currentInteractable = collision.gameObject;
            enteredDoorRange = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        currentInteractable = null;
        enteredDoorRange = false;
    }
}
