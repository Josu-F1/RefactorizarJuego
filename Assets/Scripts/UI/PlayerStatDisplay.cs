using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// OBSOLETO: Esta clase viola principios SOLID. 
/// Usar PlayerStatDisplayComposer con BombStatsUI, MovementStatsUI y UserInfoUI
/// </summary>
[System.Obsolete("Use PlayerStatDisplayComposer instead. This class violates SOLID principles.")]
public class PlayerStatDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI bombLimitText,
        damageText,
        lengthText,
        moveSpeedText,
        usernameText;
    private BombSpawner bombSpawner;
    private MoveComponent moveComponent;

    private void Start()
    {
        Player player = Player.Instance;
        bombSpawner = player.GetComponentInChildren<BombSpawner>();
        moveComponent = player.GetComponent<MoveComponent>();
        bombSpawner.OnBombLimitChanged += UpdateBombLimitText;
        bombSpawner.OnDamageChanged += UpdateDamageText;
        bombSpawner.OnLengthChanged += UpdateLengthText;
        moveComponent.OnMoveSpeedChanged += UpdateMoveSpeedText;
        UpdateAll();

        Debug.Log("Nombre de usuario actual: " + DataManagerComposer.CurrentUsername);
        usernameText.text = DataManagerComposer.CurrentUsername;
    }

    private void UpdateMoveSpeedText()
    {
        moveSpeedText.text = (moveComponent.MoveSpeed * 100).ToString();
    }

    private void UpdateLengthText()
    {
        lengthText.text = bombSpawner.Length.ToString();
    }

    private void UpdateDamageText()
    {
        damageText.text = bombSpawner.Damage.ToString();
    }

    private void UpdateBombLimitText()
    {
        bombLimitText.text = bombSpawner.BombLimit.ToString();
    }

    private void UpdateAll()
    {
        UpdateMoveSpeedText();
        UpdateLengthText();
        UpdateDamageText();
        UpdateBombLimitText();
    }

    private void OnDestroy()
    {
        bombSpawner.OnBombLimitChanged -= UpdateBombLimitText;
        bombSpawner.OnDamageChanged -= UpdateDamageText;
        bombSpawner.OnLengthChanged -= UpdateLengthText;
        moveComponent.OnMoveSpeedChanged -= UpdateMoveSpeedText;
    }
}
