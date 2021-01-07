using UnityEngine;

public class MainMenuController : MonoBehaviour
{    
    
    private void Awake()
    {
        
    }

    void Start()
    {        
        // OnPlayBgMusic(adSource);
    }

    public void UpdateBackgroundMusic(bool value)
    {        
        FindObjectOfType<GameManager>().UpdateBGMusic(value);        
    }

    public void UpdateSFXMusic(bool value)
    {
        // Debug.Log(value);
    }
}
