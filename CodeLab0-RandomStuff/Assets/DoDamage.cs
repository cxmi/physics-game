using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public HealthBarManager healthBarManager;
    void OnCollisionEnter(Collision other){
        healthBarManager.TakeDamage(10);
    }
}
