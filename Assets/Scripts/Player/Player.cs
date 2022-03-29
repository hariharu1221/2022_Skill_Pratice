using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    #region VARIABLE
    //SERIALIZEFIELD
    [SerializeField] private float originSpeed;
    [SerializeField] private float time;
    [Header("�ҷ� ����")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDamage;
    [SerializeField] private float bulletCool;

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

    private BulletShooter shooter;

    //CONST
    public Vector2 limit { get { return new Vector2(80, 40); } }

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
    }

    private void VariableSetting()
    {
        hpGauge   = new GaugePoint(100, 100);
        fuelGauge = new GaugePoint(20, 20);
        painGauge = new GaugePoint(100, 0);
        yPos = 20;
        speed = originSpeed;

        state = PlayerState.normal;
        lowFlyingState = ExecutionOrder.none;
        boostingState = ExecutionOrder.none;

        shooter = GetComponent<BulletShooter>();
        shooter.Set(bulletCool, bulletSpeed, bulletDamage);
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

        if (state == PlayerState.overload) lowFlyingState = ExecutionOrder.none;
        if (lowFlyingState == ExecutionOrder.none)
        {
            transform.position = Vector3.Lerp(transform.position, pos + new Vector3(0, yPos, 0), Time.deltaTime * 5);
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
                transform.position = Vector3.Lerp(transform.position, pos + new Vector3(0, -20, 0), Time.deltaTime * 5);
                fuelGauge.GaugeBar -= Time.deltaTime * 4f;
                break;
            case ExecutionOrder.end:
                //�ö󰡴� ȿ��
                state = PlayerState.normal;
                lowFlyingState = ExecutionOrder.none;
                break;
        }
    }

    private void Boosting() //�ν�Ʈ
    {
        if (state == PlayerState.overload && boostingState == ExecutionOrder.execution) boostingState = ExecutionOrder.end;
        if (boostingState == ExecutionOrder.none) return;

        switch (boostingState)
        {
            case ExecutionOrder.standby:
                //�ν��� ȿ��
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

    private void GaugeManagement() //�������� ����
    {
        if (!fuelGauge.Check()) //���� �������� 0���� �������� ���
        {
            lowFlyingState = ExecutionOrder.end;
            lowFlyingState = ExecutionOrder.end;

            hpGauge.GaugeBar -= 10; //hp �������� 10 ���ҽ�Ű��
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