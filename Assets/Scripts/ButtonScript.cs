using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    //[SerializeField] Button restart;
    //[SerializeField] Button exit;

    public void Restart()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void ExitGame()
    {
        Debug.Log("game over");
        Application.Quit();
    }
}
