using UnityEngine;
using UnityEngine.Events;

public class CoinController : MonoBehaviour
{
    public UnityEvent OnCoinCollect = new();
    [SerializeField] private float rotationSpeed = 5;
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerEnter(Collider triggeredObject)
    {
        if (triggeredObject.CompareTag("Player"))
        {
            OnCoinCollect?.Invoke();
            Destroy(gameObject);
        }
    }
}
