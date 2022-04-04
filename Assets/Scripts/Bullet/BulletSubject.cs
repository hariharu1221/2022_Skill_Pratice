using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSubject : DestructibleSingleton<BulletSubject>
{
    private List<Bullet> bullets;
    private List<Bullet> deathBullets;
    [SerializeField] private GameObject bulletGroup;

    private void Awake()
    {
        SetInstance();
        VariableSet();
    }

    private void VariableSet()
    {
        bullets = new List<Bullet>();
        deathBullets = new List<Bullet>();
        if (!bulletGroup) bulletGroup = GameObject.Find("BulletGroup");
    }

    private void Update()
    {
        BulletUpdate();
        DestroyBullet();
    }

    private void BulletUpdate()
    {
        foreach (Bullet bullet in bullets)
        {
            if (!bullet.isStop) bullet.BulletUpdate();
            if (Utils.CheckEscape(bullet.gameObject) || bullet.Hited)
            {
                deathBullets.Add(bullet);
            }
        }
    }

    private void DestroyBullet()
    {
        foreach (Bullet bullet in deathBullets)
        {
            bullets.Remove(bullet);
            Destroy(bullet.gameObject);
        }
        deathBullets.Clear();
    }

    public void AddBullet(Bullet bullet)
    {
        bullet.gameObject.transform.SetParent(bulletGroup.transform);
        bullets.Add(bullet);
    }

    public void RemoveBullet(Bullet bullet)
    {
        deathBullets.Add(bullet);
    }

    public void ChangeType(bool isPlayer)
    {
        foreach (Bullet bullet in bullets)
        {
            if (isPlayer && bullet.Type != EntityType.player)
            {
                bullet.Type = EntityType.player;
                Vector3 pos = bullet.transform.rotation.eulerAngles - new Vector3(0, 180, 0);
                bullet.transform.rotation = Quaternion.Euler(pos);
                bullet.SetSprite();
            }
        }
    }

    public void StopBulelt(EntityType type, bool stop)
    {
        foreach (Bullet bullet in bullets)
        {
            if (bullet.Type == type) bullet.isStop = stop;
        }
    }
}
