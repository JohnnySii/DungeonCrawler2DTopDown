using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent, IHittable
{
    [SerializeField]
    private int maxHealth;

    public bool LeveledUp { get; set; }
    private int health;
    private int damage;
    public bool UpdateLevelClearText { get; set; }
    public int Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
            uiHealth.UpdateUI(health);
        }
    }

    private int xp;
    private int levelUpXp = 10;
    //private int currentLevel = 1;
    public int currentLevel { get; set; } = 1;

    public int doDamage = 5;

    public Enemy enemy;

    [field: SerializeField]
    public UnityEvent<int> OnLevelUp { get; set; }
    [field: SerializeField]
    public UnityEvent<int> OnAddDamage { get; set; }


    [SerializeField]
    private UILevel uiLevel = null;

    [SerializeField]
    private UIStats uiStats = null;

    public int Xp 
    { 
        get => xp;
        set
        {
            xp = Mathf.Clamp(value, 0, levelUpXp);

        } 
    }

    public bool LevelUp { get; set; }

    private bool dead = false;
    public bool LevelCleared { get; set; } = false;

    public int Coins { get; set; }

    [field: SerializeField]
    public UIHealth uiHealth { get; set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }
    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    public UiLevelUpgradeChoice uiLevelUpgradeChoice;


    private void Start()
    {
        Health = maxHealth;
        uiHealth.Initialize(Health);
        enemy = FindObjectOfType(typeof(Enemy)) as Enemy;

        uiLevelUpgradeChoice = FindAnyObjectByType(typeof(UiLevelUpgradeChoice)) as UiLevelUpgradeChoice;


        OnLevelUp.AddListener(uiLevel.UpdateLevelText);
        uiLevel.UpdateLevelText(currentLevel);

        OnAddDamage.AddListener(uiStats.UpdateStatsText);
        uiStats.UpdateStatsText(doDamage);

    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if(dead == false)
        {
            Health--;
            OnGetHit?.Invoke();
            if (Health <= 0)
            {
                OnDie?.Invoke();
                dead = true;
                StartCoroutine(DeathCoroutine());
            }
        }
        
        
    }

    IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

    public void GainXP()
    {

        if (Xp >= levelUpXp)
        {
            currentLevel++;
            LeveledUp = true;
            Debug.Log("You levelled up");
            Debug.Log("Level: " + currentLevel);
            Xp = 0;
            doDamage = currentLevel * 2;
        }
        Debug.Log("Killed enemy and gained xp");

        Xp++;
        Debug.Log("You have " + Xp + "/" + levelUpXp);

        OnLevelUp?.Invoke(currentLevel);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            //SceneManager.LoadScene("LevelUpReward");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Resource"))
        {
            var resource = collision.gameObject.GetComponent<Resource>();
            if (resource != null)
            {
                switch (resource.ResourceData.ResourceType)
                {
                    case ResourceTypeEnum.Health:
                        if(Health >= maxHealth)
                        {
                            return;
                        }
                        Health += resource.ResourceData.GetAmount();
                        resource.PickUpResource();
                        break;
                }
            }
        }
    }

}
