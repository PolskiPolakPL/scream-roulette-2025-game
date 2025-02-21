using PolskiPolakPL.Utils;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class ToiletScript : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] float cooldown = 5;

    Interactable interactionSource;
    Timer timer;

    bool isFlushed = false;

    // Start is called before the first frame update
    void Start()
    {
        interactionSource = GetComponent<Interactable>();
        interactionSource.OnInteraction += FlushToilet;

        timer = new Timer(cooldown, true);
        timer.OnTimerEnd += ResetToilet;
    }

    private void Update()
    {
        if(isFlushed)
            timer.Tick(Time.deltaTime);
    }

    void FlushToilet()
    {
        if (isFlushed)
            return;
        isFlushed = true;
        audioSource.Play();
    }

    void ResetToilet()
    {
        isFlushed = false;
    }

    private void OnDestroy()
    {
        timer.OnTimerEnd -= ResetToilet;
    }
}
