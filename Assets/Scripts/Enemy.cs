using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject path;
    [SerializeField] List<Transform> waypoints = new List<Transform>();
    
    [SerializeField] int moneyValue = 25;
    [SerializeField] int powerTake = 1;
    [SerializeField] float startingMoveSpeed = 1f;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float turnSpeed = 2.5f;
    
    Transform nextWaypoint;
    int waypointIndex = 0;
    Transform lastWaypoint;

    [Header("Slow")] //  TODO make enemy mover script for this stuff
    [SerializeField] float slowTimer = 0f;
    [SerializeField] bool slowed;

    Resources resources;
    
    private void Start() {
        path = GameObject.FindGameObjectWithTag("Path");
        resources = FindObjectOfType<Resources>();
        SetupRoute();
        //StartCoroutine(MoveOld());
        nextWaypoint = waypoints[waypointIndex];
        lastWaypoint = waypoints[waypoints.Count - 1];
        transform.LookAt(nextWaypoint);
    }

    private void Update() {
        CheckSlow();
        Move();
    }

    // Get the next Waypoint
    void GetNextWaypoint() {
        waypointIndex++;
        nextWaypoint = waypoints[waypointIndex];
    }

    void Move() {
        Vector3 direction = nextWaypoint.transform.position - transform.position;
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        
        if (nextWaypoint == lastWaypoint) {
            // End Route
            if (Vector3.Distance(transform.position, lastWaypoint.position) <= 0.2f) {
                print("Finished Route");
                resources.TakePower(powerTake);
                Destroy(gameObject);
            }
        } else {
            // Get next waypoint when ready
            if (Vector3.Distance(transform.position, nextWaypoint.position) <= 5f) {
                GetNextWaypoint();
                //transform.LookAt(nextWaypoint);
            }
        }

        FaceWaypoint(nextWaypoint);

    }

    void FaceWaypoint(Transform positionToFace) {
        Vector3 faceDirection = positionToFace.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(faceDirection, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
    }

    void SetupRoute() {
        foreach(Transform wp in path.transform) {
            waypoints.Add(wp.transform);
        }
    }

    public void Die() {
        resources.AddMoney(moneyValue);
        Destroy(gameObject);
    }

    public void Slow(float percent, float timeSlowed, Color slowColor) {
        if (!slowed) {
            slowTimer = timeSlowed;
            float percentSlowed = percent / 100;
            slowed = true;
            moveSpeed = moveSpeed * percentSlowed;
            GetComponent<MeshRenderer>().material.color = slowColor;
        } else {
            slowTimer = timeSlowed;
        }
    }

    void CheckSlow() {
        if (slowed) {
            if (slowTimer < 0) {
                slowed = false;
                moveSpeed = startingMoveSpeed;
                GetComponent<MeshRenderer>().material.color = Color.white;
            } else {
                slowTimer -= Time.deltaTime;
            }
        }
    }


    IEnumerator MoveOld() {

        foreach (Transform wp in waypoints) {
            Vector3 startPoint = transform.position;
            Vector3 endPoint = wp.position;
            float moveInc = 0f;

            while (moveInc < 1f) {
                moveInc += Time.deltaTime;
                transform.position = Vector3.Lerp(startPoint, endPoint, moveInc * moveSpeed);
                yield return new WaitForEndOfFrame();
            }
        }

        print("Finished Route");
        resources.TakePower(powerTake);
        Destroy(gameObject);
    }

}