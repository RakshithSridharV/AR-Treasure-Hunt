using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Settings")]
    public int startingScore = 0;
    public int totalClues = 4;

    private int currentScore;
    private int currentClueCount;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        ResetGame();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        UIManager.Instance?.UpdateScore(currentScore);
    }

    public void IncrementClue()
    {
        currentClueCount++;
        UIManager.Instance?.UpdateProgress(currentClueCount, totalClues);
    }

    public void GameOver()
    {
        UIManager.Instance?.ShowGameOver(currentScore);
    }

    public void ResetGame()
    {
        currentScore = startingScore;
        currentClueCount = 0;

        UIManager.Instance?.UpdateScore(currentScore);
        UIManager.Instance?.UpdateProgress(currentClueCount, totalClues);
        UIManager.Instance?.ClearHint();
        UIManager.Instance?.ClearMessage();
        UIManager.Instance?.HideGameOver();

        foreach (var clue in GameObject.FindGameObjectsWithTag("Clue"))
            Destroy(clue);

        foreach (var treasure in GameObject.FindGameObjectsWithTag("Treasure"))
            Destroy(treasure);

        TreasureManager.Instance?.ResetTreasure();
        PlacementManager.Instance?.ResetPlacement();
    }
}