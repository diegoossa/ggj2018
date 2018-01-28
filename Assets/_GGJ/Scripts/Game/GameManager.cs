
using System.Collections;
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
            StartCoroutine(WhenActivate3Towers());
        }
    }

    private IEnumerator WhenActivate3Towers()
    {
        yield return new WaitForSeconds(3f);
        DialogueController.Instance.ShowComment(17);

        yield return new WaitForSeconds(15f);
        DialogueController.Instance.ShowComment(18);
        yield return new WaitForSeconds(4f);
        DialogueController.Instance.ShowComment(19);
        yield return new WaitForSeconds(6f);
        DialogueController.Instance.ShowComment(20);
        yield return new WaitForSeconds(7f);
        DialogueController.Instance.ShowComment(21);
        yield return new WaitForSeconds(15f);
        DialogueController.Instance.ShowComment(22);
        yield return new WaitForSeconds(10f);
        DialogueController.Instance.ShowComment(23);
        yield return new WaitForSeconds(10f);
        DialogueController.Instance.ShowComment(24);
        yield return new WaitForSeconds(6f);
        DialogueController.Instance.ShowComment(25);
        yield return new WaitForSeconds(10f);
        DialogueController.Instance.ShowComment(26);
        yield return new WaitForSeconds(10f);
        DialogueController.Instance.ShowComment(27);
        yield return new WaitForSeconds(10f);
        DialogueController.Instance.ShowComment(28);
        yield return new WaitForSeconds(10f);

        //TODO: FINAL SCENE

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
