using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiLvlUp : MonoBehaviour
{

    Player player;



    private void Start()
    {
        player = FindAnyObjectByType(typeof(Player)) as Player;

    }



}
