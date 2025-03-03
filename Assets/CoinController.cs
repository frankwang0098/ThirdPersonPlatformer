using UnityEngine;
using UnityEngine.Events;

public class CoinController : MonoBehaviour
{
    public UnityEvent OnCoinCollect = new();
    [SerializeField] private float rotationSpeed = 90f;
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider triggeredObject)
    {
        // Check if the player collided
        if (triggeredObject.CompareTag("Player"))
        {
            OnCoinCollect?.Invoke();
            Destroy(gameObject);
        }
    }
}
