using UnityEngine;

public class OnTriggerMusic : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            source.clip = clip;
            source.Play();
            gameObject.SetActive(false);
        }
    }
}
