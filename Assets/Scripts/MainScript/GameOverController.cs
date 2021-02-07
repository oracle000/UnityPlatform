using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{    

    public void MainMenu()
    {
        GameManager.instance.MainMenu();
    }
    public void Restart()
    {        
        GameManager.instance.Restart();
        GameManager.instance.SetEnableInput(true);
    }
}
