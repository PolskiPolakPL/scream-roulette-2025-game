using UnityEngine;
using UnityEngine.AI;


public class WeepingAngel : MonoBehaviour
{
    Collider collider;
    Camera camera;
    Plane[] cameraFrustumPlanes;

    [SerializeField] GameObject angelModel;
    [SerializeField] Transform target;
    [SerializeField] LayerMask occluderLayer;
    [SerializeField] float OcclusionRayHeight = 1;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        collider = angelModel.GetComponent<Collider>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsAngelOnScreen() && !IsAngelOccluded())
        {
            FreezeAgent(true);
        }
        else
        {
            FreezeAgent(false);
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
        Bounds bounds = collider.bounds;
        cameraFrustumPlanes = GeometryUtility.CalculateFrustumPlanes(camera);
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
