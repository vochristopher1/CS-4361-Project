using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static int points;
    public TextMeshProUGUI CoinsText;
    public static int currentHealth = 100;
    public Slider healthBar;
    public static bool gameOver;
    public GameObject gameOverPanel;

    void Start()
    {
        points = 0;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        CoinsText.text = "Coins:" + points;

        healthBar.value = currentHealth;

        if (currentHealth < 0)
        {
            gameOver = true;
            gameOverPanel.SetActive(true);
            currentHealth = 100;
        }
    }
}
