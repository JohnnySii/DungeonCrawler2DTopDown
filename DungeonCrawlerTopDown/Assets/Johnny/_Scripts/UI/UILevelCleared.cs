using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class UILevelCleared : MonoBehaviour
{
    [SerializeField] GameObject levelCleared;

    [SerializeField]
    private TextMeshProUGUI text = null;



    Player player;

    public Timer timer;


    private void Start()
    {
        player = FindAnyObjectByType(typeof(Player)) as Player;
        timer = FindAnyObjectByType(typeof(Timer)) as Timer;


    }

    private void Update()
    {
        StarsAchieved();
    }


    private void StarsAchieved()
    {
        if (player.LevelCleared == true)
        {
            

            levelCleared.SetActive(true);
            Time.timeScale = 0f;

            text.SetText("Level cleared in: " + timer.timerAdd + " seconds\n" +
                "you got " + player.Coins + "/" + player.Coins + " coins");



        }

    }

    public void Restart()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("JohnnyTest");


    }
}
