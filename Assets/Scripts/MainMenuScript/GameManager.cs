using System.Collections;
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
    private bool _enableInput = false;
    private bool PlayBackgroundMusic;


    private bool _isLeftKeyPressed = false;
    private bool _isRightKeyPressed = false;
    private bool _isJumpKeyPressed = false;

    private enum GameMode { MainMenu, Loading, Stage1, Stage2, Stage3};    

    private void Awake()
    {
        MakeSingleton();
    }

    private void Start()
    {
        bgMusic = 1f;
        _enableInput = true;
    }

    public float BackgroundMusic()
    {
        return bgMusic;
    }

    public float SFXMusic()
    {
        return sfxMusic;
    }
    public bool GetEnableInput()
    {
        return _enableInput;
    }

    public void SetEnableInput(bool value)
    {
        _enableInput = value;
    }

    public bool GetLeftKeyPressed()
    {
        return _isLeftKeyPressed;
    }

    public void UpdateLeftKeyPressed(bool value)
    {        
        _isLeftKeyPressed = value;
    }

    public bool GetRightKeyPressed()
    {
        return _isRightKeyPressed;
    }

    public void UpdateRightKeyPressed(bool value)
    {
        _isRightKeyPressed = value;
    }

    public bool GetJumpKeyPressed()
    {
        return _isJumpKeyPressed;
    }
    public void UpdateJumpKeyPressed(bool value)
    {
        _isJumpKeyPressed = value;
    }


    public void PlayerStop()
    {
        _isRightKeyPressed = false;
        _isLeftKeyPressed = false;
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

    public void MainMenu()
    {
        playerScore = 0;
        playerLife = 3;
        _enableInput = true;
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {        
        playerScore = 0;
        playerLife = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void DisplayLevel1()
    {
        SceneManager.LoadScene(1);
        StartCoroutine(WaitReturnLevel(2, "level1"));
    }

    public void DisplayLevel2()
    {
        Debug.Log("ere");
        SceneManager.LoadScene(1);
        StartCoroutine(WaitReturnLevel(2, "level2"));
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

    IEnumerator WaitReturnLevel(float value, string type)
    {
        yield return new WaitForSeconds(value);

        SceneManager.LoadScene(type == "level1" ? 2 : 3);
    }
}