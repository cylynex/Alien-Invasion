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
        gc.CreateTower(tower);

        /*
        if (gc.CreateTower(activeTile.transform, tower)) {
            gameObject.SetActive(false);
        } else {
            UnColor();
            gameObject.SetActive(false);
        }
        */
        gameObject.SetActive(false);
    }

    public void EngageTile(GameObject targetTile) {
        //if (activeTile != null) UnColor();
        //activeTile = targetTile;
        activeTile = targetTile;
        Invoke("SendTile", .01f); // TODO Figure out why this isnt populating fast enough to require a delay.
    }

    void SendTile() {
        gc.SetActiveTile(activeTile);
    }
}