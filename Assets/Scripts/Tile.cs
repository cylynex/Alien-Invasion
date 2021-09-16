using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class Tile : MonoBehaviour {

    GameController gc;
    [SerializeField] bool isPlacable = true;
    bool occupied = false;

    private void Start() {
        gc = FindObjectOfType<GameController>();
    }

    private void OnMouseDown() {
        /*
        if (isPlacable) {
            int towerCost = 50; // TODO - THIs needs to come from the actual tower not hardcoded here.
            occupied = gc.CreateTower(transform, towerCost);
        }
        */

        if (isPlacable) {
            print("show menu");
        }

    }

    public void SetPlacable(bool placable) {
        isPlacable = placable;
    }
}