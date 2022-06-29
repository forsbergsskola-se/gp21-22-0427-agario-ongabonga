using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AgarioShared
{
    public class StartGame : MonoBehaviour
    {
        [SerializeField] TMP_InputField playerNameInput;
        
        public void GameStart() {
            ServerConnection.Instance.Connect(playerNameInput.text);
            SceneManager.LoadScene("Agario");
        }
    }
}

