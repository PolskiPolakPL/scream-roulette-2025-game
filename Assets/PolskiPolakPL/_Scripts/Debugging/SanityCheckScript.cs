using UnityEngine;

public class SanityCheckScript : MonoBehaviour
{
    private void Start()
    {
        SanitySystem.OnBecomeMad += CallMad;
        SanitySystem.OnBecomeInsane += CallInsane;
        SanitySystem.OnBecomeParanoid += CallParanoid;
        SanitySystem.OnBecomeSane += CallSane;
    }

    private void OnDestroy()
    {
        SanitySystem.OnBecomeMad -= CallMad;
        SanitySystem.OnBecomeInsane -= CallInsane;
        SanitySystem.OnBecomeParanoid -= CallParanoid;
        SanitySystem.OnBecomeSane -= CallSane;
    }

    void CallMad()
    {
        Debug.LogWarning("I'M GOING MAD!!!");
    }

    void CallInsane()
    {
        Debug.LogWarning("I'M INSANE!!!");
    }

    void CallParanoid()
    {
        Debug.LogWarning("Am I insane?");
    }

    void CallSane()
    {
        Debug.LogWarning("I'm Good :D");
    }
}
