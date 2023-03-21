using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent, IHittable
{
    [SerializeField]
    private int maxHealth;

    private int health;
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
    private int levelUpXp = 5;

    public Enemy enemy;

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

    [field: SerializeField]
    public UIHealth uiHealth { get; set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }
    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    private void Start()
    {
        Health = maxHealth;
        uiHealth.Initialize(Health);
        enemy = FindObjectOfType(typeof(Enemy)) as Enemy;
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

        if (xp >= levelUpXp)
        {
            Debug.Log("Level up");

        }
        Debug.Log("Killed enemy and gained xp");

        Xp++;
        Debug.Log("You have " + Xp + "/" + levelUpXp);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
    //    {
    //        LevelUp();
    //    }

    //    //Destroy(gameObject);
    //}

}
