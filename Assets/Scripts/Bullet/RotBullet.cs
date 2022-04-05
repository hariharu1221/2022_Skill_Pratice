using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotBullet : Bullet
{
    public override void SetTag()
    {
        GameObject target;

        if (type == EntityType.player)
        {
            Enemy enemy = EnemySubject.Instance.GetCloseToPlayerEnemy(Player.Instance.transform.position);
            if (enemy == null)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                return;
            }
            target = enemy.gameObject; // 가장 가까운 적
            gameObject.tag = "PlayerBullet";
            Vector3 dir = target.transform.position - transform.position;
            dir.y = 0;
            transform.rotation = Quaternion.LookRotation(dir.normalized);
        }
        else
        {
            target = Player.Instance.gameObject;
            gameObject.tag = "EnemyBullet";
            Vector3 dir = target.transform.position - transform.position;
            dir.y = 0;
            transform.rotation = Quaternion.LookRotation(dir.normalized);
        }
    }

    public override void BulletUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnDisable()
    {
        BulletPool.Instance.ReturnToRotPool(this);
    }
}