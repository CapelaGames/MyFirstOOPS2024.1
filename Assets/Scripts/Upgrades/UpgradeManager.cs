using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private int money = 0;
    [SerializeField] private Button buttonPrefab;
    [SerializeField] private Transform buttonParent;
    private PlaneController planeController;
    private List<BaseUpgrades> upgrades;
    private void Start()
    {
        planeController = FindObjectOfType<PlaneController>();

        upgrades = new List<BaseUpgrades>();
        
        upgrades.Add(new SpeedUpgrade(planeController, 5,500f));
        upgrades.Add(new SpeedUpgrade(planeController, 8,1000f));
        upgrades.Add(new SpeedUpgrade(planeController, 11,1500f));
        upgrades.Add(new GravityUpgrade(planeController, 5,1f));
        upgrades.Add(new GravityUpgrade(planeController, 8,2f));
        upgrades.Add(new GravityUpgrade(planeController, 11,3f));

        for (int i = 0; i < upgrades.Count ; i++)
        {
            var upgrade = upgrades[i];
            
            Button go = Instantiate(buttonPrefab, buttonParent);

            int x = i;
            go.onClick.AddListener(()=>PurchaseUpgrade(x));
        }
    }

    public void PurchaseUpgrade(int index)
    {
        if (upgrades[index].PayForUpgrade(ref money))
        {
            upgrades[index].ApplyUpgrade();
        }
    }
}
