using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class LightSwitch : MonoBehaviour
{
    [SerializeField] bool lightsON = true;
    [SerializeField] List<Light> lights = new List<Light>();
    Interactable interactionSource;
    private void Start()
    {
        interactionSource = GetComponent<Interactable>();
        interactionSource.OnInteraction += ToggleLight;
    }
    public void ToggleLight()
    {
        lightsON = !lightsON;
        foreach (Light light in lights)
        {
            light.enabled = lightsON;
        }
    }

    private void OnDestroy()
    {
        interactionSource.OnInteraction -= ToggleLight;
    }
}
