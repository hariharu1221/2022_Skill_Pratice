using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : DestructibleSingleton<Player>
{
    #region VARIABLE
    //SERIALIZEFIELD
    [SerializeField] private float originSpeed;
    [SerializeField] private float time;

    //VARIABLE
    [HideInInspector] public GaugePoint hpGauge;
    [HideInInspector] public GaugePoint fuelGauge;
    [HideInInspector] public GaugePoint painGauge;
    [HideInInspector] public PlayerState state;
    [HideInInspector] public float yPos;
    [HideInInspector] public float speed;

    //INPUT
    [HideInInspector] public ExecutionOrder lowFlyingState;
    [HideInInspector] public ExecutionOrder boostingState;
    [HideInInspector] public Vector2 vec;
    [HideInInspector] public Quaternion rot;

    private bool Invincibility;

    //CONST
    public Vector2 limit { get { return new Vector2(160, 100); } }

    #endregion

    private void Awake()
    {
        VariableSetting();
    }

    private void Update()
    {
        Movement();
        LowFlying();
        Boosting();
        GaugeManagement();
        StateManagement();
        SetRotation();
    }

    private void VariableSetting()
    {
        hpGauge   = new GaugePoint(200, 200);
        fuelGauge = new GaugePoint(20, 20);
        painGauge = new GaugePoint(100, 0);
        yPos = 20;
        speed = originSpeed;

        state = PlayerState.normal;
        lowFlyingState = ExecutionOrder.none;
        boostingState = ExecutionOrder.none;

        Invincibility = false;
    }

    private void Movement() //움직임
    {
        transform.position += new Vector3(vec.x, 0, vec.y) * Time.deltaTime * speed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -limit.x, limit.x),
            transform.position.y, Mathf.Clamp(transform.position.z, -limit.y, limit.y));
    }

    private void LowFlying() //저공비행
    {
        Vector3 pos = new Vector3(transform.position.x, 0, transform.position.z);

        if (state == PlayerState.overload) lowFlyingState = ExecutionOrder.none;
        if (lowFlyingState == ExecutionOrder.none)
        {
            transform.position = Vector3.Lerp(transform.position, pos + new Vector3(0, yPos, 0), Time.deltaTime * 5);
            return;
        }

        switch(lowFlyingState)
        {
            case ExecutionOrder.standby:
                //내려가는 효과
                lowFlyingState = ExecutionOrder.execution;
                break;
            case ExecutionOrder.execution:
                transform.position = Vector3.Lerp(transform.position, pos + new Vector3(0, -20, 0), Time.deltaTime * 5);
                fuelGauge.GaugeBar -= Time.deltaTime * 4f;
                state = PlayerState.invincibility;
                break;
            case ExecutionOrder.end:
                //올라가는 효과
                state = PlayerState.normal;
                lowFlyingState = ExecutionOrder.none;
                break;
        }
    }

    private void Boosting() //부스트
    {
        if (state == PlayerState.overload && boostingState == ExecutionOrder.execution) boostingState = ExecutionOrder.end;
        if (boostingState == ExecutionOrder.none) return;

        switch (boostingState)
        {
            case ExecutionOrder.standby:
                //부스터 효과
                speed = originSpeed * 2;
                boostingState = ExecutionOrder.execution;
                break;
            case ExecutionOrder.execution:
                fuelGauge.GaugeBar -= Time.deltaTime * 2f;
                break;
            case ExecutionOrder.end:
                speed = originSpeed;
                boostingState = ExecutionOrder.none;
                break;
        }
    }

    private void GaugeManagement() //게이지바 관리
    {
        if (!fuelGauge.Check()) //연료 게이지가 0으로 떨어졌을 경우
        {
            lowFlyingState = ExecutionOrder.end;
            lowFlyingState = ExecutionOrder.end;

            hpGauge.GaugeBar -= 10; //hp 게이지를 10 감소시키고
            fuelGauge.GaugeBar = fuelGauge.MaxGaugeBar; //연료 게이지를 꽉 채움

            state = PlayerState.overload; //과부하 상태 진입
        }
    }

    private void SetRotation()
    {
        transform.rotation = rot;
    }

    private void StateManagement()
    {
        switch (state)
        {
            case PlayerState.normal:
                //fuelGauge.GaugeBar += Time.deltaTime;
                break;
            case PlayerState.overload:
                StartCoroutine(Overload());
                break;
        }
    }

    private IEnumerator Overload() //과부하상태
    {
        speed = originSpeed / 2f;
        yield return new WaitForSeconds(5f);
        speed = originSpeed;
        state = PlayerState.normal;
    }


    public void GetDamage(float damage)
    {
        if (Invincibility || state == PlayerState.invincibility) return;
        hpGauge.GaugeBar -= damage;
        if (Invincibility) return;
        StartCoroutine(InvincibilityBuff(1.5f));
    }

    public IEnumerator InvincibilityBuff(float time)
    {
        float cool = 0;
        while (cool < time)
        {
            Invincibility = true;
            cool += Time.deltaTime;
            yield return new WaitForFixedUpdate();
            Debug.Log("무적");
        }
        Invincibility = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            GetDamage(other.GetComponent<Bullet>().GetDamage());
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            GetDamage(other.gameObject.GetComponent<Enemy>().DestructDamage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Boss"))
        {
            GetDamage(other.GetComponent<Boss>().DestructDamage);
        }
    }
}

public enum PlayerState
{
    normal,
    execution,
    invincibility,
    overload,
    breakdown,
}

public enum ExecutionOrder
{
    standby,
    execution,
    end,
    none
}