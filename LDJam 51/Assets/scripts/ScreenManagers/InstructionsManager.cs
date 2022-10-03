using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsManager : MonoBehaviour {

    public void Back() {
        SceneManager.LoadScene("Opening");
    }

    public void Quit() {
        Application.Quit();
    }

}
