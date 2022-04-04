using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static bool CheckEscape(GameObject ob)
    {
        if (Mathf.Abs(ob.transform.position.x) > Player.Instance.limit.x + 80 || Mathf.Abs(ob.transform.position.z) > Player.Instance.limit.y + 80) return true;
        return false;
    }
}
