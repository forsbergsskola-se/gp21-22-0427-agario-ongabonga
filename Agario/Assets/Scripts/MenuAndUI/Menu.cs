using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void RestartGame(){ 
        SceneManager.LoadScene("Agario");
    }
    public void Disconnect(){
        SceneManager.LoadScene("AgarioMainMenu");
    }
    public void QuitGame(){ 
        Application.Quit();
    }
}
