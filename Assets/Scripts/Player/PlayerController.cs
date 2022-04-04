using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction_Player input;
    private InputAction movement;
    private InputAction lowFlying;
    private InputAction boosting;
    private InputAction targeting;

    private Player player;
    private PlayerSkillSystem skillSystem;
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject targetImage;

    private bool targetReset = true;

    private void Awake()
    {
        VariableSetting();
        KeySetting();
        camera = Camera.main;
    }

    private void KeySetting() //input에 함수 대입
    {
        //LowFlying KeySetting
        lowFlying.started += ctx => player.lowFlyingState = ExecutionOrder.standby;
        lowFlying.canceled += ctx => player.lowFlyingState = ExecutionOrder.end;

        //Boosting KeySetting
        boosting.started += ctx => player.boostingState = ExecutionOrder.standby;
        boosting.canceled += ctx => player.boostingState = ExecutionOrder.end;

        //mouse point
        targeting.started += ctx => targetReset = !targetReset;
    }

    private void VariableSetting() //변수 세팅
    {
        //PLAYER INPUT
        input = new InputAction_Player();
        movement = input.PlayerControls.Movement;
        lowFlying = input.PlayerControls.LowFlying;
        boosting = input.PlayerControls.Boosting;
        targeting = input.PlayerControls.Targeting;

        //PLAYER COMPONENT
        player = GetComponent<Player>();
        skillSystem = GetComponent<PlayerSkillSystem>();
    }

    private Vector3 originPos = Vector3.zero;
    public Vector3 GetTargetingPos(bool reset = true)
    {
        Vector3 tran = Vector3.zero;
        if (reset)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
                tran = raycastHit.point;
            originPos = tran;
        }
        else
        {
            tran = originPos;
        }

        return tran;
    }

    public Quaternion GetTargetLookAt(Vector3 origin, bool reset = true)
    {
        Vector3 target = GetTargetingPos(reset);
        Vector3 rot = target - origin;
        rot.y = 0;
        return Quaternion.LookRotation(rot.normalized);
    }

    private void Update()
    {
        player.vec = movement.ReadValue<Vector2>();
        player.rot = GetTargetLookAt(transform.position, targetReset);
        targetImage.transform.position = GetTargetingPos(false);
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}


//movement => wasd
//lowflying => ctrl
//boosting => leftshift
//fire => space
//