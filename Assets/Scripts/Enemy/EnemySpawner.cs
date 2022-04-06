using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies = new List<Enemy>();
    private float minCool;
    private float maxCool;
    [SerializeField] private EnemySubject subject;

    private const float fx = 80;
    private const float fy = 20;
    private const float fz = 240;

    private float enemyHpMult;

    private void Awake()
    {
        if (!subject) FindObjectOfType<EnemySubject>();

        minCool = 1f;
        maxCool = 1.5f;
        enemyHpMult = 1f;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            Check();

            Vector3 vec = new Vector3(Random.Range(-fx, fx + 1), fy, fz + transform.position.z);
            int index = Random.Range(0, enemies.Count);
            Spawn(vec, index);

            float cool = Random.Range(minCool, maxCool);
            yield return new WaitForSeconds(cool);
        }
    }

    private void Spawn(Vector3 vec, int index)
    {
        var n = Instantiate(enemies[index]);
        n.transform.position = vec;
        n.HpMult(enemyHpMult);
        subject.AddEnemy(n);
    }

    private void Check()
    {
        if (EnemySubject.Instance.DisCount >= 15)
        {
            minCool = 0.7f;
            maxCool = 1.2f;
            enemyHpMult = 1.6f;
        }
        if (EnemySubject.Instance.DisCount >= 30)
        {
            minCool = 0.3f;
            maxCool = 0.7f;
            enemyHpMult = 2f;
        }
        if (EnemySubject.Instance.DisCount >= 100) 
        {
            minCool = 0.3f;
            maxCool = 0.6f;
            enemyHpMult = 3f;
        }
        if (EnemySubject.Instance.DisCount >= 200) 
        {
            minCool = 0.3f;
            maxCool = 0.6f;
            enemyHpMult = 4f;
        }
        if (EnemySubject.Instance.DisCount >= 400) 
        {
            minCool = 0.3f;
            maxCool = 0.5f;
            enemyHpMult = 4f;
        }
        if (EnemySubject.Instance.DisCount >= 800)
        {
            minCool = 0.25f;
            maxCool = 0.4f;
            enemyHpMult = 5f;
        }
    }
}
