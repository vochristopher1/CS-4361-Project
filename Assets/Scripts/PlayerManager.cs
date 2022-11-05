using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static int points;
    public TextMeshProUGUI CoinsText;

    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CoinsText.text = "Coins:" + points;
    }
}
