using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UILevel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text = null;

    public void UpdateLevelText(int levelCount)
    {

        text.SetText("Level: " + levelCount.ToString());

    }


}
