using UnityEngine;
using UnityEngine.SceneManagement;

namespace SimpleScripts
{
    public class SceneHelper : MonoBehaviour
    {
        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadLevel(int buildIndex)
        {
            SceneManager.LoadScene(buildIndex);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }

}
