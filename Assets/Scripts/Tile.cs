using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class Tile : MonoBehaviour {

    GameController gc;
    [SerializeField] bool isPlacable = true;
    [SerializeField] GameObject towerBuildMenu;
    bool occupied = false;

    private void Start() {
        gc = FindObjectOfType<GameController>();
        //towerBuildMenu = GameObject.FindGameObjectWithTag("BuildTowerMenu");
    }

    private void OnMouseDown() {
        /*
        if (isPlacable) {
            int towerCost = 50; // TODO - THIs needs to come from the actual tower not hardcoded here.
            occupied = gc.CreateTower(transform, towerCost);
        }
        */

        if (isPlacable) {
            print("popping menu");
            towerBuildMenu.SetActive(true);
            towerBuildMenu.GetComponent<TowerBuilderMenu>().EngageTile(gameObject);
        }

    }

    public void SetPlacable(bool placable) {
        isPlacable = placable;
    }
}