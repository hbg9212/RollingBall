using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;
    protected readonly PlayerGroundData groundData;

    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        stateMachine = playerStateMachine;
        groundData = stateMachine.Player.Data.GroundedData;
    }

    public virtual void Enter()
    {
        AddInputActionsCallbacks();
    }

    public virtual void Exit()
    {
        RemoveInputActionsCallbacks();
    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Update()
    {
        Move();
    }

    private void ReadMovementInput()
    {
        stateMachine.MovementInput = stateMachine.Player.Input.PlayerActions.Move.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();

        Rotate(movementDirection);

        Move(movementDirection);
    }

    private Vector3 GetMovementDirection()
    {
        Vector3 forward = stateMachine.MainCameraTransform.forward;
        Vector3 right = stateMachine.MainCameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        return forward * stateMachine.MovementInput.y + right * stateMachine.MovementInput.x;
    }

    private void Move(Vector3 movementDirection)
    {
        float movementSpeed = GetMovemenetSpeed();
        stateMachine.Player.Controller.Move(
            ((movementDirection * movementSpeed)
            + stateMachine.Player.ForceReceiver.Movement)
            * Time.deltaTime
            );
    }

    protected void ForceMove()
    {
        stateMachine.Player.Controller.Move(stateMachine.Player.ForceReceiver.Movement * Time.deltaTime);
    }

    private void Rotate(Vector3 movementDirection)
    {
        if (movementDirection != Vector3.zero)
        {
            Transform playerTransform = stateMachine.Player.transform;
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, stateMachine.RotationDamping * Time.deltaTime);
        }
    }

    private float GetMovemenetSpeed()
    {
        float movementSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
        return movementSpeed;
    }

    protected void StartAnimation(int animationHash)
    {

    }

    protected void StopAnimation(int animationHash)
    {

    }

    protected virtual void AddInputActionsCallbacks()
    {
        PlayerInput input = stateMachine.Player.Input;
        input.PlayerActions.Move.canceled += OnMovementCanceled;
        input.PlayerActions.Run.started += OnRunStarted;
        input.PlayerActions.ESC.started += OnEscStarted;

        stateMachine.Player.Input.PlayerActions.Jump.started += OnJumpStarted;

    }

    protected virtual void RemoveInputActionsCallbacks()
    {
        PlayerInput input = stateMachine.Player.Input;
        input.PlayerActions.Move.canceled -= OnMovementCanceled;
        input.PlayerActions.Run.started -= OnRunStarted;
        input.PlayerActions.ESC.started -= OnEscStarted;

        stateMachine.Player.Input.PlayerActions.Jump.started -= OnJumpStarted;
    }

    protected virtual void OnJumpStarted(InputAction.CallbackContext context)
    {

    }

    protected virtual void OnRunStarted(InputAction.CallbackContext context)
    {

    }

    protected virtual void OnMovementCanceled(InputAction.CallbackContext context)
    {

    }

    protected virtual void OnEscStarted(InputAction.CallbackContext context)
    {
        
    }

    protected float GetNormalizedTime(Animator animator, string tag)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

        if (animator.IsInTransition(0) && nextInfo.IsTag(tag))
        {
            return nextInfo.normalizedTime;
        }
        else if (!animator.IsInTransition(0) && currentInfo.IsTag(tag))
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0f;
        }
    }
}