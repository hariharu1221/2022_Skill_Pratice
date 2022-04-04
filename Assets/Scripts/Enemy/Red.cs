using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : Enemy
{
    protected override void Awake()
    {

    }

    public override void EnemyUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    protected override void KillReward()
    {
        if (hp > 0) return;
        GameManager.Instance.painBar.GaugeBar += 5;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Bullet bullet = other.GetComponent<Bullet>();
            hp -= bullet.GetDamage();
            KillReward();
        }
    }
}
