using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("ºÒ·¿ Á¶Á¤")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDamage;
    [SerializeField] private float bulletCool;
    [SerializeField] private float speed;

    [Header("½ºÅÝ")]
    [SerializeField] private float hp;
    public float HP { get { return hp; } }
    [SerializeField] private int exp;

    private BulletShooter shooter;

    private void Awake()
    {
        shooter = GetComponent<BulletShooter>();
        shooter.Set(bulletCool, bulletSpeed, bulletDamage);
    }

    public void EnemyUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void Check()
    {
        if (hp <= 0) PlayerSkillSystem.Instance.EXP += exp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Bullet bullet = other.GetComponent<Bullet>();
            hp -= bullet.GetDamage();
            Check();
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hp = 0;
            Check();
        }
    }
}
