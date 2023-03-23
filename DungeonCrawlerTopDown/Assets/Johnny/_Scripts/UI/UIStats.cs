using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIStats : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text = null;

    public void UpdateStatsText(int damage)
    {

        text.SetText("Damage: " + damage.ToString());

    }



}
