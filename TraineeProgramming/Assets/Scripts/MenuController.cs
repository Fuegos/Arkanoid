using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject ResultGameText;
    public GameObject StartGameText;

   
    void Start()
    {
        ResultGameText.GetComponent<Text>().text = FrontGUIController.Result;
        StartGameText.GetComponent<Text>().text = FrontGUIController.StatusGame;

    }

    
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
