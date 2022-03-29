using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GaugeBackFront fuelGauge;
    [SerializeField] private GaugeBackFront hpGauge;
    [SerializeField] private Image expGauge;
    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        SetGauge(fuelGauge, player.fuelGauge.GaugeBar / player.fuelGauge.MaxGaugeBar);
        SetGauge(hpGauge, player.hpGauge.GaugeBar / player.hpGauge.MaxGaugeBar);
    }

    private void SetGauge(GaugeBackFront gauge, float value)
    {
        gauge.front.fillAmount = value;
        gauge.back.fillAmount = Mathf.Lerp(gauge.back.fillAmount, gauge.front.fillAmount, Time.deltaTime * 2f);
        //if (gauge.front.fillAmount <= fuelGauge.back.fillAmount - 0.001f) gauge.back.fillAmount = gauge.front.fillAmount;
    }
}

[System.Serializable]
public class GaugeBackFront
{
    public Image front;
    public Image back;
}
//hp, fuel, 진행도, 미션, 