using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    private int step = 0;
    public bool tutorialActive = true;

    void Start()
    {
        ShowStep();
    }

    public void ShowStep()
    {
        tutorialActive = true;
        switch (step)
        {
            case 0:
                tutorialText.text = "Welcome! Use joystick to move.";
                break;
            case 1:
                tutorialText.text = "Go near the hens and click 'Collect' to gather eggs.";
                break;
            case 2:
                tutorialText.text = "Move to the customer box to sell eggs.";
                break;
            case 3:
                tutorialText.text = "Unlock popcorn field to grow corn and make popcorn.";
                break;
            default:
                tutorialText.text = "";
                tutorialActive = false;
                break;
        }

        Invoke(nameof(NextStep), 6f);
    }

    void NextStep()
    {
        step++;
        ShowStep();
    }
}