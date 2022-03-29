using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies = new List<Enemy>();
    [SerializeField] private float minCool;
    [SerializeField] private float maxCool;
    [SerializeField] private EnemySubject subject;

    private const float fx = 80;
    private const float fy = 20;
    private const float fz = 160;

    private void Awake()
    {
        if (!subject) FindObjectOfType<EnemySubject>();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            Vector3 vec = new Vector3(Random.Range(-fx, fx + 1), fy, fz);
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
        subject.AddEnemy(n);
    }
}
