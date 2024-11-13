using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    int health = 10;
    public int Health => health;
    float strength = 10.0f;
    public float Strength => strength;
    float speed = 5.0f;
    public float Speed => speed;

    float originalSpeed;
    float SpeedBoostDuration = 0.0f;
    float SpeedBoostTimer = 0.0f;
    bool IsSpeedBoostActive = false;
    [SerializeField] TextMeshProUGUI healthTxt, speedTxt, strengthTxt;
    
    void Start()
    {
        originalSpeed = speed;
        UpdateHealthText();
        UpdateSpeedText();
        UpdateStrengthText();

    }

    void Update()
    {
        UpdateSpeedBoostTimer();
    }
    void UpdateSpeedBoostTimer()
    {
        if (IsSpeedBoostActive)
        {
            SpeedBoostTimer += Time.deltaTime;
            Debug.Log("Speed Boost!!");
            if (SpeedBoostTimer >= SpeedBoostDuration)
            {
                speed = originalSpeed;
                IsSpeedBoostActive = false;
                Debug.Log("Speed boost ended. Speed reset");
            }

        }
    }

    public void PowerUp(int healthIncrease)
    {
        health += healthIncrease;
        UpdateHealthText();
        Debug.Log($"Health increased by {healthIncrease}. New health : {health} ");
    }
    public void PowerUp(float strengthMultiplier)
    {
        strength *= strengthMultiplier;
        Debug.Log($"Health increased by {strengthMultiplier * 100}% . New Strength : {strength}");
        UpdateStrengthText();
    }

    public void PowerUp(float speedMultiplier, float duration)
    {
        if (!IsSpeedBoostActive)
        {
            speed *= speedMultiplier;
            IsSpeedBoostActive = true;
            SpeedBoostDuration = duration;
            SpeedBoostTimer = 0.0f;
            UpdateSpeedText();
            Debug.Log($"Speed boosted by {speedMultiplier * 100}% for {duration} seconds.");
        }
    }
    void UpdateHealthText()
    {
        healthTxt.text = $"Health: {Health}";
    }

    void UpdateStrengthText()
    {
        strengthTxt.text = $"Strength: {Strength}";
    }

    void UpdateSpeedText()
    {
        speedTxt.text = $"Speed: {Speed}";
    }

}
