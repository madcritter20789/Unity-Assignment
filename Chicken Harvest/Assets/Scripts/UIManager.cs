using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI eggText;
    public TextMeshProUGUI popcornText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void UpdateUI(int money, int eggs, int popcorn)
    {
        moneyText.text = "Money: $" + money;
        eggText.text = "Eggs: " + eggs;
        popcornText.text = "Popcorn: " + popcorn;
    }

    public void UpdateMoney(int money)
    {
        moneyText.text = "Money: $" + money;
    }

    public void UpdateEggs(int eggs)
    {
        eggText.text = "Eggs: " + eggs;
    }

    public void UpdatePopcorn(int popcorn)
    {
        popcornText.text = "Popcorn: " + popcorn;
    }
}