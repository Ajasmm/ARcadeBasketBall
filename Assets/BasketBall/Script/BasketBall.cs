using UnityEngine;

public class BasketBall : MonoBehaviour
{
    [SerializeField] Rigidbody rBody;
    [SerializeField] float ResetTimer = 3;

    float tempTimer = 0;

    public static bool IsBallDown = true;
    private void Start()
    {
       ResetBall(Vector3.zero, Quaternion.identity);
    }
    private void Update()
    {
        if (!IsBallDown)
        {
            tempTimer += Time.deltaTime;
            if (tempTimer > ResetTimer)
                IsBallDown = true;
        }
    }
    public void ThrowBall(Vector3 force)
    {
        rBody.isKinematic = false;
        IsBallDown = false;
        rBody.AddForce(force, ForceMode.Impulse);

    }
    public void ResetBall(Vector3 position, Quaternion rotation)
    {
        rBody.isKinematic = true;
        rBody.position = position;
        rBody.rotation = rotation;
        IsBallDown = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
            IsBallDown = true;
    }
}
