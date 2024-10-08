using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private string menuScene, MainScene;
    private MouseStateManager MSM;
    private MouseState prevousState;
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 1;
        isPaused = false;
        pauseScreen.SetActive(false);
        MSM = FindObjectOfType<MouseStateManager>();
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {

            PauseGame();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(MainScene);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        isPaused = true;
        prevousState = MSM.GetMouseState();
        MSM.SetMouseState(0);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        isPaused = false;
        switch (prevousState)
        {
            case MouseState.none:
                MSM.SetMouseState(0);
                break;
            case MouseState.drag:
                MSM.SetMouseState(1);
                break;
            case MouseState.clean:
                MSM.SetMouseState(2);
                break;
            case MouseState.cleanWeak:
                MSM.SetMouseState(3);
                break;
            case MouseState.cleanMedium:
                MSM.SetMouseState(4);
                break;
            case MouseState.cleanStrong:
                MSM.SetMouseState(5);
                break;
            case MouseState.delete:
                MSM.SetMouseState(6);
                break;
            default:
                MSM.SetMouseState(7);
                break;
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadWorldScene()
    {

        SceneManager.LoadScene("worldScene");
    }
}
