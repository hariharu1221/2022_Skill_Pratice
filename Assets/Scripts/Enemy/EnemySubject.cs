using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySubject : MonoBehaviour
{
    private List<Enemy> enemies;
    private List<Enemy> deathEnemies;
    [SerializeField] private GameObject enemyGroup;

    private void Awake()
    {
        enemies = new List<Enemy>();
        deathEnemies = new List<Enemy>();
        if (!enemyGroup) GameObject.Find("EnemyGroup");
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
            if (Utils.CheckEscape(enemy.gameObject) || enemy.HP <= 0)
            {
                deathEnemies.Add(enemy);
            }
        }
    }

    private void DestoryEnemy()
    {
        foreach (Enemy enemy in deathEnemies)
        {
            enemies.Remove(enemy);
            Destroy(enemy.gameObject);
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
}
