using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceball : MonoBehaviour {

    GameObject target;
    float speed = 30f;
    [SerializeField] int damage = 0;
    [SerializeField] float slowPercent = 50;
    [SerializeField] float slowTime;
    [SerializeField] Color slowColor;

    private void Start() {
        target = GetComponent<AmmoTarget>().target;
    }

    private void Update() {
        if (target != null) {
            Move();
        }
    }

    void Move() {
        transform.LookAt(target.transform);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "EnemyGround") {
            collision.gameObject.GetComponent<HitPoints>().TakeDamage(damage);
            collision.gameObject.GetComponent<Enemy>().Slow(slowPercent, slowTime, slowColor);
            Destroy(gameObject);
        }
    }
}