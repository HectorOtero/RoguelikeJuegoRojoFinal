using UnityEngine;

public class Experience : MonoBehaviour, ICollectible
{
    public int experienceGranted;
    public void Collect()
    {
        PlayerStats player = FindAnyObjectByType<PlayerStats>();
        player.IncreaseExperience(experienceGranted);
        Destroy(gameObject);
    }   
}
