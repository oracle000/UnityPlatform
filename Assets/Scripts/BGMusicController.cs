using UnityEngine;

public class BGMusicController : MonoBehaviour
{

    private AudioSource ad;
    private static BGMusicController instance = null;
    private bool defaultBGMusic = true;
    private bool defaultSFXMusic = true;
    private static BGMusicController Instance
    {
        get { return instance; }
    }


    private void Start()
    {
        ad = GetComponent<AudioSource>();        
        if (FindObjectOfType<GameManager>().GetOnPlayBgMusic())
            ad.Play();        

        MakeSingleton();
    }

    private void Update()
    {        
        if (!FindObjectOfType<GameManager>().GetOnPlayBgMusic())
        {                   
            ad.Pause();
        }        
    }

    public void PlayBGMusic(bool value)
    {
        if (value)
        {
            FindObjectOfType<GameManager>().UpdateBGMusic(value);
            ad.Play();
        }
        
    }

    void MakeSingleton()
    {
        if (instance != null) Destroy(gameObject);

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
