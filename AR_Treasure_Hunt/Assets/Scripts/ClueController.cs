using UnityEngine;

public class ClueController : MonoBehaviour
{
    [Header("Clue Settings")]
    public GameObject nextCluePrefab;
    public int clueScore = 100;
    public ParticleSystem clueEffect;
    public string clueHint;

    private bool clueCollected = false;

    private void Start()
    {
        UIManager.Instance?.ShowHint(clueHint);
    }

    private void Update()
    {
        if (clueCollected) return;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    OnClueCollected();
                }
            }
        }
    }

    private void OnClueCollected()
    {
        clueCollected = true;

        if (clueEffect != null)
        {
            clueEffect.Play();
        }

        GameManager.Instance?.AddScore(clueScore);
        GameManager.Instance?.IncrementClue();

        if (nextCluePrefab != null)
        {
            Vector3 offset = new Vector3(Random.Range(1f, 2f), 0.1f, Random.Range(1f, 2f));
            GameObject nextClue = Instantiate(nextCluePrefab, transform.position + offset, Quaternion.identity);

            ClueController cc = nextClue.GetComponent<ClueController>();
            if (cc != null)
                UIManager.Instance?.ShowHint(cc.clueHint);
        }
        else
        {
            TreasureManager.Instance?.RevealTreasure(transform.position);
            GameManager.Instance?.GameOver();
            UIManager.Instance?.ClearHint();
            UIManager.Instance?.ShowMessage("Treasure Revealed!");
        }

        // Hide visual immediately, destroy object after delay to allow effect to play
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
            r.enabled = false;

        foreach (Collider c in GetComponentsInChildren<Collider>())
            c.enabled = false;

        Destroy(gameObject, 3f); // Give extra delay for particle to fully play
    }


}
