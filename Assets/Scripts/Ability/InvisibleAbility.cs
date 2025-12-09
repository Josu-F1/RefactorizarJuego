using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ❌ DEPRECATED: Use AbilitySystemComposer with InvisibilityAbilityStrategy instead
/// </summary>
[System.Obsolete("❌ DEPRECATED: Use AbilitySystemComposer (Clean Architecture) instead. This legacy class is NO LONGER SUPPORTED.", true)]
public class InvisibleAbility : MonoBehaviour
{
    [SerializeField] private float duration = 4f;
    [SerializeField] private GameObject[] invisibleObjects;
    public void Invisible()
    {
        StartCoroutine(GoInvisible());
    }

    private IEnumerator GoInvisible()
    {
        foreach (var g in invisibleObjects)
        {
            g.SetActive(false);
        }
        yield return new WaitForSeconds(duration);
        foreach (var g in invisibleObjects)
        {
            g.SetActive(true);
        }
    }
}
