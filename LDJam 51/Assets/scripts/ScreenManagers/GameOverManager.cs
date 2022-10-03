using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour {


    [SerializeField] private Text scoreText;


    private void Start() {
        scoreText.text = ScoreModel.Instance.score.ToString("0");    
    }

    public void Restart() {
        SceneManager.LoadScene("Gameplay");
    }

    public void Quit() {
        Application.Quit();
    }
}
