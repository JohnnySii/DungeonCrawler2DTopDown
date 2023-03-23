using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiLevelUpgradeChoice : MonoBehaviour
{

    [SerializeField] GameObject levelUpRewardMenu;

    public GameObject TextBox;
    public GameObject Option01;
    public GameObject Option02;
    public GameObject Option03;
    public int OptionChosen { get; set; }

    Player player;

    private void Start()
    {
        player = FindAnyObjectByType(typeof(Player)) as Player;
    }

    private void Update()
    {
        if (player.LeveledUp == true)
        {
            levelUpRewardMenu.SetActive(true);
            Time.timeScale = 0f;

            player.LeveledUp = false;
        }


    }

    public void ChoiceOption1()
    {
        OptionChosen = 1;

        levelUpRewardMenu.SetActive(false);
        Debug.Log("Damage now: " + player.doDamage);

        player.doDamage += 100 * player.currentLevel;

        player.OnAddDamage?.Invoke(player.doDamage);


        Debug.Log("Damage now: " + player.doDamage);

        Time.timeScale = 1f;

    }

    public void ChoiceOption2()
    {
        OptionChosen = 2;

        levelUpRewardMenu.SetActive(false);
        Debug.Log("Health now: " + player.Health);

        player.Health += 2;

        Debug.Log("Health now: " + player.Health);

        Time.timeScale = 1f;

    }

    public void ChoiceOption3()
    {
        OptionChosen = 3;

        levelUpRewardMenu.SetActive(false);

        Time.timeScale = 1f;

        //player.Ammo += 100;
    }



}
