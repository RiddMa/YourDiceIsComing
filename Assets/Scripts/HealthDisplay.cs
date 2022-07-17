using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    // public int health;
    private TextMeshPro _healthText;

    // Start is called before the first frame update
    void Start()
    {
        _healthText = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        // _healthText.text = "Health: " + health;
    }

    public void SetHealth(float targetHealth)
    {
        _healthText.text = "Health: " + targetHealth;
    }
}