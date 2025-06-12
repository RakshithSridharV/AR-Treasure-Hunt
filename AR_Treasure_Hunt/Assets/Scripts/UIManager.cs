using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TMP_Text hintText;
    public TMP_Text messageText;
    public TMP_Text scoreText;
    public TMP_Text progressText;
    public Button resetButton;
    public GameObject gameOverPanel;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        resetButton.onClick.AddListener(() => GameManager.Instance.ResetGame());
        gameOverPanel.SetActive(false);
    }

    public void ShowHint(string text)
    {
        hintText.text = "HINT: " + text;
        AnimateText(hintText);
    }

    public void ShowMessage(string text)
    {
        messageText.text = text;
        AnimateText(messageText);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "SCORE: " + score;
    }

    public void UpdateProgress(int current, int total)
    {
        progressText.text = $"CLUES: {current}/{total}";
    }

    public void ShowGameOver(int finalScore)
    {
        gameOverPanel.SetActive(true);
        gameOverPanel.GetComponentInChildren<TMP_Text>().text = $"GAME COMPLETE!\nFinal Score: {finalScore}";
    }

    public void HideGameOver() => gameOverPanel.SetActive(false);
    public void ClearHint() => hintText.text = "";
    public void ClearMessage() => messageText.text = "";

    void AnimateText(TMP_Text text)
    {
        CanvasGroup group = text.GetComponent<CanvasGroup>();
        if (!group) group = text.gameObject.AddComponent<CanvasGroup>();
        group.alpha = 1;
        LeanTween.alphaCanvas(group, 0, 3f).setDelay(5f);
    }
}