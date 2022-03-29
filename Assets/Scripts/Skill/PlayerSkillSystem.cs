using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillSystem : DestructibleSingleton<PlayerSkillSystem>
{
    [SerializeField] private LevelUpUI levelUpUI;

    private int level;
    private int exp;
    public int EXP { get { return exp; } set { exp = value; StartCoroutine(LevelCheck()); } }
    private bool isLevelUp;
    private List<Skill> skillList;

    private void Awake()
    {
        SetInstance();
        VariableSet();
    }

    private void Start()
    {
        Invoke("LevelUp", 2f);
    }

    private void VariableSet()
    {
        if (!levelUpUI) levelUpUI = FindObjectOfType<LevelUpUI>();
        level = 0;
        isLevelUp = false;
        skillList = new List<Skill>();

       
    }

    private IEnumerator LevelCheck()
    {
        while (exp >= 100)
        {
            exp -= 100;
            LevelUp();
            yield return new WaitForFixedUpdate();
        }
        Debug.Log(exp);
    }

    public void LevelUp() //standby
    {
        if (isLevelUp) return;
        level++;

        isLevelUp = true;
        //UI ����
        int optionOne = Random.Range(0, SkillFactory.Count());
        int optionTwo = Random.Range(0, SkillFactory.Count());
        int optionThr = Random.Range(0, SkillFactory.Count());

        Time.timeScale = 0.3f;
        levelUpUI.SetOptions(optionOne, optionTwo, optionThr);
    }

    public void LevelUpEnd(Skill skill) //end
    {
        if (!isLevelUp) return;
        isLevelUp = false;
        Time.timeScale = 1f;
        Debug.Log(skill.GetType().Name);
        GetSkill(skill);
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
        skill.Passive();
    }

    public void MaxLevel()
    {
        foreach (Skill item in skillList)
        {
            item.LevelUp();
        }
    }
}
