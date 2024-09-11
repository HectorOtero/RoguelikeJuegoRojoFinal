using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void CambiarAScena(string nombreDeLaEscena)
    {
        SceneManager.LoadScene(nombreDeLaEscena);
        Time.timeScale = 1.0f;
    }

    public void RegresarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgain()
    {
        SceneManager.GetActiveScene();
    }
}

