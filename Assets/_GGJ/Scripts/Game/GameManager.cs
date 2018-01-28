
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public string currentLanguage = Languages.SPANISH;
    public Transform player;

    private Camera mainCamera;
    public Animator cameraAnimator;


    private void Start()
    {
        mainCamera = Camera.main;
        //cameraAnimator = mainCamera.GetComponent<Animator>();

        if (!player)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Glitch()
    {
        cameraAnimator.SetTrigger("Glitch");
    }
}
