
using UnityEngine;

public class ModifierManager : MonoBehaviour {


    public static ModifierManager Instance { get; private set; }

    public float playerMovementSpeed = 10f;
    [SerializeField] private float defaultPlayerMovementSpeed = 10f;

    public float bulletDamage = 10f;
    [SerializeField] private float defaultBulletDamage = 10f;


    public bool hasModifierSet { get; private set; } = false;

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
        if (!hasModifierSet) {
            print("Doubled player speed");
            playerMovementSpeed = defaultPlayerMovementSpeed * 2f;
            hasModifierSet = true;
            Invoke("ResetPlayerSpeed", 10f); //reset the playerspeed after 10 seconds.
        }
    }

    private void ResetPlayerSpeed() {
        hasModifierSet = false;
        print("resetting the player speed");
        playerMovementSpeed = defaultPlayerMovementSpeed;
    }

    public void DoubleBulletDamage() {
        if (!hasModifierSet) {
            print("doubled bullet damage");
            hasModifierSet = true;
            bulletDamage = defaultBulletDamage * 2f;
            Invoke("ResetBulletDamage", 10f);
        }
    }

    private void ResetBulletDamage() {
        hasModifierSet = false;
        print("resetting the bullet damage");
        bulletDamage = defaultBulletDamage;
    }
}

