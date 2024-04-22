using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button exitButton;
    public Button againButton;
    public GameObject resultGameText;

    void Start()
    {
        Button btn = exitButton.GetComponent<Button>();
        btn.onClick.AddListener(exitOnClick);

        btn = againButton.GetComponent<Button>();
        btn.onClick.AddListener(againOnClick);

        resultGameText.GetComponent<Text>().text = PlayerPrefs.GetString("result");
    }

    public void againOnClick()
    {
        SceneManager.LoadScene("Main");
    }

    public void exitOnClick()
    {
        Application.Quit();
    }
}
