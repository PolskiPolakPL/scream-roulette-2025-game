using UnityEngine;
using PolskiPolakPL.Utils;

public class ProximityDrain : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float drainDistance;
    [SerializeField] int sanityDrain;
    [SerializeField] float drainDelay;
    [SerializeField] float heightOffset=1;

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
        Vector3 offset = new Vector3(0, heightOffset, 0);
        isTargetInRange = Vector3.Distance(transform.position,target.transform.position) <= drainDistance;
        if (isTargetInRange /*&& !CheckTargetOccluded(transform.position,target.transform.position)*/)
        {
            Debug.DrawLine(transform.position + offset, target.transform.position + offset, Color.red);
            timer.Tick(Time.deltaTime);
        }
        Debug.DrawLine(transform.position+offset, target.transform.position + offset, Color.green);
    }

    void DrainSanity()
    {
        player.sanity = SanitySystem.LooseSanity(player.sanity,sanityDrain);
    }

    bool CheckTargetOccluded(Vector3 originPosition, Vector3 targetPosition)
    {
        Vector3 offset = new Vector3(0,heightOffset,0);
        return Physics.Linecast(originPosition+offset, targetPosition+offset);
    }

    private void OnDestroy()
    {
        timer.OnTimerEnd -= DrainSanity;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, drainDistance);
    }
}
