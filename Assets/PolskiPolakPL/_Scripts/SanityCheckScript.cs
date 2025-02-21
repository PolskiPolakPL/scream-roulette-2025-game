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
        Debug.Log("I'M GOING MAD!!!");
    }

    void CallInsane()
    {
        Debug.Log("I'M INSANE!!!");
    }

    void CallParanoid()
    {
        Debug.Log("Am I insane?");
    }

    void CallSane()
    {
        Debug.Log("I'm Good :D");
    }
}
