using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField] GameObject tower;
    [SerializeField] Text errorText;
    Resources resources;

    private void Start() {
        resources = FindObjectOfType<Resources>();
        errorText.text = "";
    }

    public bool CreateTower(Transform location, int cost) {
        if (resources.Money >= cost) {
            float yPos = location.position.y + 5;
            Vector3 towerSpot = new Vector3(location.position.x, yPos, location.position.z);
            GameObject thisTower = Instantiate(tower, towerSpot, Quaternion.identity);
            resources.TakeMoney(cost);
            return true;
        } else {
            SetErrorText("Insufficient Funds");
            return false;
        }
    }

    void SetErrorText(string updText) {
        errorText.text = updText;
        Invoke("ClearText", 2f);
    }

    void ClearText() {
        errorText.text = "";
    }

}