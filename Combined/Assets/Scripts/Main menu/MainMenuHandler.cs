using UnityEngine;

namespace Main_menu
{
    public class MainMenuHandler : MonoBehaviour
    {
        public void EnterSnakeGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SnakeGame");
        }
        
        public void EnterSpringGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SpringGame");
        }
        
        public void EnterColoringGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("ColorGame");
        }
        
        public void CloseApplication()
        {
            Application.Quit();
        }
  
    }
}
