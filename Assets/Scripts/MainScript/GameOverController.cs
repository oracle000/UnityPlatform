using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{    

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        FindObjectOfType<GameManager>().Restart();
    }
}
