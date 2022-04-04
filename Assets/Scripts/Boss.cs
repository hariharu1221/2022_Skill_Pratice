using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("ºÒ·¿ Á¶Á¤")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDamage;
    [SerializeField] private float bulletCool;
    [SerializeField] protected float speed;

    [Header("½ºÅÝ")]
    [SerializeField] protected float maxHP;
    protected float hp;
    [SerializeField] protected int exp;
    [SerializeField] protected float destructDamage;

    [Header("ºÒ·¿")]
    [SerializeField] protected Bullet bullet;
    [SerializeField] protected Bullet rotBullet;

    public float HP { get { return hp; } set { hp = value; } }
    public float MaxHp { get { return maxHP; } }
    public float DestructDamage { get { return destructDamage; } }

    private BulletShooter[] shooters;

    protected virtual void Awake()
    {
        shooters = GetComponentsInChildren<BulletShooter>();
        foreach(BulletShooter shooter in shooters)
        {
            shooter.Set(bulletCool, bulletSpeed, bulletDamage);          
        }
        hp = maxHP;
    }

    private void Start()
    {
        StartCoroutine(Pattern());
    }


    private IEnumerator ToMove(Vector3 nowPos, Vector3 pos, float time)
    {
        float cool = 0;
        while (cool < time)
        {
            transform.position = Vector3.Lerp(nowPos, pos, cool / time);
            cool += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = pos;
    }

    float nz = 42;
    float ny = 20;
    private IEnumerator Pattern()
    {
        yield return ToMove(transform.position, new Vector3(0, 20, nz), 3f);
        while (true)
        {
            int random = Random.Range(0, 6);

            switch(random)
            {
                case 0:
                    yield return ToMove(transform.position, new Vector3(Player.Instance.transform.position.x, ny, nz), 2f);
                    break;
                case 1:
                    yield return pOne();
                    break;
                case 2:
                    yield return pTwo();
                    break;
                case 3:
                    yield return pThr();
                    break;
                case 4:
                    yield return pFou();
                    break;
                case 5:
                    yield return pFiv();
                    break;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator pOne()
    {
        yield return ToMove(transform.position, new Vector3(Player.Instance.transform.position.x, ny, nz), 0.5f);
        yield return ToMove(transform.position, new Vector3(transform.position.x, ny, -15), 0.5f);
        yield return ToMove(transform.position, new Vector3(transform.position.x, ny, nz), 1f);
    }

    private IEnumerator pTwo()
    {
        float cool = 0;
        float number_of_bullet = 50;

        StartCoroutine(ToMove(transform.position, new Vector3(Player.Instance.transform.position.x, ny, nz), 1f));
        while (cool < 3)
        {
            for (int i = 0; i < number_of_bullet; i++)
            {
                var b = InstantiateBullet(30, bulletDamage, transform.position);
                b.transform.rotation = Quaternion.Euler(new Vector3(0, ((float)(i + cool) / number_of_bullet) * 360f, 0));
            }
            cool += 0.25f;
            yield return new WaitForSeconds(0.25f);
        }
    }

    private IEnumerator pThr()
    {
        float number_of_bullet = 50;

        StartCoroutine(ToMove(transform.position, new Vector3(Player.Instance.transform.position.x, ny, nz), 1f));
        for (int k = 0; k < 5; k++)
        {
            for (int i = 0; i < number_of_bullet; i++)
            {
                var b = InstantiateBullet(20, bulletDamage, transform.position);
                b.transform.rotation = Quaternion.Euler(new Vector3(0, ((float)(i + k / 10f) / number_of_bullet) * 360f, 0));
                b.SetSpeedDelay(100, 3f);
                yield return new WaitForSeconds(0.005f);
            }
        }
    }

    private IEnumerator pFou()
    {
        float number_of_bullet = 50;

        for (int k = 0; k < 5; k++)
        {
            StartCoroutine(ToMove(transform.position, new Vector3(Player.Instance.transform.position.x, ny, nz), 1f)); 
            for (int i = 0; i < number_of_bullet; i++)
            {
                var b = InstantiateBullet(30, bulletDamage, transform.position);
                b.transform.rotation = Quaternion.Euler(new Vector3(0, -((float)(i + k / 10f) / number_of_bullet) * 360f, 0));
                b.SetSpeedDelay(0, 1f);
                b.SetSpeedDelay(60, 5f);

                var b2 = InstantiateBullet(30, bulletDamage, transform.position);
                b2.transform.rotation = Quaternion.Euler(new Vector3(0, ((float)(i + k / 10f) / number_of_bullet) * 360f, 0));
                b2.SetSpeedDelay(0, 2f);
                b2.SetSpeedDelay(60, 6f);

                yield return new WaitForSeconds(0.005f);
            }
        }

        yield return new WaitForSeconds(5f);
    }

    private IEnumerator pFiv()
    {
        float number_of_bullet = 6;
        StartCoroutine(ToMove(transform.position, new Vector3(Player.Instance.transform.position.x, ny, nz), 1f));
        for (int k = 0; k < 80; k++)
        {
            for (int i = 0; i < number_of_bullet; i++)
            {
                var b = InstantiateBullet(50, bulletDamage, transform.position);
                b.transform.rotation = Quaternion.Euler(new Vector3(0, ((float)(i + k / 10f) / number_of_bullet) * 360f, 0));
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    private Bullet InstantiateBullet(float speed, float damage, Vector3 pos)
    {
        var b = GameObject.Instantiate(bullet);
        b.BulletSet(speed, damage, EntityType.boss);
        b.transform.position = pos;
        BulletSubject.Instance.AddBullet(b);

        return b;
    }

    protected virtual void KillReward()
    {
        if (hp > 0) return;
        //ÅÍÁö´Â ÆÄÆ¼Å¬
        GameManager.Instance.NextLevel();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Bullet bullet = other.GetComponent<Bullet>();
            hp -= bullet.GetDamage();
            KillReward();
        }
    }   
}
