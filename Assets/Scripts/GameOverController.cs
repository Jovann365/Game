using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
   public void OnGameOverClick()
   {
      SceneManager.LoadScene("MainMenu");
   }
}
