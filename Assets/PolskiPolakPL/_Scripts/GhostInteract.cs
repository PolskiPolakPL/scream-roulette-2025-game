using PolskiPolakPL.Utils;
using UnityEngine;

public class GhostInteract : MonoBehaviour
{
    [SerializeField] Transform interactiveParent;
    [SerializeField] float interactionTime;
    [SerializeField] float interactionDistance;


    Timer timer;
    Interactable currentInteractable;

    private void Start()
    {
        timer = new Timer(interactionTime,true);
        timer.OnTimerEnd += TryInteraction;
    }

    private void Update()
    {
        timer.Tick(Time.deltaTime);
    }

    void TryInteraction()
    {
        GetClosesdInteractable();
        if (currentInteractable == null)
            return;
        float interactableDistance = Vector3.Distance(transform.position, currentInteractable.transform.position);
        if(interactableDistance <= interactionDistance)
        {
            currentInteractable.Interact();
        }
    }

    void GetClosesdInteractable()
    {
        int closestId = 0;
        float minDistance = Mathf.Infinity;
        for (int i = 0; i < interactiveParent.childCount; i++)
        {
            float distance = Vector3.Distance(transform.position,interactiveParent.GetChild(i).position);
            if (distance < minDistance)
            {
                closestId = i;
                minDistance = distance;
            }
        }
        currentInteractable = interactiveParent.GetChild(closestId).gameObject.GetComponent<Interactable>();
    }

    //private void OnDestroy()
    //{
    //    timer.OnTimerEnd -= TryInteraction;
    //}
}
