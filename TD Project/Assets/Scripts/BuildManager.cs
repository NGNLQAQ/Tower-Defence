using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{

    public TowerData laserData;
    public TowerData missileData;
    public TowerData standardData;

    private TowerData selected;
    private TowerData[] towerDatas;

    private int money = 1000;

    public Text moneyText;

    public Animator moneyFlicker;

    private void Start()
    {
        towerDatas = new TowerData[3] {laserData, missileData, standardData};
    }

    private void Update()
    {
        foreach(TowerData data in towerDatas)
        {
            if(data.cost > money)
            {
                data.priceTag.color = Color.red;
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(EventSystem.current.IsPointerOverGameObject() == false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("Map")))
                {
                    CubeManager mapCube = hit.collider.GetComponent<CubeManager>();
                    //mapCube.GetComponent<MeshRenderer>().material.color = Color.blue;
                    if(mapCube.tower == null)
                    {
                        if(money >= selected.cost)
                        {
                            MoneyUpdate(-selected.cost);
                            mapCube.BuildTower(selected.towerPrefab);
                        }
                        else
                        {
                            moneyFlicker.SetTrigger("Flicker");
                        }
                    }
                    else
                    {

                    }
                }

            }
        }
    }

    public void MoneyUpdate(int value)
    {
        money += value;
        moneyText.text = "$" + money;
    }
    public void OnLaserSelected(bool isSelected)
    {
        if(isSelected)
        {
            selected = laserData;
        }
    }

    public void OnMissileSelected(bool isSelected)
    {
        if(isSelected)
        {
            selected = missileData;
        }
    }
    public void OnStandardSelected(bool isSelected)
    {
        if(isSelected)
        {
            selected = standardData;
        }
    }
}
