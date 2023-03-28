using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiCoins : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text = null;

    public void UpdateCoinText(int coins)
    {

        text.SetText("Coins: " + coins.ToString());

    }

}
