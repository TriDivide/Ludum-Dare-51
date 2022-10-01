
using UnityEngine;

public class ModifierManager : MonoBehaviour {


    public static ModifierManager Instance { get; private set; }

    public float playerMovementSpeed = 10f;
    [SerializeField] private float setPlayerMovementSpeed = 10f;

    private void Awake() {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
        }
    }

    public void DoublePlayerSpeed() {
        playerMovementSpeed = setPlayerMovementSpeed * 2f;
        Invoke("ResetPlayerSpeed", 10f); //reset the playerspeed after 10 seconds.
    }

    private void ResetPlayerSpeed() {
        print("resetting the player speed");
        playerMovementSpeed = setPlayerMovementSpeed;
    }


}

