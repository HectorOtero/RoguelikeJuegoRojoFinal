using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
   public enum GameState
    {
        Gameplay,
        Pause,
        GameOver
    }

    public GameState state;
    public GameState previousState;

    public GameObject PanelPausa;

    public GameObject PanelGameOver;

    public bool isGameOver = false;

    float watchtime;
    public Text watchdisplay;


    void Awake()
    {
        PanelPausa.SetActive(false);
        PanelGameOver.SetActive(false);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Extra" + this + "Deleted");
        }
    }

    private void Update()
    {
        switch(state)
        {
            case GameState.Gameplay:
                Watch();
                break; 
            case GameState.Pause:
                break;
            case GameState.GameOver:
                if (!isGameOver)
                {
                    isGameOver = true;
                }
                break;

                default:
                Debug.Log("State does not exist");
                break;
        }
    }

    public void ChangeState(GameState newState)
    {
        state = newState;
    }

    public void PausedGame()
    {
        if (state != GameState.Pause) 
        {
            previousState = state;
            ChangeState(GameState.Pause);
            Time.timeScale = 0;
            PanelPausa.SetActive(true);
        }
        
    }

    public void ResumeGame()
    {
        if (state == GameState.Pause)
        {
            ChangeState(previousState);
            Time.timeScale = 1f;
            PanelPausa.SetActive(false);
        }
        
    }

    public void GameOver()
    {
        ChangeState(GameState.GameOver);
        PanelGameOver.SetActive(true);
    }

    void Watch()
    {
        watchtime += Time.deltaTime;
        WatchDisplay();
    }

    void WatchDisplay()
    {
        int minutes = Mathf.FloorToInt(watchtime / 60);
        int seconds = Mathf.FloorToInt(watchtime % 60);

        watchdisplay.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
 