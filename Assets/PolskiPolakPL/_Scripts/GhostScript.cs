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
        BecomeInvisible();
        patrolMap.enabled = true;
        ghostInteract.enabled = false;
        proximityDrain.enabled = true;
        weepingAngel.enabled = false;
    }

    void StartSecondPhase()
    {
        BecomeInvisible();
        patrolMap.enabled = true;
        ghostInteract.enabled = true;
        proximityDrain.enabled = false;
        weepingAngel.enabled = false;
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
