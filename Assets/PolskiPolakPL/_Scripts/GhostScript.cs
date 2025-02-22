using System.Runtime.CompilerServices;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    [SerializeField] GameObject ghostModel;
    GhostInteract ghostInteract;
    ProximityDrain proximityDrain;
    WeepingAngel weepingAngel;
    PatrolMap patrolMap;
    // Start is called before the first frame update
    void Start()
    {
        ghostInteract = GetComponent<GhostInteract>();
        proximityDrain = GetComponent<ProximityDrain>();
        weepingAngel = GetComponent<WeepingAngel>();
        patrolMap = GetComponent<PatrolMap>();


        SanitySystem.OnBecomeMad += StartThirdPhase;
        SanitySystem.OnBecomeInsane += StartSecondPhase;
        SanitySystem.OnBecomeParanoid += StartFirstPhase;
    }

    void StartFirstPhase()
    {
        proximityDrain.enabled = true;
    }

    void StartSecondPhase()
    {
        patrolMap.enabled = true;
        ghostInteract.enabled = true;
    }

    void StartThirdPhase()
    {
        BecomeVisible();
        patrolMap.enabled = false;
        ghostInteract.enabled = true;
        proximityDrain.enabled = true;
        weepingAngel.enabled = true;
    }

    void BecomeVisible()
    {
        ghostModel.layer = 1;
    }

    void BecomeInvisible()
    {
        ghostModel.layer = 6;
    }
}
