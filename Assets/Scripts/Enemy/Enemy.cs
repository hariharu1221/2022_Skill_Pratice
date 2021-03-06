using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("?ҷ? ????")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDamage;
    [SerializeField] private float bulletCool;
    [SerializeField] protected float speed;

    [Header("????")]
    [SerializeField] protected float maxHp;
    protected float hp;
    public float HP { get { return hp; } set { hp = value; } }
    [SerializeField] protected int exp;
    [SerializeField] protected float destructDamage;
    public float DestructDamage { get { return destructDamage; } }

    [SerializeField] private GameObject sprite;
    [SerializeField] private GameObject hitSprite;
    [SerializeField] private GameObject hpSprite;

    private BulletShooter shooter;

    protected virtual void Awake()
    {
        shooter = GetComponent<BulletShooter>();
        shooter.Set(bulletCool, bulletSpeed, bulletDamage);

        hp = maxHp;
    }

    public virtual void HpMult(float mult)
    {
        maxHp *= mult;
        hp *= mult;
    }

    public virtual void EnemyUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        hpSprite.transform.localScale = new Vector3(hp / maxHp * 10, transform.localScale.y, transform.localScale.z);
    }

    protected virtual void KillReward()
    {
        if (hp > 0) return;
        PlayerSkillSystem.Instance.EXP += exp;
        Player.Instance.fuelGauge.GaugeBar += 1;
    }

    private void ReturnSprite()
    {
        hitSprite.SetActive(false);
        sprite.SetActive(true);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Bullet bullet = other.GetComponent<Bullet>();
            hp -= bullet.GetDamage();

            hitSprite.SetActive(true);
            sprite.SetActive(false);
            Invoke("ReturnSprite", 0.05f);

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
