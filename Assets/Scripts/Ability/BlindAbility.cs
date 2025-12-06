using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ❌ DEPRECATED: Use AbilitySystemComposer with BlindAbilityStrategy instead
/// </summary>
[System.Obsolete("❌ DEPRECATED: Use AbilitySystemComposer (Clean Architecture) instead. This legacy class is NO LONGER SUPPORTED.", true)]
public class BlindAbility : MonoBehaviour
{
    [SerializeField] private GameObject blindLight;
    [SerializeField] private float duration = 5;
    private GlobalLight globalLight;
    private void Start()
    {
        globalLight = GlobalLight.Instance;
        blindLight.SetActive(false);
    }
    public void Blind()
    {
        StartCoroutine(Blinding());
    }
    private IEnumerator Blinding()
    {
        globalLight.TurnOff(duration);
        blindLight.SetActive(true);
        yield return new WaitForSeconds(duration);
        blindLight.SetActive(false);
    }
}
