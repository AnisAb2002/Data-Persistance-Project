using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TMP_InputField inputField;

    private void Start()
    {
        inputField.text = MenuManager.instance.playerName;
        highScoreText.text = "High Score : " + MenuManager.instance.highScore;
    }

    private void LateUpdate()
    {
        if (inputField.text != MenuManager.instance.playerName)
        {
            MenuManager.instance.playerName = inputField.text;
            MenuManager.instance.SavingData();
        }

    }
    public void PlayButton()
    {
        SceneManager.LoadScene("main");
    }

    public void ExitButton()
    {
        EditorApplication.ExitPlaymode();
    }
}
