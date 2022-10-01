using UnityEngine;

public class HostileController : MonoBehaviour {


    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bullet") {
            Destroy(gameObject);
        }
    }
}
