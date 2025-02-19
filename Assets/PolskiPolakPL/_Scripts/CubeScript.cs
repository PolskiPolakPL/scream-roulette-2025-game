using UnityEngine;

public class CubeScript : MonoBehaviour
{
    Interactable interactionSource;
    // Start is called before the first frame update
    void Start()
    {
        interactionSource = GetComponent<Interactable>();
        interactionSource.OnInteraction += DoCubeInteraction;
    }

    void DoCubeInteraction()
    {
        Debug.Log($"Interacted with cube named: {gameObject.name}!");
    }

    private void OnDestroy()
    {
        interactionSource.OnInteraction -= DoCubeInteraction;
    }
}
