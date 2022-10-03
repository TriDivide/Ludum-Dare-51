using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameObject spawnObject;
    public string tagRef;
    public int MaxNumberInScene = 20;
    private int objectsInScene = 0;

    public float spawnRate = 10f;


    private void Start() {
        InvokeRepeating("Spawn", 0f, spawnRate);
    }

    private void FixedUpdate() {
        if (tagRef != null) {
            objectsInScene = GameObject.FindGameObjectsWithTag(tagRef).Length;
        }
    }

    private void Spawn() {
        if (objectsInScene <= MaxNumberInScene) {
            Instantiate(spawnObject, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }
}
