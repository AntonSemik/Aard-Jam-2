using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction moveVectorInputAction;
    Vector2 moveInput;

    [SerializeField] float speedBase;
    [SerializeField] float speedPerMultiplier = 1;
    int currentScoreMultiplier = 1;

    Rigidbody RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();

        moveVectorInputAction.Enable();
        moveVectorInputAction.performed += OnMoveVectorInput;
        moveVectorInputAction.canceled += OnMoveVectorInput;

        Score.onScoreMultiplierChanged += ScoreMultiplierChanged;
    }

    private void Update()
    {
        Move();
    }

    private void OnDestroy()
    {
        moveVectorInputAction.performed -= OnMoveVectorInput;
        moveVectorInputAction.canceled -= OnMoveVectorInput;
        moveVectorInputAction.Disable();

        Score.onScoreMultiplierChanged -= ScoreMultiplierChanged;
    }

    private void Move()
    {
        RB.AddForce(new Vector3(moveInput.x,0,moveInput.y).normalized * (speedBase + speedPerMultiplier * currentScoreMultiplier));
    }

    void OnMoveVectorInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void ScoreMultiplierChanged(int value)
    {
        currentScoreMultiplier = value - 1;
    }
}
