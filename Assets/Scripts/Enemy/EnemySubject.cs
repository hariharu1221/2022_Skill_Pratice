using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySubject : DestructibleSingleton<EnemySubject>
{
    private List<Enemy> enemies;
    private List<Enemy> deathEnemies;
    [SerializeField] private GameObject enemyGroup;

    private int disCount;
    public int DisCount { get { return disCount; } }

    private void Awake()
    {
        SetInstance();
        VariableSet();
    }

    private void VariableSet()
    {
        enemies = new List<Enemy>();
        deathEnemies = new List<Enemy>();
        if (!enemyGroup) GameObject.Find("EnemyGroup");
        disCount = 0;
    }

    private void Update()
    {
        UpdateEnemy();
        DestoryEnemy();
    }
    
    private void UpdateEnemy()
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.EnemyUpdate();
            if (Utils.CheckEscape(enemy.gameObject))
                GameManager.Instance.painBar.GaugeBar += 1f;
            if (Utils.CheckEscape(enemy.gameObject) || enemy.HP <= 0)
                deathEnemies.Add(enemy);
        }
    }

    private void DestoryEnemy()
    {
        foreach (Enemy enemy in deathEnemies)
        {
            enemies.Remove(enemy);
            Destroy(enemy.gameObject);
            disCount++;
        }
        deathEnemies.Clear();
    }

    public void AddEnemy(Enemy enemy)
    {
        enemy.transform.SetParent(enemyGroup.transform);
        enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
    }

    public Enemy GetRandomEnemy()
    {
        int random = Random.Range(0, enemies.Count);
        return enemies[random];
    }

    public Enemy GetCloseToPlayerEnemy(Vector3 pos)
    {
        if (enemies.Count == 0) return null;

        int index = 0;
        float minDis = float.MaxValue;

        for(int i = 0; i < enemies.Count; i++)
        {
            float dis = Vector3.Distance(pos, enemies[i].transform.position);
            if (dis < minDis)
            {
                index = i;
                minDis = dis;
            }
        }
        return enemies[index];
    }
}
