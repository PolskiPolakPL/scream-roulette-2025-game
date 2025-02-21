using System;
using PolskiPolakPL.Utils;
using UnityEngine;
using UnityEngine.Audio;

public class AudioOcclusion : MonoBehaviour
{
    [SerializeField] Transform origin;
    [SerializeField] String lowpassFilterName;
    [SerializeField] float checkFrequency = 0.1f;
    [SerializeField] LayerMask occluderLayer;

    AudioSource source;
    AudioMixer audioMixer;
    Timer updateTimer;
    private void Awake()
    {
        updateTimer = new Timer(checkFrequency, true);
        updateTimer.OnTimerEnd += HandleOcclusion;
    }

    private void Start()
    {
        source = transform.gameObject.GetComponent<AudioSource>();
        audioMixer = source.outputAudioMixerGroup.audioMixer;
    }

    // Update is called once per frame
    void Update()
    {
        updateTimer.Tick(Time.deltaTime);
    }

    private void OnDestroy()
    {
        updateTimer.OnTimerEnd -= HandleOcclusion;
    }

    void HandleOcclusion()
    {
        ChangeOcclusion(Camera.main.transform);
    }

    bool IsPlayerVisible(Vector3 OriginPosition, Vector3 targetPosition)
    {
        return !Physics.Linecast(OriginPosition, targetPosition, occluderLayer);
    }

    void PlayOpenSound()
    {
        audioMixer.SetFloat(lowpassFilterName, 22000);
    }

    void PlayOccludedSound()
    {
        audioMixer.SetFloat(lowpassFilterName, 700);
    }

    void ChangeOcclusion(Transform target)
    {
        if (IsPlayerVisible(origin.position, target.position))
            PlayOpenSound();
        else
            PlayOccludedSound();
    }
}