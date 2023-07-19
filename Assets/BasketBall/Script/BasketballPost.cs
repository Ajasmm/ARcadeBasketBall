using UnityEngine;
using Game.Framework;

public class BasketballPost : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Ball"))
            return;

        Rigidbody ballRigidBody;
        other.TryGetComponent<Rigidbody>(out ballRigidBody);

        if (ballRigidBody == null)
            return;

        float dotValue = Vector3.Dot(-transform.up, ballRigidBody.velocity);
        if (dotValue > 0.75F)
        {
            ((Basketball_GameplayMode)GameManager.Instance.GameplayMode).AddScore(10);
        }
    }
}