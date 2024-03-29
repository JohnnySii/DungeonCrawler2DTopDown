using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : Bullet
{
    protected Rigidbody2D rigidBody;

    public override BulletDataSO BulletData 
    { 
        get => base.BulletData;
        set
        { 
            base.BulletData = value;
            rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.drag = BulletData.Friction;
        }
    }

    private void FixedUpdate()
    {
        if (rigidBody != null && BulletData != null)
        {
            //Bullet flying in the direction it is facing
            rigidBody.MovePosition(transform.position + BulletData.BulletSpeed * transform.right * Time.fixedDeltaTime);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hittable = collision.GetComponent<IHittable>();
        hittable?.GetHit(BulletData.Damage, gameObject);
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            HitObstacle();
        }else if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            HitEnemy();
        }
        Destroy(gameObject);
    }

    private void HitEnemy()
    {
        Debug.Log("Hitting enemy");
    }

    private void HitObstacle()
    {
        Debug.Log("Hitting obstacle");
    }


}
