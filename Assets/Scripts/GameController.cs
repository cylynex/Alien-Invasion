using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField] Text errorText;
    Resources resources;
    GameObject activeTile;
    public GameObject ActiveTile { set { activeTile = value; } }

    private void Start() {
        resources = FindObjectOfType<Resources>();
        errorText.text = "";
    }

    public void CreateTower(GameObject tower) {
        int cost = tower.GetComponent<Tower>().TowerCost;
        Transform location = activeTile.transform;

        if (resources.Money >= cost) {
            float yPos = location.position.y + 5;
            Vector3 towerSpot = new Vector3(location.position.x, yPos, location.position.z);
            GameObject thisTower = Instantiate(tower, towerSpot, Quaternion.identity);
            location.gameObject.GetComponent<Tile>().SetTower(thisTower);
            resources.TakeMoney(cost);
            activeTile.GetComponent<Tile>().IsOccupied = true;
            UnColor();
        } else {
            SetErrorText("Insufficient Funds");
        }
    }

    // TODO - Future method for mouse placable towers
    public void CreatePlacableTower(GameObject tower) {
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        Instantiate(tower, objectPos, Quaternion.identity);
    }

    void SetErrorText(string updText) {
        errorText.text = updText;
        Invoke("ClearText", 2f);
    }

    void ClearText() {
        errorText.text = "";
    }

    void Color() {
        activeTile.GetComponentInChildren<MeshRenderer>().sharedMaterial.color = activeTile.GetComponent<Tile>().HighlightColor;
    }

    public void UnColor() {
        activeTile.GetComponentInChildren<MeshRenderer>().material.color = activeTile.GetComponent<Tile>().OriginalColor;
    }

    public void SetActiveTile(GameObject tile) {
        if (activeTile != null) UnColor();
        activeTile = tile;
        Color();
    }

}