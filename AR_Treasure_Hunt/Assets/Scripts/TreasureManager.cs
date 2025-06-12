using UnityEngine;

public class TreasureManager : MonoBehaviour
{
    public static TreasureManager Instance;

    [Header("Treasure Reference")]
    public GameObject treasureObject;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void RevealTreasure(Vector3 spawnPosition)
    {
        if (treasureObject != null)
        {
            treasureObject.transform.position = spawnPosition + new Vector3(0, 0.1f, 0); // small offset upward
            treasureObject.SetActive(true);
        }
    }

    public void ResetTreasure()
    {
        if (treasureObject != null)
        {
            treasureObject.SetActive(false);
        }
    }
}
