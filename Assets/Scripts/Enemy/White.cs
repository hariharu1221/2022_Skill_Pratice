using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class White : Enemy
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
        GetRandomItem();
        PlayerSkillSystem.Instance.EXP += exp;
        Player.Instance.fuelGauge.GaugeBar += 1;
    }

    protected override void OnTriggerEnter(Collider other)
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

    private void GetRandomItem()
    {
        int random = Random.Range(0, 4);

        switch(random)
        {
            case 0:
                Player.Instance.hpGauge.GaugeBar += 10;
                break;
            case 1:
                //StartCoroutine(Player.Instance.InvincibilityBuff(3f));
                break;
            case 2:
                exp += 100;
                break;
            case 3:
                GameManager.Instance.painBar.GaugeBar -= 5f;
                break;
        }
    }
}
