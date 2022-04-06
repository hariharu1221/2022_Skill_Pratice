using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    //치트 => GameManager
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

    //아이템
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

    //스코어 창 UI => 스크립트 => 10개까지 정렬 && 메인화면을 통하는 버튼

    //게임 오버시 => player.hp <= 0 || painbar >= 100 update 통해서 UI 띄우기 && 더 이상 실행 할 수 없게 bool로 체크 =>
    //UI에서 버튼 누르면 => 스코어 ADD 후 스코어 초기화 및 정렬 랭킹화면으로
    //
    //보스 처치시 => boss.isDead > update 통해서 UI 띄우기  &&  더 이상 실행 할 수 없게 bool로 체크 =>
    //UI에서 버튼 누르면 => 스코어 Plus 후 다음 씬으로


    //잡몹 hp 및 맞을때 스프라이트
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


    //보스, 레이저 도트
    //보스 ui
    //보스 패턴
    //pattern
    //
    //잡몹 패턴
    //bosspattern one
    //
    //스킬
    //pattern one

    //복붙 복붙
}
//남으면 파티클
