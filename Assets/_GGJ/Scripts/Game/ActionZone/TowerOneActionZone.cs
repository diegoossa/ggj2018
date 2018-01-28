using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class TowerOneActionZone : ActionZone
{
    public GameObject[] gosToActivate;
    public GameObject[] gosToDeactivate;

    public PlayableDirector cinematic;

    public override void ActivateZone()
    {
        StartCoroutine(ActivateZoneCoroutine());
    }

    private IEnumerator ActivateZoneCoroutine()
    {
        Debug.Log("Initial Zone");
        yield return new WaitForSeconds(2f);
        GameManager.Instance.robot.animator.SetTrigger("Connect");
        yield return new WaitForSeconds(6f);

        for (int i = 0; i < gosToActivate.Length; i++)
            gosToActivate[i].SetActive(true);

        for (int i = 0; i < gosToDeactivate.Length; i++)
            gosToDeactivate[i].SetActive(false);

        //yield return new WaitForSeconds(1f);
        //DialogueController.Instance.ShowComment(10);
        //yield return new WaitForSeconds(3f);
        //DialogueController.Instance.ShowComment(11);

        //GameManager.Instance.robot.canMove = true;
        //GameManager.Instance.canShowMap = true;

        cinematic.Play();

        yield return new WaitForSeconds(5f);
        DialogueController.Instance.ShowComment(16);

        GameManager.Instance.ActivateTower();

    }
}
