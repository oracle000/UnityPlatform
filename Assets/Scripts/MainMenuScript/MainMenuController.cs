using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void UpdateBackgroundMusic(bool value)
    {        
        FindObjectOfType<GameManager>().UpdateBGMusic(value);        
    }

    public void UpdateSFXMusic(bool value)
    {

    }
}
