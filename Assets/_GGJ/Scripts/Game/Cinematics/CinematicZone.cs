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
        }
    }

    private void ShowCinematic()
    {
        GetComponent<BoxCollider>().enabled = false;
        onTrigger = false;

        player.GetComponent<RobotController>().canMove = false;

        if (interactionPosition)
        {
            player.DOMove(new Vector3(interactionPosition.position.x, player.position.y, interactionPosition.position.z), 1);
            player.DORotate(interactionPosition.eulerAngles, 1);
        }

        if (actionZone)
        {
            actionZone.ActivateZone();
        }

        cinematicDirector.Play();
    }

}
