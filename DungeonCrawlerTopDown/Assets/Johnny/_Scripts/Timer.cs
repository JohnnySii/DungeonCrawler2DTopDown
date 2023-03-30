using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float timerAdd;
    public bool timerOn = false;

    [SerializeField]
    private TextMeshProUGUI text = null;

    [SerializeField]
    private TextMeshProUGUI levelClearText = null;
    [SerializeField] GameObject levelCleared;


    [SerializeField]
    private Enemy enemyPrefab = null;

    public EenemySpawner enemySpawner;

    public Player player;

    public List<Enemy> allEnemies;

    public int enemiesLeft;

    public int stars = 0;
    public int maxStars = 3;


    public UILevelCleared uiLvlClear;

    [field: SerializeField]
    public UnityEvent<int> OnAddCoins { get; set; }

    [SerializeField]
    private UiCoins uiCoins = null;


    void Start()
    {
        timerOn = true;
        enemySpawner = FindObjectOfType(typeof(EenemySpawner)) as EenemySpawner;
        enemyPrefab = FindObjectOfType(typeof(Enemy)) as Enemy;
        player = FindAnyObjectByType(typeof(Player)) as Player;
        uiLvlClear = FindAnyObjectByType(typeof(UILevelCleared)) as UILevelCleared;

    }

    void Update()
    {


        CheckTimer();

        //if (enemyPrefab.EnemiesLeft == true)
        //{
        //    allEnemies.RemoveAt(allEnemies.Count - 1);

        //    Debug.Log("Enemy count: " + allEnemies.Count);


        //    enemiesLeft -= 1;

        //    enemyPrefab.EnemiesLeft = false;
        //}

    }

    public void CheckTimer()
    {

        if (timerOn)
        {
            timerAdd += Time.deltaTime;
            UpdateTimer(timerAdd);
        }


        //if (enemySpawner.Count <= 0)
        //{
        //    Debug.Log(enemySpawner.Count);
        //}

        CheckLevelClear();



    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        text.SetText("Timer: {0:00} : {1:00}", minutes, seconds);

    }

    public void CheckLevelClear()
    {
        if (player.LevelCleared == true)
        {
            if (timerAdd >= 0 && timerAdd < 10)
            {
                stars = 3;
                player.Coins += 100;

                levelCleared.SetActive(true);
                Time.timeScale = 0f;

                levelClearText.SetText("Level cleared in: " + timerAdd + " seconds\n" + 
                    " You achieved " + stars + "/" + maxStars + " stars " + 
                    "\nYou got " + player.Coins + " coins");

            }
            else if (timerAdd >= 10 && timerAdd < 15)
            {
                Debug.Log("You have cleared the level in: " + timerAdd + " seconds");
                stars = 2;
                player.Coins += 50;
                Debug.Log("You achieved " + stars + "/" + maxStars + " stars and got " + player.Coins + " coins");

                levelCleared.SetActive(true);
                Time.timeScale = 0f;

                levelClearText.SetText("Level cleared in: " + timerAdd + " seconds\n" +
                    " You achieved " + stars + "/" + maxStars + " stars " +
                    "\nYou got " + player.Coins + " coins");

            }
            else if (timerAdd >= 15 && timerAdd < 20)
            {
                Debug.Log("You have cleared the level in: " + timerAdd + " seconds");
                stars = 1;
                player.Coins += 25;
                Debug.Log("You achieved " + stars + "/" + maxStars + " stars and got " + player.Coins + " coins");

                levelCleared.SetActive(true);
                Time.timeScale = 0f;

                levelClearText.SetText("Level cleared in: " + timerAdd + " seconds\n" +
                    " You achieved " + stars + "/" + maxStars + " stars " +
                    "\nYou got " + player.Coins + " coins");

            }
            else if (timerAdd >= 20 && timerAdd < 25)
            {
                Debug.Log("You have cleared the level in: " + timerAdd + " seconds");
                stars = 0;
                player.Coins += 0;
                Debug.Log("You achieved " + stars + "/" + maxStars + " stars and got " + player.Coins + " coins");

                levelCleared.SetActive(true);
                Time.timeScale = 0f;

                levelClearText.SetText("Level cleared in: " + timerAdd + " seconds\n" +
                    " You achieved " + stars + "/" + maxStars + " stars " +
                    "\nYou got " + player.Coins + " coins");
            }
            timerOn = false;
            player.LevelCleared = false;
            player.UpdateLevelClearText = true;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        levelCleared.SetActive(false);

        OnAddCoins.AddListener(uiCoins.UpdateCoinText);
        uiCoins.UpdateCoinText(player.Coins);

    }


}
