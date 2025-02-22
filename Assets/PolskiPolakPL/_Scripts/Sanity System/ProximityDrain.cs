using UnityEngine;
using PolskiPolakPL.Utils;

public class ProximityDrain : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float drainDistance;
    [SerializeField] int sanityDrain;
    [SerializeField] float drainDelay;

    bool isTargetInRange;

    PlayerScript player;
    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer(drainDelay,true);
        timer.OnTimerEnd += DrainSanity;
        player = target.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        isTargetInRange = Vector3.Distance(transform.position,target.transform.position) <= drainDistance;
        if (isTargetInRange && !CheckTargetOccluded(transform.position,target.transform.position))
        {
            timer.Tick(Time.deltaTime);
        }
    }

    void DrainSanity()
    {
        player.sanity = SanitySystem.LooseSanity(player.sanity,sanityDrain);
    }

    bool CheckTargetOccluded(Vector3 originPosition, Vector3 targetPosition)
    {
        return Physics.Linecast(originPosition, targetPosition);
    }

    //private void OnDestroy()
    //{
    //    timer.OnTimerEnd -= DrainSanity;
    //}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, drainDistance);
    }
}
