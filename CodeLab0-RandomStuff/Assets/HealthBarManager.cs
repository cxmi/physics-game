using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class HealthBarManager : MonoBehaviour
{
    public RectTransform healthBar;
    public float maxHealth = 100;
    public float currentHealth = 75;
    float stupidSliderOffset = 1.07f;
    float healthPercentage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthPercentage = currentHealth/maxHealth;
        healthBar.anchorMax = new Vector2(healthPercentage, 1);

        if (healthPercentage > stupidSliderOffset){
            healthPercentage = stupidSliderOffset;
        }


        if (healthPercentage < 0){
            healthPercentage = 0;
        }
    }

    public void TakeDamage (float damage){
        currentHealth -= damage;
    }
}
