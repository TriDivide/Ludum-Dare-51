using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    [SerializeField] private float fireRate = 0.2f;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject bulletPrefab;


    private float timeUntilFire;
    private PlayerMovement pm;


    private void Awake() {
        pm = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && timeUntilFire < Time.time) {
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
    }

    private void Shoot() {
        float angle = pm.isFacingRight ? 0f : 180f;
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }



}
