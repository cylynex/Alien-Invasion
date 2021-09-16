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
        SelectTower(fireTower);
    }

    public void SelectIceTower() {
        SelectTower(iceTower);
    }

    public void SelectTower(GameObject tower) {
        if (gc.CreateTower(activeTile.transform, tower)) {
            activeTile.GetComponent<Tile>().IsOccupied = true;
            UnColor();
            gameObject.SetActive(false);
        } else {
            UnColor();
            gameObject.SetActive(false);
        }
    }

    public void EngageTile(GameObject targetTile) {
        if (activeTile != null) UnColor();
        activeTile = targetTile;
        activeTile.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
    }

    void UnColor() {
        activeTile.GetComponentInChildren<MeshRenderer>().material.color = activeTile.GetComponent<Tile>().OriginalColor;
    }



}