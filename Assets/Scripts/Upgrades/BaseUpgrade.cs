using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseUpgrade
{
    public Button upgradeButton;
    
    protected int cost = 1;

    public abstract void ApplyUpgrade();

    public abstract string UpgradeName();

    public void SetButton(Button button)
    {
        upgradeButton = button;
    }
    
    public void CheckButtonCost(int money)
    {
        if (upgradeButton == null)
        {
            return;
        }

        if (money < cost)
        {
            upgradeButton.interactable = false;
        }
        else
        {
            upgradeButton.interactable = true;
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
