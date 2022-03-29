using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public Bullet bullet;
    public EntityType type;
    private float cool;
    private float speed;
    private float damage;
    private GameObject target;
    [SerializeField] private BulletSubject subject;

    private void Awake()
    {
        if(!subject) subject = FindObjectOfType<BulletSubject>();
        if (type == EntityType.enemy) target = Player.Instance.gameObject;
        else if (type == EntityType.player) target = Player.Instance.gameObject; // 가장 가까운 적
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
        var n = Instantiate(bullet);
        n.BulletSet(speed, damage, type, target);
        n.transform.position = transform.position;
        subject.AddBullet(n);
    }
}

public enum EntityType
{
    player,
    enemy,
    boss
}