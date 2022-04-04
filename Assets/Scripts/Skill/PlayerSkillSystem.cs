using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillSystem : DestructibleSingleton<PlayerSkillSystem>
{
    [SerializeField] private LevelUpUI levelUpUI;

    private int level;
    public int Level { get { return level; } }
    private int exp;
    public int EXP { get { return exp; } set { exp = value; LevelCheck(); } }
    public int MAX_EXP { get { return (int)(100 * Mathf.Sqrt(level)); } }
    public const int MAX_SKILL_COUNT = 7;
    private bool isLevelUp;
    private List<Skill> skillList;
    [SerializeField] private BulletShooter shooter;
    private List<BulletShooter> shooterList;

    private void Awake()
    {
        SetInstance();
        VariableSet();
        WeaponCheck();
    }

    private void VariableSet()
    {
        if (!levelUpUI) levelUpUI = FindObjectOfType<LevelUpUI>();
        level = 1;
        isLevelUp = false;
        skillList = new List<Skill>();
        shooterList = new List<BulletShooter>();
    }

    private void WeaponCheck()
    {
        if (level == 1)
        {
            WeaponClear();
            InstantitateWeapon(Vector3.zero, 5, 0.1f);
        }
        else if (level == 3)
        {
            WeaponClear();
            InstantitateWeapon(new Vector3(3, 0, 0), 7, 0.1f);
            InstantitateWeapon(new Vector3(-3, 0, 0), 7, 0.1f);
        }
        else if (level == 5)
        {
            WeaponClear();
            InstantitateWeapon(new Vector3(3.5f, 0, 0), 9, 0.1f);
            InstantitateWeapon(new Vector3(0, 0, 0), 9, 0.1f);
            InstantitateWeapon(new Vector3(-3.5f, 0, 0), 9, 0.1f);
        }
        else if (level >= 5)
        {
            WeaponClear();
            InstantitateWeapon(new Vector3(3.5f, 0, 0), 5 + level, 0.1f);
            InstantitateWeapon(new Vector3(0, 0, 0), 5 + level, 0.1f);
            InstantitateWeapon(new Vector3(-3.5f, 0, 0), 5 + level, 0.1f);
        }
    }
    
    private void WeaponClear()
    {
        foreach(var shooter in shooterList)
        {
            Destroy(shooter.gameObject);
        }
        shooterList.Clear();
    }

    private void InstantitateWeapon(Vector3 pos, float damage = 5, float cool = 0.1f, float speed = 250)
    {
        var n = Instantiate(shooter, this.transform);
        n.transform.localPosition = pos;
        n.Set(cool, speed, damage);
        shooterList.Add(n);
    }

    private void LevelCheck()
    {
        if (exp >= MAX_EXP)
            LevelUp();
    }

    public void LevelUp() //standby
    {
        if (isLevelUp) return;
        level++;

        isLevelUp = true;

        int optionOne, optionTwo, optionThr;
        //UI ¶ç¿ì±â
        if (skillList.Count < MAX_SKILL_COUNT)
        {
            optionOne = Random.Range(0, SkillFactory.Count());
            optionTwo = Random.Range(0, SkillFactory.Count());
            optionThr = Random.Range(0, SkillFactory.Count());
        }
        else
        {
            int[] indexs = new int[MAX_SKILL_COUNT];
            for (int i = 0; i < MAX_SKILL_COUNT; i++)
                indexs[i] = skillList[i].Index;

            optionOne = indexs[Random.Range(0, MAX_SKILL_COUNT)];
            optionTwo = indexs[Random.Range(0, MAX_SKILL_COUNT)];
            optionThr = indexs[Random.Range(0, MAX_SKILL_COUNT)];
        }

        Time.timeScale = 0.3f;
        levelUpUI.SetOptions(optionOne, optionTwo, optionThr);
    }

    public void LevelUpEnd(Skill skill) //end
    {
        if (!isLevelUp) return;
        isLevelUp = false;
        Time.timeScale = 1f;
        GetSkill(skill);
        exp -= MAX_EXP;
        WeaponCheck();
        LevelCheck();
    }

    public void GetSkill(Skill skill)
    {
        bool on = false;
        foreach (Skill item in skillList)
        {
            if (item.GetType() == skill.GetType())
            {
                item.LevelUp();
                on = true;
                break;
            }
        }

        if (on) return;

        skillList.Add(skill);
        StartCoroutine(skill.Passive());
    }

    public void MaxLevel()
    {
        foreach (Skill item in skillList)
        {
            item.LevelUp();
        }
    }
}
