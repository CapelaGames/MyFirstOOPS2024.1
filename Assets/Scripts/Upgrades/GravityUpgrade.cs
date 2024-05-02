using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityUpgrade : BaseUpgrades
{
    protected PlaneController planeController;
    protected float upgradeGravity;
    
    public GravityUpgrade(PlaneController plane, int upgradeCost, float newSpeed)
    {
        planeController = plane;
        cost = upgradeCost;
        upgradeGravity = newSpeed;
    }
    
    public override void ApplyUpgrade()
    {
        planeController.gravity -= upgradeGravity;
        planeController.gravity = Mathf.Clamp(planeController.gravity, 0f, 20f);
    }
}
