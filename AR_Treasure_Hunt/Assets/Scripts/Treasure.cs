using UnityEngine;

public class Treasure : MonoBehaviour
{
    [Header("Treasure Effects")]
    public ParticleSystem revealEffect;
    public AudioClip revealSound;
    public float destroyDelay = 3f;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.spatialBlend = 1f;
        }
    }

    public void Reveal()
    {
        gameObject.SetActive(true);
        revealEffect?.Play();

        if (revealSound != null)
            audioSource.PlayOneShot(revealSound);
    }
}
