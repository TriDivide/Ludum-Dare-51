using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] private Text scoreText, modifierText;

    private string beginningModifierText = "Modifier in effect: ";

    void FixedUpdate() {
        scoreText.text = "Score: " + ScoreModel.Instance.score.ToString("0");

        modifierText.gameObject.SetActive(ModifierManager.Instance.modifierInEffect != null);

        if (ModifierManager.Instance.modifierInEffect != null) {

            switch (ModifierManager.Instance.modifierInEffect) {
                case Modifier.doubleScore:
                    modifierText.text = beginningModifierText + "Double Points.";
                    break;
                case Modifier.increasedPlayerDamage:
                    modifierText.text = beginningModifierText + "Double Damage.";
                    break;
                case Modifier.reverseHostileGravity:
                    modifierText.text = beginningModifierText + "Hostile Gravity Reversed";
                    break;
                case Modifier.reversePlayerGravity:
                    modifierText.text = beginningModifierText + "Gravity Reversed.";
                    break;
                case Modifier.speed:
                    modifierText.text = beginningModifierText + "Double Speed.";
                    break;

            }

        }
    }
}
