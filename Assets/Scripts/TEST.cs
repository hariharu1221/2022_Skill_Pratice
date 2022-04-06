using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    //ġƮ => GameManager
    private void Cheat()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            PlayerSkillSystem.Instance.LevelUp();
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            if (Player.Instance.state != PlayerState.invincibility)
                Player.Instance.state = PlayerState.invincibility;
            else
                Player.Instance.state = PlayerState.normal;
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            EnemySubject.Instance.AllDestroy();
            //public void AllDestroy()
            //{
            //    foreach (Enemy enemy in enemies)
            //    {
            //        deathEnemies.Add(enemy);
            //    }
            //}
        }
        if (Input.GetKey(KeyCode.F6))
        {
            Player.Instance.hpGauge.GaugeBar += 0.1f;
        }
        if (Input.GetKey(KeyCode.F7))
        {
            Player.Instance.hpGauge.GaugeBar -= 0.1f;
        }
        if (Input.GetKey(KeyCode.F8))
        {
            GameManager.Instance.painBar.GaugeBar += 0.1f;
        }
        if (Input.GetKey(KeyCode.F9))
        {
            GameManager.Instance.painBar.GaugeBar -= 0.1f;
        }
        if (Input.GetKey(KeyCode.F10))
        {
            //Spawner CheatSpawn();
        }
        if (Input.GetKey(KeyCode.F11))
        {
            //Spawner CheatSpawn();
        }

    }

    //������
    private void GetRandomItem()
    {
        int random = Random.Range(0, 4);

        switch (random)
        {
            case 0:
                Player.Instance.hpGauge.GaugeBar += 10;
                break;
            case 1:
                //StartCoroutine(Player.Instance.InvincibilityBuff(3f));
                break;
            case 2:
                PlayerSkillSystem.Instance.EXP += 100;
                break;
            case 3:
                GameManager.Instance.painBar.GaugeBar -= 5f;
                break;
        }
    }

    //���ھ� â UI => ��ũ��Ʈ => 10������ ���� && ����ȭ���� ���ϴ� ��ư

    //���� ������ => player.hp <= 0 || painbar >= 100 update ���ؼ� UI ���� && �� �̻� ���� �� �� ���� bool�� üũ =>
    //UI���� ��ư ������ => ���ھ� ADD �� ���ھ� �ʱ�ȭ �� ���� ��ŷȭ������
    //
    //���� óġ�� => boss.isDead > update ���ؼ� UI ����  &&  �� �̻� ���� �� �� ���� bool�� üũ =>
    //UI���� ��ư ������ => ���ھ� Plus �� ���� ������


    //��� hp �� ������ ��������Ʈ
    [SerializeField] private GameObject sprite;
    [SerializeField] private GameObject hitSprite;
    [SerializeField] private GameObject hpSprite;

    public virtual void EnemyUpdate()
    {
        transform.Translate(0, 0, Time.deltaTime);
        //hpSprite.transform.localScale = new Vector3(hp / maxHp * 10, transform.localScale.y, transform.localScale.z);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Bullet bullet = other.GetComponent<Bullet>();
            //hp -= bullet.GetDamage();

            hitSprite.SetActive(true);
            sprite.SetActive(false);
            Invoke("ReturnSprite", 0.05f);

            //KillReward();
        }
        if (other.gameObject.CompareTag("Player"))
        {
            //hp = 0;
            //KillReward();
        }
    }


    //����, ������ ��Ʈ
    //���� ui
    //���� ����
    //pattern
    //
    //��� ����
    //bosspattern one
    //
    //��ų
    //pattern one

    //���� ����
}
//������ ��ƼŬ
