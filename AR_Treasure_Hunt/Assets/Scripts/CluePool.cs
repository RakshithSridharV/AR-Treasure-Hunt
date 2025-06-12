using UnityEngine;
using System.Collections.Generic;

public class CluePool : MonoBehaviour
{
    [Header("Pool Settings")]
    public GameObject cluePrefab;
    public int initialPoolSize = 10;

    private Queue<GameObject> poolQueue;

    private void Awake()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        poolQueue = new Queue<GameObject>();

        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject clue = Instantiate(cluePrefab, transform);
            clue.SetActive(false);
            poolQueue.Enqueue(clue);
        }
    }

    public GameObject GetClue(Vector3 position, Quaternion rotation)
    {
        GameObject clue;

        if (poolQueue.Count > 0)
        {
            clue = poolQueue.Dequeue();
            clue.transform.SetPositionAndRotation(position, rotation);
        }
        else
        {
            clue = Instantiate(cluePrefab, position, rotation, transform);
        }

        clue.SetActive(true);
        return clue;
    }

    public void ReturnClue(GameObject clue)
    {
        clue.SetActive(false);
        poolQueue.Enqueue(clue);
    }
}
