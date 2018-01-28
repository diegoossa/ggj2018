using System.Collections;
using UnityEngine;

public class DeactivateOnTrigger : MonoBehaviour
{
    public GameObject[] thingsToDeactivate;
    public float timeToDeactivate = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DoSomething());
        }
    }

    private IEnumerator DoSomething()
    {
        yield return new WaitForSeconds(timeToDeactivate);
        for (int i = 0; i < thingsToDeactivate.Length; i++)
        {
            thingsToDeactivate[i].SetActive(false);
        }
    }
}
