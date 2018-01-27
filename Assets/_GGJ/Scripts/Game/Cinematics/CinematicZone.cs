using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using DG.Tweening;

public class CinematicZone : MonoBehaviour
{
    [SerializeField]
    private bool cinematicFinished;

    [SerializeField]
    private ActionZone actionZone;

    [SerializeField] private Transform interactionPosition;

    private Transform player;

    private PlayableDirector cinematicDirector;
    private bool onTrigger;

    private void Awake()
    {
        cinematicDirector = GetComponent<PlayableDirector>();
        player = GameManager.Instance.player;
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
        if (interactionPosition)
        {
            player.DOMove(interactionPosition.position, 1);
            player.DORotate(interactionPosition.eulerAngles, 1);
        }

        if (actionZone)
        {
            actionZone.ActivateZone();
        }

        cinematicDirector.Play();
    }

}
