using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Ammo")]
public class Ammo : ScriptableObject {

    public string ammoName;
    public GameObject ammoObject;
    public GameObject AmmoObject { get { return ammoObject; } }

}