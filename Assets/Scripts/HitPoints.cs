using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoints : MonoBehaviour {

    [SerializeField] int startingHitPoints;
    [SerializeField] int hitPoints;    

    private void Start() {
        hitPoints = startingHitPoints;
    }

    public void TakeDamage(int amount) {
        hitPoints -= amount;
        if (hitPoints <= 0) GetComponent<Enemy>().Die();
    }
}