using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    //field
    [SerializeField] private int money = 0;

    //propery
    //public int Money2 {  get; private set; }
    public int Money
    {
        get
        {
            return money;
        }
        private set
        {
            money = value;
            foreach (var upgrade in upgrades )
            {
               upgrade.CheckButtonCost(value); 
            }
        }
    }
    
    
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
            upgrade.SetButton(go);
            upgrade.CheckButtonCost(Money); 
            TMP_Text text = go.GetComponentInChildren<TMP_Text>();
            text.text = upgrade.UpgradeName(); 

            int x = i;
            go.onClick.AddListener(()=>PurchaseUpgrade(x));
        }
    }

    public void PurchaseUpgrade(int index)
    {
        int tempMoney = Money;
        if (upgrades[index].PayForUpgrade(ref tempMoney))
        {
            upgrades[index].ApplyUpgrade();
        }

        Money = tempMoney;
    }

    public void EarnMoney(int amount)
    {
        Money += amount;
    }
}
