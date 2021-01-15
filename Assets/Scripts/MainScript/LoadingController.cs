using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{

    private Animator anim;
    void Start()
    {        
        anim = GetComponent<Animator>();
        anim.SetInteger("state", 0);

        StartCoroutine(SetTimeout(1.5f));        
    }


    IEnumerator SetTimeout(float value)
    {
        yield return new WaitForSeconds(value);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
