using UnityEngine;

public class BotonPausa : MonoBehaviour
{
    GameManager gameManager;
    public void Pausa()
    {
        gameManager.PausedGame();
    }
}
