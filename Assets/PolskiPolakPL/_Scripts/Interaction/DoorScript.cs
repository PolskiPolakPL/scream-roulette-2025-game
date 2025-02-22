using UnityEngine;


[RequireComponent(typeof(Interactable))]
public class DoorScript : MonoBehaviour
{
    Interactable interactionSource;

    [SerializeField] Animator doorAnimator;
    [SerializeField] bool isDoorOpened = false;
    [SerializeField] Collider doorCollider;
    public bool Locked = false;
    private void Start()
    {
        interactionSource = GetComponent<Interactable>();
        interactionSource.OnInteraction += DoInteraction;
        doorCollider = GetComponent<Collider>();
    }

    public void DoInteraction()
    {
        if (Locked)
            return;
        if (isDoorOpened)
            CloseDoor();
        else
            OpenDoor();
    }

    void OpenDoor()
    {
        doorAnimator.Play("OpenDoorAnimation");
        isDoorOpened = true;
        interactionSource.message = "Close";
    }

    void CloseDoor()
    {
        doorAnimator.Play("CloseDoorAnimation");
        isDoorOpened = false;
        interactionSource.message = "Open";
    }
    void EnableCollider()
    {
        doorCollider.enabled = true;
    }
    void DisableCollider()
    {
        doorCollider.enabled = false;
    }
}