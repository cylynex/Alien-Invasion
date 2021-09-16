using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    
    [Header("Settings")]
    [SerializeField] string towerName;
    [SerializeField] float range;
    [SerializeField] int towerCost;
    public int TowerCost { get { return towerCost; } }

    [SerializeField] bool isBuiltYet = true;

    [SerializeField] GameObject target;
    public GameObject Target { get { return target; } }

    [SerializeField] float fireTime = 2f;
    [SerializeField] float fireTimer = 0f;
    [SerializeField] Ammo ammo;

    float tempRange;

    private void Start() {
        tempRange = Mathf.Infinity;
    }

    private void Update() {
        if (isBuiltYet) {
            GetTarget();
            FireControl();
            CheckRangeToTarget();
        } else {
            // TODO - Different building system for click placement.  Maybe change to this later.
            //print("not built yet - stick with the mouse");
            //Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        }
    }

    void GetTarget() {
        if (target == null) {
            GameObject[] targets = GameObject.FindGameObjectsWithTag("EnemyGround");
            
            // Get closest Enemy and lock onto them - this method keeps that target till destroyed or out of range
            foreach (GameObject enemy in targets) {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if ((distanceToEnemy < tempRange) && (distanceToEnemy < range)) {
                    target = enemy;
                }
            }            
        }
    }

    void CheckRangeToTarget() {
        if (target != null) {
            if (Vector3.Distance(transform.position, target.transform.position) > range) {
                target = null;
            }
        }
    }

    void FireControl() {
        if (target != null && fireTimer <= 0) {
            GameObject firedAmmo = Instantiate(ammo.AmmoObject, transform.position, Quaternion.identity);
            firedAmmo.GetComponent<AmmoTarget>().target = target;
            fireTimer = fireTime;
        } else {
            fireTimer -= Time.deltaTime;
        }
    }
}