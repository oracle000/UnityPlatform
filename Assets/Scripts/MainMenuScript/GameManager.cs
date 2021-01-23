using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private AudioSource audioSource;


    private bool _isOnBgMusic = true;
    private bool _isOnSfxMusic = true;
    private float bgMusic = 0;
    private float sfxMusic = 0;
    private int playerLife = 3;
    private int playerScore = 0;
    private bool _GamePauseOrStop = false;
    private bool PlayBackgroundMusic;

    private enum GameMode { MainMenu, Loading, Stage1, Stage2, Stage3};    

    private void Awake()
    {
        MakeSingleton();
    }

    private void Start()
    {
        bgMusic = 1f;        
    }

    public float BackgroundMusic()
    {
        return bgMusic;
    }

    public float SFXMusic()
    {
        return sfxMusic;
    }

    public int GetPlayerLife()
    {
        return playerLife;
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

    public bool GetGamePauseOrStop()
    {
        return _GamePauseOrStop;
    }

    public void IsGamePauseOrStop()
    {
        _GamePauseOrStop = true;
    }

    public void IsGameResume()
    {
        _GamePauseOrStop = false;
    }


    public void UpdatePlayerLife(int life)
    {
        playerLife -= life;
    }

    public void UpdatePlayerScore(int score)
    {
        playerScore += score;
    }
       
    public void GameOver()
    {
    }

    public void PitFall(int life)
    {
        playerLife -= life;
    }
    public void Restart()
    {
        playerLife = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    

    public bool GetOnPlayBgMusic()
    {
        return _isOnBgMusic;
    }
    public void UpdateBGMusic(bool value)
    {     
        _isOnBgMusic = value;
    }

    public void OnPlayBgMusic(AudioSource audio)
    {          
        PlayBackgroundMusic = true;
    }

    public void OnStopBgMusic(AudioSource audio)
    {
        audio.Pause();
        PlayBackgroundMusic = false;
    }

    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }  
}