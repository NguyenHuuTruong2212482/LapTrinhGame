using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void Options()
    {
        SceneManager.LoadScene("OptionMenu");
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game closed"); 
    }
}