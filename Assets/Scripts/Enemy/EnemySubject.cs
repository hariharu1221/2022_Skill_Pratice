using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySubject : MonoBehaviour
{
    private List<Enemy> enemies;

    private void Awake()
    {
        enemies = new List<Enemy>();
    }

    private void Update()
    {
        List<Enemy> list = new List<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.EnemyUpdate();
            if (Utils.CheckEscape(enemy.gameObject))
            {
                list.Add(enemy);
            }
        }

        foreach (Enemy enemy in list)
        {
            enemies.Remove(enemy);
            Destroy(enemy.gameObject);
        }
    }

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
    }
}
