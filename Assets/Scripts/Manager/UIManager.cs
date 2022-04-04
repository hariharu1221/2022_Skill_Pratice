using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : DestructibleSingleton<UIManager>
{
    [SerializeField] private GaugeBackFront fuelGauge;
    [SerializeField] private GaugeBackFront hpGauge;
    [SerializeField] private Image expGauge;
    [SerializeField] private Image painGauge;
    [SerializeField] private Image bossGauge;
    [SerializeField] private Text misson;
    [SerializeField] private RectTransform Target;
    private Boss boss;

    void Update()
    {
        SetGauge(fuelGauge, Player.Instance.fuelGauge.GaugeBar / Player.Instance.fuelGauge.MaxGaugeBar);
        SetGauge(hpGauge, Player.Instance.hpGauge.GaugeBar / Player.Instance.hpGauge.MaxGaugeBar);
        SetGauge(expGauge, (float)PlayerSkillSystem.Instance.EXP / (float)PlayerSkillSystem.Instance.MAX_EXP);
        SetGauge(painGauge, GameManager.Instance.painBar.GaugeBar / GameManager.Instance.painBar.MaxGaugeBar);
    }

    public void SetMisson(string text)
    {
        misson.text = text;
    }

    private void SetGauge(GaugeBackFront gauge, float value)
    {
        gauge.front.fillAmount = value;
        gauge.back.fillAmount = Mathf.Lerp(gauge.back.fillAmount, gauge.front.fillAmount, Time.deltaTime * 2f);
    }

    private void SetGauge(Image gauge, float value)
    {
        gauge.fillAmount = Mathf.Lerp(gauge.fillAmount, value, Time.deltaTime * 4f);
    }

    public void SetBoss(Boss boss)
    {
        this.boss = boss;
        StartCoroutine(BossUI());
    }

    IEnumerator BossUI()
    {
        while (true)
        {
            SetGauge(bossGauge, boss.HP / boss.MaxHp);
            yield return new WaitForEndOfFrame();
        }
    }
}

[System.Serializable]
public class GaugeBackFront
{
    public Image front;
    public Image back;
}
//hp, fuel, 진행도, 미션, 