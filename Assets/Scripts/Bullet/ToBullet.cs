using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToBullet : Bullet
{
    public Vector3 ToRot;
    public float ToRotSpeed = 1;

    public float ToFast;
    public float ToFastSpeed = 1;

    public override void BulletUpdate()
    {
        Vector3 rot = Vector3.Lerp(transform.rotation.eulerAngles, ToRot, Time.deltaTime * ToRotSpeed);
        transform.rotation = Quaternion.Euler(rot);

        this.speed = Mathf.Lerp(this.speed, ToFast, Time.deltaTime * ToFastSpeed);

        base.BulletUpdate();
    }

    public void DelayToRotSet(Vector3 toRot, float speed, float time)
    {
        StartCoroutine(DelayRotSet(toRot, speed, time));
    }

    private IEnumerator DelayRotSet(Vector3 toRot, float speed, float time)
    {
        yield return new WaitForSeconds(time);
        ToRot = toRot;
        ToRotSpeed = speed;
    }

    public void DelayToRotSet(GameObject target, float speed, float time)
    {
        StartCoroutine(DelayRotSet(target, speed, time));
    }

    private IEnumerator DelayRotSet(GameObject target, float speed, float time)
    {
        yield return new WaitForSeconds(time);
        ToRot = Utils.TargetRotation(transform.position, target.transform.position);
        ToRotSpeed = speed;
    }

    public void DelayToFastSet(float toFast, float speed, float time)
    {
        StartCoroutine(DelayFastSet(toFast, speed, time));
    }

    private IEnumerator DelayFastSet(float toFast, float speed, float time)
    {
        yield return new WaitForSeconds(time);
        ToFast = toFast;
        ToFastSpeed = speed;
    }
}
