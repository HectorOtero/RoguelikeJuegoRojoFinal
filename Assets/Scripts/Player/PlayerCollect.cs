using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ICollectible collectible))
        {
            collectible.Collect();
        }
    }
}
