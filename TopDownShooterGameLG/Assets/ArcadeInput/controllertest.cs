using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class controllertest : MonoBehaviour
{
    ControllerActions inputActions;
    Vector2 movement;
    public int times;
    void Awake()
    {
        inputActions = new ControllerActions();

        inputActions.gamingActionMap.movement.performed += context => movement = context.ReadValue<Vector2>(); // movement is set to the thumbstick value
        inputActions.gamingActionMap.movement.canceled += context => movement = Vector2.zero;
    }

    void Update()
    {
        //Vector2 newMovement = new Vector2(movement.x, movement.y) * Time.deltaTime;
        Vector2 newRotation = new Vector2(movement.y, -movement.x) * times * Time.deltaTime;
        transform.Rotate(newRotation, Space.World);
        Debug.Log(movement.y);
    }

    private void OnEnable()
    {
        inputActions.gamingActionMap.Enable();
    }
    private void OnDisable()
    {
        inputActions.gamingActionMap.Disable();
    }
}
