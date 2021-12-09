using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Destroyer destr;
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject mainMenu;
    void Start()
    {
        startButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
        Time.timeScale = 0;
        destr.OnDestroyObj += RestartButtonActive;
        panelMenu.gameObject.SetActive(true);
        PlayerSatistic.Instance.ResetScore();
    }
    public void OnStart()
    {
        startButton.gameObject.SetActive(false);
        Time.timeScale = 1;
        panelMenu.gameObject.SetActive(false);
        PlayerSatistic.Instance.ResetHP();
    }
    public void RestartButtonActive()
    {
        Time.timeScale = 0;
        restartButton.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(true);
        panelMenu.gameObject.SetActive(true);
    }
    public void OnRestart()
    {
        restartButton.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        panelMenu.gameObject.SetActive(false);
        Time.timeScale = 1;

    }
    public void MainMenu()
    {
        Start();
    }
}
