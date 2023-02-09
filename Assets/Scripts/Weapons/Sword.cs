using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sword : MonoBehaviour
{

    [SerializeField] InputAction onAttackInput;

    [SerializeField] AnimationCurve bladeSwipeCurve;
    [SerializeField] float swipeTime;


    private Transform bladeTransform;
    private float swipeCurvePoint;
    private bool isSwiping = false;

    private void Awake()
    {
        bladeTransform = GetComponent<Transform>();

        onAttackInput.Enable();
        onAttackInput.performed += OnAttackInput;
    }

    private void OnDestroy()
    {
        onAttackInput.performed -= OnAttackInput;
        onAttackInput.Disable();
    }

    private void FixedUpdate()
    {
        if (isSwiping)
        {
            SwipeBlade();
        }
    }

    void StartAttack()
    {
        if (isSwiping) return; isSwiping = true;

        swipeCurvePoint = 0;

        bladeTransform.localRotation = Quaternion.Euler(0, bladeSwipeCurve.Evaluate(swipeCurvePoint), 0);
    }

    void SwipeBlade()
    {
        swipeCurvePoint += Time.fixedDeltaTime / swipeTime;

        if (swipeCurvePoint >= 1)
        {
            swipeCurvePoint = 0;
            isSwiping = false;
        }

        bladeTransform.localRotation = Quaternion.Euler(0, bladeSwipeCurve.Evaluate(swipeCurvePoint),0);
    }

    void OnAttackInput(InputAction.CallbackContext context)
    {
        StartAttack();
    }
}
