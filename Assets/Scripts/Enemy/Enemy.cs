using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("ºÒ·¿ Á¶Á¤")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDamage;
    [SerializeField] private float bulletCool;
    [SerializeField] protected float speed;

    [Header("½ºÅÝ")]
    [SerializeField] protected float hp;
    public float HP { get { return hp; } set { hp = value; } }
    [SerializeField] protected int exp;
    [SerializeField] protected float destructDamage;
    public float DestructDamage { get { return destructDamage; } }

    private BulletShooter shooter;

    protected virtual void Awake()
    {
        shooter = GetComponent<BulletShooter>();
        shooter.Set(bulletCool, bulletSpeed, bulletDamage);
    }

    public virtual void EnemyUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    protected virtual void KillReward()
    {
        if (hp > 0) return;
        PlayerSkillSystem.Instance.EXP += exp;
        Player.Instance.fuelGauge.GaugeBar += 1;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Bullet bullet = other.GetComponent<Bullet>();
            hp -= bullet.GetDamage();
            KillReward();
        }
        if (other.gameObject.CompareTag("Player"))
        {
            hp = 0;
            KillReward();
        }
    }

    protected virtual void OnCollisionEnter(Collision other)
    {

    }
}
