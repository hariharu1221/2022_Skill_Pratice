using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float speed;
    protected float damage;
    protected EntityType type;

    protected bool hited;
    public bool Hited { get { return hited; } }

    public virtual void BulletSet(float speed, float damage, EntityType type, GameObject target)
    {
        this.speed = speed;
        this.damage = damage;
        this.type = type;
        hited = false;

        if (type == EntityType.player)
        {
            gameObject.tag = "PlayerBullet";
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.tag = "EnemyBullet";
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public virtual void BulletUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    public float GetDamage()
    {
        if (hited) return 0;
        hited = true;
        Debug.Log(hited);
        return damage;
    }
}

public class RotBullet : Bullet
{
    public override void BulletSet(float speed, float damage, EntityType type, GameObject target)
    {
        base.BulletSet(speed, damage, type, target);

        Vector3 dir = target.transform.position = transform.position;
        transform.rotation = Quaternion.LookRotation(dir.normalized);
    }

    public override void BulletUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}

public enum BulletType
{
    bullet,
    rotBullet,
    guidedBullet
}