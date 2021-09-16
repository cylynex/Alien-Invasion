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
    Color originalColor;
    public Color OriginalColor { get { return originalColor; } }

    private void Start() {
        gc = FindObjectOfType<GameController>();
        originalColor = GetComponentInChildren<MeshRenderer>().sharedMaterial.color;
    }

    private void OnMouseDown() {
        
        if (isPlacable && !isOccupied) {
            towerBuildMenu.SetActive(true);
            towerBuildMenu.GetComponent<TowerBuilderMenu>().EngageTile(gameObject);
        }
    }

    public void SetPlacable(bool placable) {
        isPlacable = placable;
    }
}