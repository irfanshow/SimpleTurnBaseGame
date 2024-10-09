using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public GameObject howToPlayUI;
    public TextMeshProUGUI howToPlayDesc;
    [SerializeField][TextArea] string howToPlayText;
    GameManager gameManager;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        howToPlayDesc.text = howToPlayText;
    }
    public void showHowToPlay()
    {
        Time.timeScale = 0;
        StaticVariable.isPause = true;
        howToPlayUI.SetActive(true);
        gameManager.inGameUI.SetActive(false);
        gameManager.inGameObject.SetActive(false);


    }

    public void closeHowToPlay()
    {
        Time.timeScale = 1;
        StaticVariable.isPause = false;
        howToPlayUI.SetActive(false);
        gameManager.inGameUI.SetActive(true);
        gameManager.inGameObject.SetActive(true);
        
    }
}
