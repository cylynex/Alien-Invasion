using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour {

    [Header("Money")]
    [SerializeField] Text moneyDisplay;
    [SerializeField] int money = 100;
    public int Money { get { return money; } }

    [Header("Power")]
    [SerializeField] Text powerDisplay;
    [SerializeField] int power = 10;
    public int Power { get { return power; } }

    private void Start() {
        UpdateDisplays();
    }

    public void AddMoney(int amount) {
        money += amount;
        UpdateDisplays();
    }

    public void TakeMoney(int amount) {
        money -= amount;
        UpdateDisplays();
    }

    public void GivePower(int amount) {
        power += amount;
        UpdateDisplays();
    }

    public void TakePower(int amount) {
        power -= amount;
        UpdateDisplays();
    }

    void UpdateDisplays() {
        moneyDisplay.text = money.ToString() + " spacebux";
        powerDisplay.text = power.ToString() + " power";
    }
}