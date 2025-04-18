using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterState : MonoBehaviour
{
    [SerializeField] private float startStamina;
    [SerializeField] private float staminaRegen;

    [SerializeField] private float currentStamina;
    private float currentHealth;

    private void RegenerateStamina (float regenAmount)
    {
        currentStamina = Mathf.Min(currentStamina * regenAmount, startStamina);
    }

    private float GetStaminaDepletion()
    {
        //sistema de inventario * 1/stat_fuerza * 1/buff_fuerza
        return 60;
    }
    
    public void DepleteStamina(float amount)
    {
        currentStamina -= GetStaminaDepletion() * amount;
    }

    public void Update()
    {
        RegenerateStamina(staminaRegen * Time.deltaTime);
    }

    public float CurrentStamina => currentStamina;
}
