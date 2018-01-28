
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public string currentLanguage = Languages.SPANISH;
    public Transform player;
    public bool canShowMap;
    public RobotController robot;

    private Camera mainCamera;
    public Animator cameraAnimator;

    public int towersActivated = 0;

    public void ActivateTower()
    {
        towersActivated++;

        if (towersActivated >= 3)
        {
        }
    }

    private void Start()
    {
        mainCamera = Camera.main;
        robot = player.GetComponent<RobotController>();

        if (PlayerPrefs.HasKey("Language"))
        {
            currentLanguage = PlayerPrefs.GetString("Language");
        }
        else
        {
            currentLanguage = Languages.SPANISH;
        }
        //cameraAnimator = mainCamera.GetComponent<Animator>();

        if (!player)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Glitch()
    {
        cameraAnimator.SetTrigger("Glitch");
    }
}
