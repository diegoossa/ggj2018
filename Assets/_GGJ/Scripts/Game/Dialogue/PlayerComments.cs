using System.Collections;
using UnityEngine;

public class PlayerComments : MonoBehaviour
{
    private RobotController robot;
    private AudioSource aSource;
    public AudioClip glitch;

    private void Start()
    {
        robot = GetComponent<RobotController>();
        StartCoroutine(StartComments());
    }

    private IEnumerator StartComments()
    {
        AudioSource.PlayClipAtPoint(glitch, transform.position, 0.8f);

        robot.canMove = false;

        yield return new WaitForSeconds(2f);
        DialogueController.Instance.ShowComment(0);
        yield return new WaitForSeconds(4f);
        DialogueController.Instance.ShowComment(1);
        yield return new WaitForSeconds(2f);
        DialogueController.Instance.ShowComment(2);
        yield return new WaitForSeconds(4f);
        DialogueController.Instance.ShowComment(3);
        robot.canMove = true;
        yield return new WaitForSeconds(6f);
        DialogueController.Instance.ShowComment(4);
        yield return new WaitForSeconds(3f);
        DialogueController.Instance.ShowComment(5);
        yield return new WaitForSeconds(3f);
        DialogueController.Instance.ShowComment(6);
        yield return new WaitForSeconds(3f);
        DialogueController.Instance.ShowComment(7);
        yield return new WaitForSeconds(3f);
        DialogueController.Instance.ShowComment(8);
        yield return new WaitForSeconds(3f);
        //DialogueController.Instance.ShowComment(9);
        //yield return new WaitForSeconds(3f);

    }

}