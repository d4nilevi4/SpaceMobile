using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceMobile
{
    public class GameOverMenu : MonoBehaviour
    {
        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
