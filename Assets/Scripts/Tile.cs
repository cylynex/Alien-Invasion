using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class Tile : MonoBehaviour {

    GameController gc;
    [SerializeField] bool isPlacable = true;
    [SerializeField] GameObject towerBuildMenu;
    [SerializeField] bool isOccupied = false;
    public bool IsOccupied { set { isOccupied = value; } }

    [SerializeField] Color originalColor;
    public Color OriginalColor { get { return originalColor; } }

    [SerializeField] Color highlightColor;
    public Color HighlightColor { get { return highlightColor; } }

    [SerializeField] GameObject tower;

    private void Start() {
        gc = FindObjectOfType<GameController>();
        originalColor = GetComponentInChildren<MeshRenderer>().sharedMaterial.color;
        highlightColor = Color.red;
    }

    private void OnMouseDown() {
        
        if (isPlacable && !isOccupied) {
            towerBuildMenu.SetActive(true);
            towerBuildMenu.GetComponent<TowerBuilderMenu>().EngageTile(gameObject);
        } else {
            print("ok show other stuff this tiles already busy");
            // Show range ring
            gc.ClearActiveTile();
            tower.GetComponent<Tower>().RangeCircle = true;
        }
    }

    public void SetPlacable(bool placable) {
        isPlacable = placable;
    }

    public void SetTower(GameObject builtTower) {
        tower = builtTower;
    }
}