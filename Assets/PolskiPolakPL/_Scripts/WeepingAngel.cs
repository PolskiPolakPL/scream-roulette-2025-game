using UnityEngine;
using UnityEngine.AI;


public class WeepingAngel : MonoBehaviour
{
    Collider angelCollider;
    Camera cam;
    Plane[] cameraFrustumPlanes;

    [SerializeField] GameObject angelModel;
    [SerializeField] Transform target;
    [SerializeField] LayerMask occluderLayer;
    [SerializeField] float OcclusionRayHeight = 1;
    [SerializeField] AudioSource AudioSource;
    NavMeshAgent agent;
    bool isAngelFrozen = false;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        angelCollider = angelModel.GetComponent<Collider>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 10;
        agent.acceleration = 20;
    }

    // Update is called once per frame
    void Update()
    {

        if(IsAngelOnScreen() && !IsAngelOccluded())
        {
            FreezeAgent(true);
            if(!isAngelFrozen)
                AudioSource.Play();
            isAngelFrozen=true;
        }
        else
        {
            FreezeAgent(false);
            isAngelFrozen = false;
        }
        if (IsAngelOccluded())
        {

        }
        agent.SetDestination(target.position);
        Vector3 offset = new Vector3(0, OcclusionRayHeight, 0);
        if(IsAngelOccluded())
            Debug.DrawLine(transform.position + offset, target.position + offset, Color.green);
        else
            Debug.DrawLine(transform.position + offset, target.position + offset, Color.red);
    }

    bool IsAngelOnScreen()
    {
        Bounds bounds = angelCollider.bounds;
        cameraFrustumPlanes = GeometryUtility.CalculateFrustumPlanes(cam);
        return GeometryUtility.TestPlanesAABB(cameraFrustumPlanes, bounds);
    }

    bool IsAngelOccluded()
    {
        Vector3 offset = new Vector3(0, OcclusionRayHeight, 0);
        Debug.DrawLine(transform.position+offset, target.position+offset, Color.green);
        return Physics.Linecast(transform.position + offset, target.position + offset, occluderLayer);
    }

    void FreezeAgent(bool freeze)
    {
        agent.isStopped = freeze;
    }

}
