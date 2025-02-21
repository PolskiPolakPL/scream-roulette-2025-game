using System;
using UnityEngine;

public static class SanitySystem
{
    //Public Events
    public static event Action OnBecomeMad;
    public static event Action OnBecomeInsane;
    public static event Action OnBecomeParanoid;
    public static event Action OnBecomeSane;

    private static SanityStatus currentStatus = SanityStatus.SANE;

    public static int LooseSanity(int currentValue, int amount)
    {
        int newSanity = Mathf.Max(currentValue-amount, 0);
        CheckSanity(newSanity);
        Debug.Log($"Lost {amount} sanity points");
        return newSanity;
    }

    public static int GainSanity(int currentValue, int amount)
    {
        int newSanity = Mathf.Min(currentValue+amount,100);
        CheckSanity(newSanity);
        return newSanity;
    }

    private static void CheckSanity(int sanity)
    {
        SanityStatus newStatus;
        switch (sanity)
        {
            case <= 0:
                {
                    newStatus = SanityStatus.DEAD;
                }
                break;

            case <= 25:
                {
                    newStatus = SanityStatus.MAD;
                }
                break;

            case <= 50:
                {
                    newStatus = SanityStatus.INSANE;
                }
                break;

            case <= 75:
                {
                    newStatus = SanityStatus.PARANOID;
                }
                break;

            default:
                {
                    newStatus = SanityStatus.SANE;
                }
                break;
        }
        if (newStatus != currentStatus)
        {
            ChangeStatus(newStatus);
        }
    }

    private static void ChangeStatus(SanityStatus newStatus)
    {
        currentStatus = newStatus;
        switch (currentStatus)
        {
            case SanityStatus.DEAD:
                {
                    //GameManager.Instance.GameOver();
                }break;

            case SanityStatus.MAD:
                {
                    OnBecomeMad?.Invoke();
                }break;

            case SanityStatus.INSANE:
                {
                    OnBecomeInsane?.Invoke();
                }break;

            case SanityStatus.PARANOID:
                {
                    OnBecomeParanoid?.Invoke();
                }break;

            case SanityStatus.SANE:
                {
                    OnBecomeSane?.Invoke();
                }break;
        }
    }

}
