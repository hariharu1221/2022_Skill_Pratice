using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //SERIALIZEFIELD
    [SerializeField] private float originSpeed;
    [SerializeField] private float time;

    //VARIABLE
    [HideInInspector] public GaugePoint hpGauge;
    [HideInInspector] public GaugePoint fuelGauge;
    [HideInInspector] public PlayerState state;
    [HideInInspector] public Vector2 limit;
    [HideInInspector] public float yPos;
    [HideInInspector] public float speed;

    //INPUT
    [HideInInspector] public ExecutionOrder lowFlyingState;
    [HideInInspector] public ExecutionOrder boostingState;
    [HideInInspector] public Vector2 vec;

    private void Awake()
    {
        VariableSetting();
    }

    private void Update()
    {
        Movement();
        LowFlying();
        Boosting();
        Fire();
        GaugeManagement();
        StateManagement();
    }

    private void VariableSetting()
    {
        hpGauge   = new GaugePoint(10, 10);
        fuelGauge = new GaugePoint(20, 20);
        limit = new Vector2(100, 40);
        yPos = 20;
        speed = originSpeed;

        state = PlayerState.normal;
        lowFlyingState = ExecutionOrder.none;
        boostingState = ExecutionOrder.none;
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

        if (lowFlyingState == ExecutionOrder.none || state == PlayerState.overload)
        {
            transform.position = Vector3.Lerp(transform.position, pos + new Vector3(0, yPos, 0), Time.deltaTime); ;
            return;
        }

        switch(lowFlyingState)
        {
            case ExecutionOrder.standby:
                //내려가는 효과
                state = PlayerState.invincibility;
                lowFlyingState = ExecutionOrder.execution;
                break;
            case ExecutionOrder.execution:
                transform.position = Vector3.Lerp(transform.position, pos + new Vector3(0, -20, 0), Time.deltaTime);
                break;
            case ExecutionOrder.end:
                //올라가는 효과
                state = PlayerState.normal;
                lowFlyingState = ExecutionOrder.none;
                break;
        }

        fuelGauge.GaugeBar -= Time.deltaTime * 2f;
    }

    private void Boosting() //부스트
    {
        if (boostingState == ExecutionOrder.none || state == PlayerState.overload) return;

        switch (boostingState)
        {
            case ExecutionOrder.standby:
                //부스터 효과
                boostingState = ExecutionOrder.execution;
                break;
            case ExecutionOrder.execution:
                speed = originSpeed * 2;
                break;
            case ExecutionOrder.end:
                speed = originSpeed;
                boostingState = ExecutionOrder.none;
                break;
        }

        fuelGauge.GaugeBar -= Time.deltaTime * 2f;
    }

    private void Fire()
    {

    }

    private void GaugeManagement() //게이지바 관리
    {
        if (!fuelGauge.Check()) //연료 게이지가 0으로 떨어졌을 경우
        {
            lowFlyingState = ExecutionOrder.end;
            lowFlyingState = ExecutionOrder.end;

            hpGauge.GaugeBar -= 1; //hp 게이지를 1 감소시키고
            fuelGauge.GaugeBar = fuelGauge.MaxGaugeBar; //연료 게이지를 꽉 채움

            state = PlayerState.overload; //과부하 상태 진입
        }
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