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

    private void Movement() //������
    {
        transform.position += new Vector3(vec.x, 0, vec.y) * Time.deltaTime * speed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -limit.x, limit.x),
            transform.position.y, Mathf.Clamp(transform.position.z, -limit.y, limit.y));
    }

    private void LowFlying() //��������
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
                //�������� ȿ��
                state = PlayerState.invincibility;
                lowFlyingState = ExecutionOrder.execution;
                break;
            case ExecutionOrder.execution:
                transform.position = Vector3.Lerp(transform.position, pos + new Vector3(0, -20, 0), Time.deltaTime);
                break;
            case ExecutionOrder.end:
                //�ö󰡴� ȿ��
                state = PlayerState.normal;
                lowFlyingState = ExecutionOrder.none;
                break;
        }

        fuelGauge.GaugeBar -= Time.deltaTime * 2f;
    }

    private void Boosting() //�ν�Ʈ
    {
        if (boostingState == ExecutionOrder.none || state == PlayerState.overload) return;

        switch (boostingState)
        {
            case ExecutionOrder.standby:
                //�ν��� ȿ��
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

    private void GaugeManagement() //�������� ����
    {
        if (!fuelGauge.Check()) //���� �������� 0���� �������� ���
        {
            lowFlyingState = ExecutionOrder.end;
            lowFlyingState = ExecutionOrder.end;

            hpGauge.GaugeBar -= 1; //hp �������� 1 ���ҽ�Ű��
            fuelGauge.GaugeBar = fuelGauge.MaxGaugeBar; //���� �������� �� ä��

            state = PlayerState.overload; //������ ���� ����
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

    private IEnumerator Overload() //�����ϻ���
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