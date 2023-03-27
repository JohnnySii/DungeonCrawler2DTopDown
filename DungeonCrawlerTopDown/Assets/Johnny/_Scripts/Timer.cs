using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timerAdd;
    public bool timerOn = false;

    [SerializeField]
    private TextMeshProUGUI text = null;

    [SerializeField]
    private Enemy enemyPrefab = null;

    public EenemySpawner enemySpawner;

    public Player player;

    public List<Enemy> allEnemies;

    public int enemiesLeft;


    void Start()
    {
        timerOn = true;
        enemySpawner = FindObjectOfType(typeof(EenemySpawner)) as EenemySpawner;
        enemyPrefab = FindObjectOfType(typeof(Enemy)) as Enemy;
        player = FindAnyObjectByType(typeof(Player)) as Player;

        allEnemies = new List<Enemy>();
        for (int i = 0; i < enemySpawner.Count; i++)
        {
            allEnemies.Add(enemyPrefab);
        }
        enemiesLeft = enemySpawner.Count;
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
            //Debug.Log(timerAdd);
        }


        //if (enemySpawner.Count <= 0)
        //{
        //    Debug.Log(enemySpawner.Count);
        //}

        if (timerAdd >= 10 && timerAdd < 20)
        {

        }
        else if (timerAdd >= 20 && timerAdd < 30)
        {

        }
        else if (timerAdd >= 30 && timerAdd < 40)
        {

        }
        else if (timerAdd >= 40 && timerAdd < 60)
        {

        }

    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        text.SetText("Timer: {0:00} : {1:00}", minutes, seconds);

    }


}
