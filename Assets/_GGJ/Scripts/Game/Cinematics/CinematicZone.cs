using UnityEngine;
using UnityEngine.Playables;

public class CinematicZone : MonoBehaviour
{
    [SerializeField]
    private bool cinematicFinished;

    private PlayableDirector cinematicDirector;
    private bool onTrigger;

    private void Awake()
    {
        cinematicDirector = GetComponent<PlayableDirector>();
    }

    private void Update()
    {
        if (onTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            ShowCinematic();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onTrigger = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onTrigger = false;
            //TODO: Transition to Follow Camera
            //cinematicDirector.Play();
        }
    }

    private void ShowCinematic()
    {
        cinematicDirector.Play();
    }
}
