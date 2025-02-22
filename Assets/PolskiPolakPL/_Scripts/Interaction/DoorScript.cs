using UnityEngine;


[RequireComponent(typeof(Interactable))]
public class DoorScript : MonoBehaviour
{
    Interactable interactionSource;

    [SerializeField] Animator doorAnimator;
    [SerializeField] bool isDoorOpened = false;
    Collider doorCollider;
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
    }

    void CloseDoor()
    {
        doorAnimator.Play("CloseDoorAnimation");
        isDoorOpened = false;
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