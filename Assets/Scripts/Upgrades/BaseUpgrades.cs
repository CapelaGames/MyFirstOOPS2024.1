using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseUpgrades
{
    public Button upgradebutton;
    
    protected int cost = 1;

    public abstract void ApplyUpgrade();

    public abstract string UpgradeName();

    public void SetButton(Button btn)
    {
        upgradebutton = btn;
    }
    public void CheckButtonCost(int money)
    {
        if (upgradebutton == null)
        {
            return;
        }
       
        Debug.Log(UpgradeName());
        if (money < cost)
        {
            upgradebutton.interactable = false;
        }
        else
        {
            upgradebutton.interactable = true;
        }
    }
    
    public bool PayForUpgrade(ref int money)
    {
        if (money >= cost)
        {
            money -= cost;
            
            return true;
        }

        return false;
    }
    
}
