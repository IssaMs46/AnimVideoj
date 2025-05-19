using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class CharacterState : MonoBehaviour
{
    [SerializeField] private float startStamina;
    [SerializeField] private float staminaRegen;

    [SerializeField] private float currentStamina;

    [SerializeField] private float startHealth = 30f;
    [SerializeField] private float currentHealth = 30f;
   
    
    
    private void start()
    {
        startHealth = 30f;
        currentHealth = startHealth;
    }
    private void RegenerateStamina (float regenAmount)
    {
       
        currentStamina = Mathf.Min(currentStamina + regenAmount, startStamina);
    }

    public void DepleteHealth(float amount, out bool zeroHealth)
    {
        currentHealth -= amount;
        zeroHealth = false;

        if(currentHealth <=0)
        {

            zeroHealth = true;
        }
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



    private void Start()
    {
        currentStamina = startStamina;

    }
    public void Update()
    {
        RegenerateStamina(staminaRegen * Time.deltaTime);
    }

    public float CurrentStamina => currentStamina;
}
