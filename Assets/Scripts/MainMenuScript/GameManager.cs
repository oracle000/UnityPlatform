using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private AudioSource audioSource;


    private bool IsOnBgMusic = true;
    private bool IsOnSFXMusic = true;
    private float bgMusic = 0;
    private float sfxMusic = 0;
    private int playerLife = 3;
    private int playerScore = 0;
    bool gameHasEnded = false;
    bool PlayBackgroundMusic;

    enum GameMode { MainMenu, Loading, Stage1, Stage2, Stage3};    

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

    public void UpdatePlayerLife(int life)
    {
        playerLife = playerLife - life;
    }

    public void UpdatePlayerScore(int score)
    {
        playerScore = playerScore + score;
    }
       
    public void GameOver()
    {
        if (gameHasEnded == false)
        {     
            gameHasEnded = true;                        
        }        
    }
    public void Restart()
    {        
        gameHasEnded = false;
        playerLife = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    

    public bool GetOnPlayBgMusic()
    {
        return IsOnBgMusic;
    }
    public void UpdateBGMusic(bool value)
    {     
        IsOnBgMusic = value;
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