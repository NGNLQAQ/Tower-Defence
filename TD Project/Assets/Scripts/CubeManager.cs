using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [HideInInspector]
    public GameObject tower;

    public GameObject buildEffect;

    public void BuildTower(GameObject towerprefab)
    {
        tower = GameObject.Instantiate(towerprefab, this.transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, this.transform.position, Quaternion.identity);
        Destroy(effect, 1);
    }
}
