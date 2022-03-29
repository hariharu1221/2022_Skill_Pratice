using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;
    private float damage;
    private EntityType type;

    public void BulletSet(float speed, float damage, EntityType type)
    {
        this.speed = speed;
        this.damage = damage;
        this.type = type;
    }

    public virtual void BulletUpdate()
    {
        transform.position += Vector3.forward * Time.deltaTime * speed;
    }
}
