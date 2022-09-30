using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class TowerData
{
    public GameObject towerPrefab;
    public GameObject upgradePrefab;
    public int cost;
    public int costUpgrade;
    public TextMeshProUGUI priceTag;
    public TowerType type;
}

public enum TowerType
{
    Laser,
    Missile,
    Standard
}
