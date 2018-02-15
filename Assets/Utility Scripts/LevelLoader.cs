using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    [SerializeField]
    [Tooltip ("THe delay in seconds before loading the main menu.")]
    private float splashDelay = 1f;

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Invoke("LoadNextScene", splashDelay);
        }
    }

    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
