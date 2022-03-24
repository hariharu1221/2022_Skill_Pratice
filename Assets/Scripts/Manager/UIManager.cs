using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image fuelGauge;
    [SerializeField] private Image hpGauge;
    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        fuelGauge.fillAmount = player.fuelGauge.GaugeBar / player.fuelGauge.MaxGaugeBar;
        hpGauge.fillAmount = player.hpGauge.GaugeBar / player.hpGauge.MaxGaugeBar;
    }
}

//hp, fuel, 진행도, 미션, 