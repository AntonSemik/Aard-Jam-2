using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public InputAction OnShootInputAction; float shootInput;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform gunpoint;

    [SerializeField] float reloadTimeBase = 1f;
    [SerializeField] float timeFactorPerMultiplier = 0.2f;
    int currentScoreMultiplier = 1;

    float timeToNextShot = 0; bool isLoaded;

    Queue<GameObject> bulletQueue = new Queue<GameObject>();
    int poolSize = 20;
    GameObject tempObject;

    private void Start()
    {
        if(bullet == null)
        {
            Debug.LogError("Gun projectile not found");
            gameObject.SetActive(false);
        }

        SetPool();
        
        OnShootInputAction.Enable();
        OnShootInputAction.performed += OnShootInput;
        OnShootInputAction.canceled += ResetShootInput;

        Score.onScoreMultiplierChanged += ScoreMultiplierChanged;
    }

    private void Update()
    {
        if (!isLoaded)
        {
            timeToNextShot -= Time.deltaTime * (1 + timeFactorPerMultiplier * currentScoreMultiplier);
            if(timeToNextShot <= 0) isLoaded = true;
        }

        if(shootInput > 0 && isLoaded)
        {
            Shoot();

            timeToNextShot = reloadTimeBase; isLoaded = false;
        }
    }

    private void OnDestroy()
    {
        OnShootInputAction.performed -= OnShootInput;
        OnShootInputAction.canceled -= ResetShootInput;

        OnShootInputAction.Disable();

        Score.onScoreMultiplierChanged -= ScoreMultiplierChanged;
    }

    private void SetPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            tempObject = Instantiate(bullet);
            tempObject.SetActive(false);

            bulletQueue.Enqueue(tempObject);
        }
    }

    private void Shoot()
    {
        tempObject = bulletQueue.Dequeue();
        bulletQueue.Enqueue(tempObject);

        tempObject.transform.position = gunpoint.position;
        tempObject.transform.rotation = gunpoint.rotation;

        tempObject.SetActive(true);
    }

    private void OnShootInput(InputAction.CallbackContext context)
    {
        shootInput = context.ReadValue<float>();
    }

    private void ResetShootInput(InputAction.CallbackContext context)
    {
        shootInput = 0;
    }

    void ScoreMultiplierChanged(int value)
    {
        currentScoreMultiplier = value;
    }
}
