using UnityEngine;
using System.Collections;

public class IntroManager_SingleText : MonoBehaviour
{
    public GameObject[] initialPanels; // Pierwsze 4 panele
    public GameObject[] eventPanels;   // Ostatnie 3 panele

    private GameObject[] activePanels; // Bie¿¹ce panele do wyœwietlenia
    private bool isEventTriggered = false;
    private bool isShowingPanels = false;

    void Start()
    {
        // Ustawia pierwsze 4 panele jako aktywne, reszta ukryta
        activePanels = initialPanels;
        SetPanelsActiveState(false);  // Ukrywa wszystkie panele na pocz¹tku
        activePanels[0].SetActive(true); // Pierwszy panel widoczny

        StartCoroutine(SwitchPanelsAutomatically()); // Uruchamia automatyczne prze³¹czanie paneli
    }

    // Funkcja odpowiedzialna za prze³¹czanie paneli
    IEnumerator SwitchPanelsAutomatically()
    {
        isShowingPanels = true;

        // Przechodzi przez wszystkie panele i pokazuje je na 10 sekund
        for (int i = 0; i < activePanels.Length; i++)
        {
            ShowPanel(i);
            yield return new WaitForSeconds(10f); // Czeka 10s na kolejn¹ kartê
            HidePanel(i);
        }

        isShowingPanels = false;
    }

    // Funkcja do pokazania panelu
    void ShowPanel(int index)
    {
        if (index < 0 || index >= activePanels.Length) return;

        activePanels[index].SetActive(true);
    }

    // Funkcja do ukrycia panelu
    void HidePanel(int index)
    {
        if (index < 0 || index >= activePanels.Length) return;

        activePanels[index].SetActive(false);
    }

    // Funkcja do ustawiania aktywnoœci paneli
    void SetPanelsActiveState(bool state)
    {
        foreach (GameObject panel in initialPanels)
        {
            panel.SetActive(state);
        }
        foreach (GameObject panel in eventPanels)
        {
            panel.SetActive(false);  // Ukrywa wszystkie panele eventowe na starcie
        }
    }

    // Funkcja do uruchomienia paneli eventowych po klikniêciu obiektu (np. drzwi)
    public void TriggerEventPanels()
    {
        if (!isEventTriggered && !isShowingPanels)
        {
            isEventTriggered = true;
            activePanels = eventPanels; // Prze³¹cza na panele eventowe
            SetPanelsActiveState(false); // Ukrywa wszystkie panele (initial oraz event)
            StartCoroutine(SwitchPanelsAutomatically()); // Uruchamia prze³¹czanie nowych paneli
        }
    }
}
