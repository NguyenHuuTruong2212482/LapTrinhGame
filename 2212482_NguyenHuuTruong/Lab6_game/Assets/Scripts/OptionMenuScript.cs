using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle soundToggle;

    public void ToggleSound(bool isOn)
    {
        AudioListener.pause = !isOn;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu"); 
    }
}

