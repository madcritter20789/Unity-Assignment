using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public Button buyHenButton;
    public Button buyWorkerButton;
    public Button unlockPopcornButton;
    public Button harvestCornButton;

    public CornField cornField;
    public PopcornMachine popcornMachine;

    void Start()
    {
        buyHenButton.onClick.AddListener(() => GameManager.Instance.SpawnHen());
        buyWorkerButton.onClick.AddListener(() => GameManager.Instance.SpawnWorker());
        unlockPopcornButton.onClick.AddListener(() => GameManager.Instance.UnlockPopcornMachine());
        /*
        harvestCornButton.onClick.AddListener(() =>
        {
            int corn = cornField.Harvest();
            if (corn > 0)
            {
                popcornMachine.AddCorn(corn);
            }
        });
        */
    }
}