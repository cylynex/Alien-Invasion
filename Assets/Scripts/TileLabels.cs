using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class TileLabels : MonoBehaviour { 
    
    [SerializeField] TextMeshPro coordinate;

    void Start() {
        UpdateCoordinates();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.C)) ToggleDisplay();
        UpdateCoordinates();
    }

    void UpdateCoordinates() {
        float positionX = transform.position.x / 10;
        float positionZ = transform.position.z / 10;
        coordinate.text = "(" + positionX + "," + positionZ + ")";
    }

    void ToggleDisplay() {
        print("hitc");
        coordinate.enabled = !coordinate.IsActive();
    }
}