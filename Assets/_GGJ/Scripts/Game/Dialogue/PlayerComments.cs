using System.Collections;
using UnityEngine;

public class PlayerComments : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(StartComments());
    }

    private IEnumerator StartComments()
    {
        yield return new WaitForSeconds(2f);
        DialogueController.Instance.ShowComment(0);
        yield return new WaitForSeconds(4f);
        DialogueController.Instance.ShowComment(1);
        yield return new WaitForSeconds(2f);
        DialogueController.Instance.ShowComment(2);
        yield return new WaitForSeconds(4f);
        DialogueController.Instance.ShowComment(3);
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