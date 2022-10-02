
using UnityEngine;

public class ModifierManager : MonoBehaviour {


    public static ModifierManager Instance { get; private set; }

    public float playerMovementSpeed { get; private set; } = 10f;
    [SerializeField] private float defaultPlayerMovementSpeed = 10f;

    public float bulletDamage { get; private set; } = 10f;
    [SerializeField] private float defaultBulletDamage = 10f;

    public float playerGravityScale { get; private set; } = 5f;
    private float defaultPlayerGravityScale = 5f;


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


    public void ReversePlayerGravity() {
        if (!hasModifierSet) {
            print("reversed gravity");
            hasModifierSet = true;
            playerGravityScale = -5;
            Invoke("ResetPlayerGravity", 10f);
        }
        
    }

    private void ResetPlayerGravity() {
        print("Player gravity has been reset");
        print(defaultPlayerGravityScale);
        playerGravityScale = defaultPlayerGravityScale;
        print(playerGravityScale);
        hasModifierSet = false;
    }
}

