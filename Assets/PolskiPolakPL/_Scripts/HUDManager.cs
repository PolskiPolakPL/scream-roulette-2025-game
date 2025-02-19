using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    //Singleton statement
    public static HUDManager Instance;
    private void Awake()
    {
        if (Instance && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }



    //Attributes
    [SerializeField] TMP_Text interactionMessage;

    public void EnableInteractionText(string text)
    {
        interactionMessage.text = text + " (F)";
        interactionMessage.gameObject.SetActive(true);
    }
    public void DisableInteractionText()
    {
        interactionMessage.gameObject.SetActive(false);
    }

}
