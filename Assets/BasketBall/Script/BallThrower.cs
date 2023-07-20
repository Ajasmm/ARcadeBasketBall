using Game.Framework;
using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallThrower : MonoBehaviour
{
    [SerializeField] float minForce;
    [SerializeField] float maxForce;
    public float intencityChangeSpeed = 1;

    [SerializeField] BasketBall ball;

    public float intencity { get; private set; }
    public float sinValue { get; private set; }

    float angle = 0;

    MyInput input;
    Basketball_GameplayMode gameplayMode;

    private void Start()
    {
        input = new MyInput();
        input.Gameplay.Enable();

        input.Gameplay.Throw.performed += Throw;
    }
    private void OnDestroy()
    {
        input.Gameplay.Throw.performed -= Throw;
    }


    private void Update()
    {
        if(gameplayMode == null)
        {
            try
            {
                gameplayMode = (Basketball_GameplayMode)GameManager.Instance.GameplayMode;
            }
            catch (Exception e)
            {
                return;
            }
        }
        if (!gameplayMode.isPlaying)
            return;

        // calculate the Intencity
        angle += Time.deltaTime * intencityChangeSpeed;
        angle %= (2 * MathF.PI);
        sinValue = MathF.Sin(angle);

        intencity = math.remap(-1, 1, 0, 1, sinValue);

    }

    public void Throw(InputAction.CallbackContext context)
    {
        Debug.Log("Inside Throw");
        if(!BasketBall.IsBallDown)
            return;

        Debug.Log("Resetting");
        ResetBall();

        Vector3 throwDirection = transform.forward;
        throwDirection.Normalize();

        ball.ThrowBall(throwDirection * Mathf.Lerp(minForce, maxForce, intencity));
        Debug.Log("Throw called");
    }
    public void ResetBall()
    {
        ball.ResetBall(transform.position, transform.rotation);
    }
}
