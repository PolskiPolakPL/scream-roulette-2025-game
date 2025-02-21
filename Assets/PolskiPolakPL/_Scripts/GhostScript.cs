using UnityEngine;
using PolskiPolakPL.Utils;

public class GhostScript : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float drainDistance;
    [SerializeField] int sanityDrain;
    [SerializeField] float drainDelay;

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
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance <= drainDistance)
        {
            timer.Tick(Time.deltaTime);
        }
    }

    void DrainSanity()
    {
        player.sanity = SanitySystem.LooseSanity(player.sanity,sanityDrain);
    }

    private void OnDestroy()
    {
        timer.OnTimerEnd -= DrainSanity;
    }
}
