using UnityEngine;

public abstract class ActionZone : MonoBehaviour
{
    public RobotController player;

    public abstract void ActivateZone();

    private void Start()
    {
        player = GameManager.Instance.player.GetComponent<RobotController>();
    }
}
