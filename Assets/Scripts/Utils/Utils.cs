using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static bool CheckEscape(GameObject ob)
    {
        if (Mathf.Abs(ob.transform.position.x) > Player.Instance.limit.x + 80 || Mathf.Abs(ob.transform.position.z) > Player.Instance.limit.y + 160) return true;
        return false;
    }

    public static Vector3 TargetRotation(Vector3 originPos, Vector3 targetPos)
    {
        Vector3 dir = targetPos - originPos;
        dir.y = 0;
        return Quaternion.LookRotation(dir.normalized).eulerAngles;
    }
}
