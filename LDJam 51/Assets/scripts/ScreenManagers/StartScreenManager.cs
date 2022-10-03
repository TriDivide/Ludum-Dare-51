using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScreenManager : MonoBehaviour {

    public void StartGame() {
        SceneManager.LoadScene("Gameplay");
    }

    public void Instructions() {
        SceneManager.LoadScene("Instructions");
    }

    public void Quit() {
        Application.Quit();
    }
}
