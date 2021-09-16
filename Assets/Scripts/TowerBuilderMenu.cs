using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilderMenu : MonoBehaviour {

    [SerializeField] GameObject fireTower;
    [SerializeField] GameObject iceTower;
    [SerializeField] GameObject activeTile;
    GameController gc;

    private void Start() {
        gc = FindObjectOfType<GameController>();
    }

    public void SelectFireTower() {
        print(activeTile.transform.position);
        gc.CreateTower(activeTile.transform, fireTower);
    }

    public void SelectIceTower() {
        gc.CreatePlacableTower(iceTower);
    }

    public void EngageTile(GameObject targetTile) {
        activeTile = targetTile;
    }



}