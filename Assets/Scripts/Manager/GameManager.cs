using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : DestructibleSingleton<GameManager>
{
    [SerializeField] private Boss bossPrefab;
    [HideInInspector] public GaugePoint painBar;
    private bool isOnBoss;
    public bool IsOnBoss { get { return isOnBoss; } }

    private int maxDisCount = 5;
    private Camera camera;

    private void Awake()
    {
        SetInstance();
        painBar = new GaugePoint(105, 0);
        isOnBoss = false;
        camera = Camera.main;
    }

    private void Update()
    {
        if (EnemySubject.Instance.DisCount >= maxDisCount && !isOnBoss)
        {
            var n = Instantiate(bossPrefab);
            n.transform.position = new Vector3(0, 20, 150);
            isOnBoss = true;
            UIManager.Instance.SetBoss(n);
        }

        if (!IsOnBoss)
        {
            UIManager.Instance.SetMisson("Virus is be Comming!  " + EnemySubject.Instance.DisCount + " / " + maxDisCount);
        }
        else
        {
            UIManager.Instance.SetMisson("Kill Corona Virus!");
        }

        
    }

    private void Check()
    {
        if (painBar.GaugeBar >= 100 || Player.Instance.hpGauge.GaugeBar <= 0) GameEnd();
    }

    public void NextLevel()
    {
        //boss
        SceneManager.LoadScene(2);
    }

    private void GameEnd()
    {
        //ui
        Invoke("Title", 2f);
    }

    private void Title()
    {
        SceneManager.LoadScene(0);
    }
}
