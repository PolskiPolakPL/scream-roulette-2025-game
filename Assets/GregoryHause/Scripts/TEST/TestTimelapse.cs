using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolskiPolakPL.Utils;

public class TestTimelapse : MonoBehaviour
{
    [SerializeField] LightingManager lightingManager;
    // Start is called before the first frame update
    void Start()
    {
        lightingManager.StartTimelapse();
    }

}
