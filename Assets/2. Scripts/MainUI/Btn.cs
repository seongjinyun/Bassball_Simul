using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Btn : MonoBehaviour
{
    public Button startBtn;
    public Button exitBtn;
    public Button infoBtn;
    public GameObject infoPanel;

    void Start()
    {
        startBtn.onClick.AddListener(StartGame);
        exitBtn.onClick.AddListener(ExitGame);
        infoBtn.onClick.AddListener(ShowInfo);

        // ���� ���� ���� �� ����
        infoPanel.SetActive(false);
    }

    void StartGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    void ExitGame()
    {
        Application.Quit();
    }

    void ShowInfo()
    {
        infoPanel.SetActive(true);
        StartCoroutine(HideInfoAfterSeconds(5));
    }

    IEnumerator HideInfoAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        infoPanel.SetActive(false);
    }
}
