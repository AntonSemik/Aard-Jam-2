using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shovel : MonoBehaviour
{

    [SerializeField] InputAction onAttackInput;

    [SerializeField] Transform shovelModel;
    [SerializeField] AnimationCurve shovelSwipeCurve;
    [SerializeField] float swipeTime;

    [SerializeField] GameObject damageZone;

    private float swipeCurvePoint;
    private bool isSwiping = false;

    private void Awake()
    {
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
        damageZone.SetActive(true);

        shovelModel.localRotation = Quaternion.Euler(0, shovelSwipeCurve.Evaluate(swipeCurvePoint), 0);
    }

    void SwipeBlade()
    {
        swipeCurvePoint += Time.fixedDeltaTime / swipeTime;

        if (swipeCurvePoint >= 1)
        {
            damageZone.SetActive(false);

            swipeCurvePoint = 0;
            isSwiping = false;
        }

        shovelModel.localRotation = Quaternion.Euler(0, shovelSwipeCurve.Evaluate(swipeCurvePoint),0);
    }

    void OnAttackInput(InputAction.CallbackContext context)
    {
        StartAttack();
    }
}
