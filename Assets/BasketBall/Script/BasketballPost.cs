using UnityEngine;
using Game.Framework;

public class BasketballPost : MonoBehaviour
{

    bool IsBallInside = false;
    public void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Ball"))
            return;

        Rigidbody ballRigidBody;
        other.TryGetComponent<Rigidbody>(out ballRigidBody);

        if (ballRigidBody == null)
            return;

        float dotValue = Vector3.Dot(-transform.up, ballRigidBody.velocity);
        if (dotValue > 0.5F)
            IsBallInside = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Ball"))
            return;

        Rigidbody ballRigidBody;
        other.TryGetComponent<Rigidbody>(out ballRigidBody);

        if (ballRigidBody == null || IsBallInside == false)
            return;

        float dotValue = Vector3.Dot(-transform.up, ballRigidBody.velocity);
        if (dotValue > 0.75F)
            ((Basketball_GameplayMode)GameManager.Instance.GameplayMode).AddScore(10);
    }
}