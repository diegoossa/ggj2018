using UnityEngine;

public class ForceField : MonoBehaviour
{
    [SerializeField] private GameObject sparks;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(sparks, other.contacts[0].point, Quaternion.identity);
            GameManager.Instance.Glitch();
        }
    }
}
