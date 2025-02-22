using PolskiPolakPL.Utils;
using UnityEngine;
using UnityEngine.AI;

public class PatrolMap : MonoBehaviour
{
    [SerializeField] float waitingTime;
    [SerializeField] Transform patrolPoints;
    Vector3 currentTarget;
    NavMeshAgent agent;

    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = new Timer(waitingTime, true);
        timer.OnTimerEnd += Move;
        timer.Tick(waitingTime);
        agent.speed = 2;
        agent.acceleration = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.stoppingDistance>=Vector3.Distance(transform.position,currentTarget))
        {
            timer.Tick(Time.deltaTime);
        }
    }

    void GetNewTarget()
    {
        int randomIndex = Random.Range(0, patrolPoints.childCount);
        currentTarget = patrolPoints.GetChild(randomIndex).transform.position;
    }

    private void Move()
    {
        GetNewTarget();
        agent.SetDestination(currentTarget);
    }
}
