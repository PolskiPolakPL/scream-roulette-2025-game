using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolskiPolakPL.Utils;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightingPreset lightingPreset;
    [SerializeField, Range(0, 24)] private float timeOfDay;
    [SerializeField] private float timelapseDuration;
    private Timer timer;
    private bool isTimelapseActive = false;

    void Start()
    {
        timer = new Timer(timelapseDuration, true);
        timer.OnTimerEnd += StopTimelapse;
    }

    void Update()
    {
        if (lightingPreset == null)
            return;

        if (isTimelapseActive)
        {
            timer.Tick(Time.deltaTime);
            timeOfDay += Time.deltaTime / timelapseDuration;
            timeOfDay %= 24f;
            UpdateLighting(timeOfDay);
        }
        else if (Application.isEditor)
        {
            timeOfDay %= 24f;
            UpdateLighting(timeOfDay/24f);
        }
    }

    private void OnValidate()
    {
        if (directionalLight != null)
            return;

        if (RenderSettings.sun != null)
            directionalLight = RenderSettings.sun;
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    directionalLight = light;
                    return;
                }
            }
        }
    }

    private void OnDestroy()
    {
        timer.OnTimerEnd -= StopTimelapse;
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = lightingPreset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = lightingPreset.FogColor.Evaluate(timePercent);

        if (directionalLight != null)
        {
            directionalLight.color = lightingPreset.DirectionalColor.Evaluate(timePercent);
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent*360f) - 90f, 170f, 0));
        }

    }

    private void StopTimelapse()
    {
        isTimelapseActive = false;
    }

    public void StartTimelapse()
    {
        isTimelapseActive = true;
    }
}
