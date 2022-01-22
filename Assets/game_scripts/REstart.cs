using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class REstart : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("PlayMode");
    }

    public void main()
    {
        SceneManager.LoadScene("MainManu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
