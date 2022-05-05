using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void StartGame(){ //start and restart game!
        SceneManager.LoadScene("Agario");
    }
    public void Disconnect(){
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame(){ 
        Application.Quit();
    }
}
