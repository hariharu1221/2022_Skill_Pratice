using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    protected int level;
    protected int projectile;
    protected float damage;

    protected Bullet bullet;
    protected string bulletAddress;

    public string spriteAddress;
    public string text;
    public string name;

    public virtual void LevelUp()
    {

    }

    public virtual void Passive()
    {

    }

    public virtual void UseSkill()
    {

    }
}

public class Skill_Zero : Skill
{
    public Skill_Zero()
    {
        level = 0;
        projectile = 5;
        damage = 5;
        bulletAddress = "Bullet";
        spriteAddress = "Skill";

        text = "asdf";
        name = "None";
    }
}

public class SKill_One : Skill
{
    public SKill_One()
    {
        level = 0;
        projectile = 5;
        damage = 5;
        bulletAddress = "Bullet";
        spriteAddress = "Skill";

        text = "asdf";
        name = "None";
    }
}

public class Skill_Two : Skill
{
    public Skill_Two()
    {
        level = 0;
        projectile = 5;
        damage = 5;
        bulletAddress = "Bullet";
        spriteAddress = "Skill";

        text = "asdf";
        name = "None";
    }
}

public class Skill_Three : Skill
{
    public Skill_Three()
    {
        level = 0;
        projectile = 5;
        damage = 5;
        bulletAddress = "Bullet";
        spriteAddress = "Skill";

        text = "asdf";
        name = "None";
    }
}