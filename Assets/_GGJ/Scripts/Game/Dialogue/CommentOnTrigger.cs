using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentOnTrigger : MonoBehaviour
{
    public int[] commentIds;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShowComments());
        }
    }

    private IEnumerator ShowComments()
    {
        for (int i = 0; i < commentIds.Length; i++)
        {
            DialogueController.Instance.ShowComment(commentIds[i]);
            yield return new WaitForSeconds(3f);
        }
    }
}
