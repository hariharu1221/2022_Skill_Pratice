using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float speed;
    protected float damage;
    protected EntityType type;
    public EntityType Type { get { return type; } set { type = value; SetTag(); } }

    protected bool hited;
    public bool Hited { get { return hited; } }
    public bool isStop;


    public virtual void BulletSet(float speed, float damage, EntityType type)
    {
        this.speed = speed;
        this.damage = damage;
        this.type = type;
        hited = false;
        isStop = false;

        SetTag();
        SetSprite();
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetSpeedDelay(float speed, float time)
    {
        StartCoroutine(SetSpeedDelayCor(speed, time));
    }

    private IEnumerator SetSpeedDelayCor(float speed, float time)
    {
        yield return new WaitForSeconds(time);
        this.speed = speed;
    }

    public void SetSprite()
    {
        GameObject pl = gameObject.transform.Find("Player").gameObject;
        GameObject en = gameObject.transform.Find("Enemy").gameObject;

        if (type == EntityType.player)
        {
            pl.SetActive(true);
            en.SetActive(false);
        }
        else
        {
            pl.SetActive(false);
            en.SetActive(true);
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
        return damage;
    }
    
    public virtual void SetTag()
    {
        if (type == EntityType.player)
        {
            gameObject.tag = "PlayerBullet";
        }
        else
        {
            gameObject.tag = "EnemyBullet";
        }
    }

    private void OnDisable()
    {
        BulletPool.Instance.ReturnToPool(this);
    }
}