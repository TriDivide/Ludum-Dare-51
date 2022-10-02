using UnityEngine;

public class ScoreModel : MonoBehaviour {

    public static ScoreModel Instance { get; private set; } = new ScoreModel();

    public int score { get; private set; }


    public ScoreModel() {
        score = 0;
    }

    public void AddToScore(int updatedScore) {
        score += updatedScore;
        print(score);
    }

    public void Reset() {
        score = 0;
    }
}
