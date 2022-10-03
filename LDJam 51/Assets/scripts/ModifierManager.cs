using UnityEngine;


public enum Modifier { speed, increasedPlayerDamage, reversePlayerGravity, reverseHostileGravity, doubleScore, }

public class ModifierManager : MonoBehaviour {


    public static ModifierManager Instance { get; private set; }

    public Modifier? modifierInEffect { get; private set; }

    public float playerMovementSpeed { get; private set; } = 10f;
    [SerializeField] private float defaultPlayerMovementSpeed = 10f;

    public float bulletDamage { get; private set; } = 10f;
    [SerializeField] private float defaultBulletDamage = 10f;

    public float playerGravityScale { get; private set; } = 5f;
    private float defaultPlayerGravityScale = 5f;

    public float hostileGravityScale { get; private set; } = 1f;
    private float defaultHostileGravityScale = 1f;

    public int scoreValue { get; private set; } = 1;
    private int defaultScoreValue = 1;


    public bool hasModifierSet { get; private set; } = false;


    public void SetModifierInEffect(Modifier? modifier) {
        modifierInEffect = modifier;
    }
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
            SetModifierInEffect(Modifier.speed);
            print("Doubled player speed");
            playerMovementSpeed = defaultPlayerMovementSpeed * 2f;
            hasModifierSet = true;
            Invoke("ResetPlayerSpeed", 10f); //reset the playerspeed after 10 seconds.
        }
    }

    private void ResetPlayerSpeed() {
        SetModifierInEffect(null);
        hasModifierSet = false;
        print("resetting the player speed");
        playerMovementSpeed = defaultPlayerMovementSpeed;
    }

    public void DoubleBulletDamage() {
        if (!hasModifierSet) {
            SetModifierInEffect(Modifier.increasedPlayerDamage);
            print("doubled bullet damage");
            hasModifierSet = true;
            bulletDamage = defaultBulletDamage * 2f;
            Invoke("ResetBulletDamage", 10f);
        }
    }

    private void ResetBulletDamage() {
        hasModifierSet = false;
        print("resetting the bullet damage");
        SetModifierInEffect(null);
        bulletDamage = defaultBulletDamage;
    }


    public void ReversePlayerGravity() {
        if (!hasModifierSet) {
            SetModifierInEffect(Modifier.reversePlayerGravity);
            print("reversed gravity");
            hasModifierSet = true;
            playerGravityScale = -5;
            Invoke("ResetPlayerGravity", 10f);
        }
        
    }

    private void ResetPlayerGravity() {
        print("Player gravity has been reset");
        SetModifierInEffect(null);
        playerGravityScale = defaultPlayerGravityScale;
        hasModifierSet = false;
    }

    public void ReverseHostileGravity() {
        if (!hasModifierSet) {
            SetModifierInEffect(Modifier.reverseHostileGravity);
            print("reversed hostile gravity");
            hasModifierSet = true;
            hostileGravityScale = -1;
            Invoke("ResetHostileGravity", 10f);
        }

    }

    private void ResetHostileGravity() {
        print("hostile gravity has been reset");
        SetModifierInEffect(null);
        hostileGravityScale = defaultHostileGravityScale;
        hasModifierSet = false;
    }

    public void DoubleScoreValue() {
        if (!hasModifierSet) {
            SetModifierInEffect(Modifier.doubleScore);
            print("double score value");
            hasModifierSet = true;
            scoreValue = 2;
            Invoke("ResetScoreValue", 10f);
        }

    }

    private void ResetScoreValue() {
        print("hostile gravity has been reset");
        SetModifierInEffect(null);
        scoreValue = defaultScoreValue;
        hasModifierSet = false;
    }
}

