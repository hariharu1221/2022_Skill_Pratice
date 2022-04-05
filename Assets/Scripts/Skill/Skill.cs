using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public abstract class Skill
{
    protected int level;
    protected float damage;
    public float Damage { get { return damage + PlayerSkillSystem.Instance.Level; } }

    protected GameObject bullet;
    protected AsyncOperationHandle bulletHandle;
    protected string bulletAddress;

    public string spriteAddress;
    public string text;
    public string name;

    protected int index;
    public int Index { get { return index; } }

    protected SkillType type;
    public SkillType Type { get { return type; } }

    public virtual void LevelUp()
    {

    }

    public virtual IEnumerator Passive()
    {
        yield return null;
    }

    public virtual void UseSkill()
    {

    }

    public void LoadBullet()
    {
        Addressables.LoadAssetAsync<GameObject>(bulletAddress).Completed +=
            (AsyncOperationHandle<GameObject> handle) =>
            {
                bullet = handle.Result;
                bulletHandle = handle;
            };
    }

    protected Bullet InstantiateBullet(BulletType type, int bulletSpeed = 100)
    {
        var b = BulletPool.Instance.InstantiateBullet(type);
        b.transform.position = Player.Instance.transform.position;
        b.BulletSet(bulletSpeed, Damage, EntityType.player);
        BulletSubject.Instance.AddBullet(b);

        return b;
    }

    protected Bullet InstantiateBullet_noadd(BulletType type, Vector3 pos, int bulletSpeed = 100)
    {
        var b = BulletPool.Instance.InstantiateBullet(type);
        b.transform.position = pos;
        b.BulletSet(bulletSpeed, Damage, EntityType.player);

        return b;
    }
}

public enum SkillType
{
    Active,
    Passive
}

public class Skill_Zero : Skill
{
    public Skill_Zero()
    {
        level = 0;
        damage = 5;
        bulletAddress = "Bullet";
        spriteAddress = "Skill";

        text = "백신을 원형으로 흩뿌립니다.";
        name = "Book";

        index = 0;
        type = SkillType.Passive;
    }

    float cool = 6;
    float maxTime = 3;

    public override void LevelUp()
    {
        level++;

        if (level >= 1) cool = 5;
        if (level >= 2) damage = 7;
        if (level >= 3) maxTime = 4;
        if (level >= 4) damage = 10;
        if (level >= 5) cool = 4;
        if (level >= 6) damage = 13;
        if (level >= 7) maxTime = 4;
        if (level >= 8) maxTime = 5;
        if (level >= 9)
        {
            damage += level - 8;
        }
    }

    public override IEnumerator Passive()
    {
        float rotY = 0;
        LoadBullet();
        yield return new WaitForSeconds(1f);

        while (true)
        {
            float time = 0;
            while(time < maxTime)
            {
                rotY += 30;
                if (rotY >= 360) rotY = 0;

                var b = InstantiateBullet(BulletType.bullet);
                b.transform.rotation = Quaternion.Euler(new Vector3(0, rotY, 0));

                time += 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(cool);
        }
    }
}

public class SKill_One : Skill
{
    public SKill_One()
    {
        level = 0;
        damage = 5;
        bulletAddress = "Bullet";
        spriteAddress = "Skill";

        text = "일정 시간마다 전방향으로 백신을 쏩니다.";
        name = "Circle Bullet";

        index = 1;
        type = SkillType.Passive;
    }

    float cool = 4;
    float number_of_bullet = 12;

    public override void LevelUp()
    {
        level++;

        if (level >= 1) cool = 3;
        if (level >= 2) damage = 7;
        if (level >= 3) number_of_bullet = 16;
        if (level >= 4) damage = 10;
        if (level >= 5) number_of_bullet = 20;
        if (level >= 6) damage = 13;
        if (level >= 7) cool = 2;
        if (level >= 8) number_of_bullet = 25;
        if (level >= 9)
        {
            damage += level - 8;
        }
    }

    public override IEnumerator Passive()
    {
        LoadBullet();
        yield return new WaitForSeconds(1f);

        while (true)
        {
            for (int i = 0; i < number_of_bullet; i++)
            {
                var b = InstantiateBullet(BulletType.bullet);
                b.transform.rotation = Quaternion.Euler(new Vector3(0, (i / number_of_bullet) * 360, 0));
            }
            yield return new WaitForSeconds(cool);
        }
    }
}

public class Skill_Two : Skill
{
    public Skill_Two()
    {
        level = 0;
        damage = 5;
        bulletAddress = "RotBullet";
        spriteAddress = "Skill";

        text = "가장 가까운 적을 노려 쏩니다";
        name = "Target Bullet";

        index = 2;
        type = SkillType.Passive;
    }

    float cool = 6;
    float number_of_bullet = 16;

    public override void LevelUp()
    {
        level++;

        if (level >= 1) cool = 5;
        if (level >= 2) damage = 7;
        if (level >= 3) number_of_bullet = 20;
        if (level >= 4) damage = 10;
        if (level >= 5) number_of_bullet = 24;
        if (level >= 6) damage = 13;
        if (level >= 7) cool = 4;
        if (level >= 8) number_of_bullet = 28;
        if (level >= 9)
        {
            damage += level - 8;
        }
    }

    public override IEnumerator Passive()
    {
        while (true)
        {
            List<Bullet> bullets = new List<Bullet>();

            for (int i = 0; i < number_of_bullet; i++)
            {
                Vector3 pos = new Vector3(-80 + (160 * i / number_of_bullet), 20, Player.Instance.transform.position.z - 10);
                var b = InstantiateBullet_noadd(BulletType.rotBullet, pos);
                bullets.Add(b);

                yield return new WaitForSeconds(0.05f);
            }

            foreach(Bullet i in bullets)
            {
                BulletSubject.Instance.AddBullet(i);
            }

            yield return new WaitForSeconds(cool);
        }
    }
}

public class Skill_Three : Skill
{
    public Skill_Three()
    {
        level = 0;
        damage = 5;
        bulletAddress = "RotBullet";
        spriteAddress = "Skill";

        text = "일정 시간 동안 가까운 적을 추가로 타게팅 합니다.";
        name = "Targeting";

        index = 2;
        type = SkillType.Passive;
    }

    float cool = 6;
    float maxTime = 4;

    public override void LevelUp()
    {
        level++;

        if (level >= 1) cool = 5;
        if (level >= 2) damage = 7;
        if (level >= 3) maxTime = 5;
        if (level >= 4) damage = 10;
        if (level >= 5) maxTime = 6;
        if (level >= 6) damage = 13;
        if (level >= 7) cool = 4;
        if (level >= 8) maxTime = 7;
        if (level >= 9)
        {
            damage += level - 8;
        }
    }

    public override IEnumerator Passive()
    {
        LoadBullet();
        yield return new WaitForSeconds(1f);

        while (true)
        {
            float time = 0;
            while (time < maxTime)
            {
                var b = InstantiateBullet(BulletType.rotBullet ,250);
                time += 0.1f;
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(cool);
        }
    }
}

public class Skill_Four : Skill
{
    public Skill_Four()
    {
        level = 0;
        damage = 5;
        bulletAddress = "Bullet";
        spriteAddress = "Skill";

        text = "매초 마다 일정량 회복합니다.";
        name = "Health Regen";

        index = 2;
        type = SkillType.Passive;
    }

    float cool = 1;
    float hp = 0.5f;

    public override void LevelUp()
    {
        level++;

        if (level >= 1) hp = 0.5f;
        if (level >= 2) hp = 0.8f;
        if (level >= 3) hp = 1.2f;
        if (level >= 4) hp = 1.5f;
        if (level >= 5) hp = 1.8f;
        if (level >= 6) hp = 2;
        if (level >= 7) hp = 2.5f;
        if (level >= 8) cool = 0.7f;
        if (level >= 9)
        {
            hp += level * 0.1f;
        }
    }

    public override IEnumerator Passive()
    {
        LoadBullet();
        yield return new WaitForSeconds(1f);

        while (true)
        {
            Player.Instance.hpGauge.GaugeBar += hp;
            yield return new WaitForSeconds(cool);
        }
    }
}

public class Skill_Five : Skill
{
    public Skill_Five()
    {
        level = 0;
        damage = 5;
        bulletAddress = "Bullet";
        spriteAddress = "Skill";

        text = "일정 시간마다 모든 총알을 반사합니다.";
        name = "reflect";

        index = 2;
        type = SkillType.Passive;
    }

    float cool = 25f;

    public override void LevelUp()
    {
        level++;

        if (level >= 1) cool = 25f;
        if (level >= 2) cool = 24f;
        if (level >= 3) cool = 23f;
        if (level >= 4) cool = 22f;
        if (level >= 5) cool = 21f;
        if (level >= 6) cool = 20f;
        if (level >= 7) cool = 19f;
        if (level >= 8) cool = 18f;
        if (level >= 9)
        {
            cool = 18f - level * 0.1f;
        }
    }

    public override IEnumerator Passive()
    {
        while (true)
        {
            BulletSubject.Instance.ChangeType(true);
            yield return new WaitForSeconds(cool);
        }
    }
}