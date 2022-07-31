using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;

public class MainMenuUI : MonoBehaviour
{
    public InputField nameInputField;
    public Text bestScoreText;

    private void Start()
    {
        BestScoreManager.instance.LoadRecord();
        bestScoreText.text = $"Best Score : {BestScoreManager.instance.recordBreakerName} : {BestScoreManager.instance.recordPoints}";
    }

    public void LoadMainScene()
    {
        BestScoreManager.instance.playerName = nameInputField.text;
        SceneManager.LoadScene(1);
    }

    public void ExitTheGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
