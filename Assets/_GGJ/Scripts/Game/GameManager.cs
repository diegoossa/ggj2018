
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public string currentLanguage = Languages.SPANISH;
    public Transform player;
    public bool canShowMap;
    public RobotController robot;

    private Camera mainCamera;
    public Animator cameraAnimator;


    private void Start()
    {
        mainCamera = Camera.main;
        robot = player.GetComponent<RobotController>();
        //cameraAnimator = mainCamera.GetComponent<Animator>();

        if (!player)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Glitch()
    {
        cameraAnimator.SetTrigger("Glitch");
    }
}
