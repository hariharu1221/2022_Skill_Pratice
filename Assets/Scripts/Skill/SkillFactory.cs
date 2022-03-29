using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFactory
{
    public static Skill GetSkill(int index)
    {
             if (index == 0) return new Skill_Zero();
        else if (index == 1) return new SKill_One();
        else if (index == 2) return new Skill_Two();
        else if (index == 3) return new Skill_Three();

        return new SKill_One();
    }

    public static int Count()
    {
        return 4;
    }
}
