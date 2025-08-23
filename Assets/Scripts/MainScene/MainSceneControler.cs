using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneControler : MonoBehaviour
{
    public void OnSinglePlayerClick()
    {
        SceneManager.LoadScene("SinglePlayer");
    }
}
