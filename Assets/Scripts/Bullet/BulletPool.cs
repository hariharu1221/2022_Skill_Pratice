using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : DestructibleSingleton<BulletPool>
{
    [SerializeField] private Bullet bulletPrefab;
    private Queue<Bullet> noActiveBullets = new Queue<Bullet>();

    [SerializeField] private RotBullet rotBulletPrefab;
    private Queue<RotBullet> noActiveRotBullets = new Queue<RotBullet>();

    private void Awake()
    {
        SetInstance();
    }

    public Bullet InstantiateBullet(BulletType type)
    {
        Bullet bullet;
        if (type == BulletType.bullet)
        {
            if (noActiveBullets.Count == 0) bullet = Instantiate(bulletPrefab);
            else bullet = noActiveBullets.Dequeue();
            bullet.gameObject.SetActive(true);
        }
        else if (type == BulletType.rotBullet)
        {
            if (noActiveRotBullets.Count == 0) bullet = Instantiate(rotBulletPrefab);
            else bullet = noActiveRotBullets.Dequeue();
            bullet.gameObject.SetActive(true);
        }
        else
        {
            if (noActiveBullets.Count == 0) bullet = Instantiate(bulletPrefab);
            else bullet = noActiveBullets.Dequeue();
            bullet.gameObject.SetActive(true);
        }

        return bullet;
    }

    public Bullet InstantiateBullet()
    {
        Bullet bullet;
        if (noActiveBullets.Count == 0) bullet = Instantiate(bulletPrefab);
        else bullet = noActiveBullets.Dequeue();
        bullet.gameObject.SetActive(true);

        return bullet;
    }

    public void ReturnToPool(Bullet bullet)
    {
        noActiveBullets.Enqueue(bullet);
    }

    public RotBullet InstantiateRotBullet()
    {
        RotBullet bullet;
        if (noActiveRotBullets.Count == 0) bullet = Instantiate(rotBulletPrefab);
        else bullet = noActiveRotBullets.Dequeue();
        bullet.gameObject.SetActive(true);

        return bullet;
    }

    public void ReturnToRotPool(RotBullet bullet)
    {
        noActiveRotBullets.Enqueue(bullet);
    }
}
