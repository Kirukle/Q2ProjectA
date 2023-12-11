using UnityEngine;
using UnityEngine.Events;

public class Interactables : MonoBehaviour
{
    public UnityEvent onScan;
    public UnityEvent<bool> canMoveChanged = new UnityEvent<bool>();
    public UnityEvent<bool> canSprintChanged = new UnityEvent<bool>();
    public UnityEvent<bool> canJumpChanged = new UnityEvent<bool>();

    public void OnScanned()
    {
        onScan.Invoke();

        ThirdMover thirdMover = GetComponent<ThirdMover>();
        Jumpy jumpy = GetComponent<Jumpy>();

        bool canMoveValue = thirdMover.CanMove;
        bool canSprintValue = thirdMover.CanSprint;
        bool canJumpValue = jumpy.canJump;

        canMoveChanged.Invoke(canMoveValue);
        canSprintChanged.Invoke(canSprintValue);
        canJumpChanged.Invoke(canJumpValue);
    }
}