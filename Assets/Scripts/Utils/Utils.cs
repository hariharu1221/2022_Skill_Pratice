using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static bool CheckEscape(GameObject ob)
    {
        if (Mathf.Abs(ob.transform.position.x) > 140 || ob.transform.position.z > 200 || ob.transform.position.z < -80) return true;
        return false;
    }
}
