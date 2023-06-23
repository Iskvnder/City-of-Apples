using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
   public void PlayGame()
    {
        SceneManager.LoadScene("CoreAbdullaScene");
    }

    public void Authors()
    {
        SceneManager.LoadScene("AuthorsCutscene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    

}
