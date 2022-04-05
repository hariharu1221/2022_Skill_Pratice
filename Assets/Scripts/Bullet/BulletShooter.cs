using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public BulletType bullet;
    public EntityType type;
    private float cool;
    private float speed;
    [HideInInspector] public float damage;
    private BulletSubject subject;

    private void Awake()
    {
        if(!subject) subject = FindObjectOfType<BulletSubject>();
    }

    public void Set(float cool, float speed, float damage)
    {
        this.cool = cool;
        this.speed = speed;
        this.damage = damage;
    }

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while(true)
        {
            Fire();
            yield return new WaitForSeconds(cool);
        }
    }

    private void Fire()
    {
        var n = BulletPool.Instance.InstantiateBullet(bullet);
        n.transform.position = transform.position;
        n.transform.rotation = transform.rotation;
        n.BulletSet(speed, damage, type);
        subject.AddBullet(n);
    }
}

public enum EntityType
{
    player,
    enemy,
    boss
}

public enum BulletType
{
    bullet,
    rotBullet,
    toBullet
}