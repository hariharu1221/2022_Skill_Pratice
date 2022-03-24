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

    private Player player;
    private PlayerSkillSystem skillSystem;

    private void Awake()
    {
        VariableSetting();
        KeySetting();
    }

    private void KeySetting() //input에 함수 대입
    {
        //LowFlying KeySetting
        lowFlying.started += ctx => player.lowFlyingState = ExecutionOrder.standby;
        lowFlying.canceled += ctx => player.lowFlyingState = ExecutionOrder.end;

        //Boosting KeySetting
        boosting.started += ctx => player.boostingState = ExecutionOrder.standby;
        boosting.canceled += ctx => player.boostingState = ExecutionOrder.end;
    }

    private void VariableSetting() //변수 세팅
    {
        //PLAYER INPUT
        input = new InputAction_Player();
        movement = input.PlayerControls.Movement;
        lowFlying = input.PlayerControls.LowFlying;
        boosting = input.PlayerControls.Boosting;

        //PLAYER COMPONENT
        player = GetComponent<Player>();
        skillSystem = GetComponent<PlayerSkillSystem>();
    }

    private void Update()
    {
        player.vec = movement.ReadValue<Vector2>();
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