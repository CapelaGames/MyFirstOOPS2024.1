using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : BaseUpgrades
{
    protected PlaneController planeController;
    protected float upgradeSpeed;

    public SpeedUpgrade(PlaneController plane)
    {
        planeController = plane;
    }

    public SpeedUpgrade(PlaneController plane, int upgradeCost)
    {
        planeController = plane;
        cost = upgradeCost;
    }

    public SpeedUpgrade(PlaneController plane, int upgradeCost, float newSpeed)
    {
        planeController = plane;
        cost = upgradeCost;
        upgradeSpeed = newSpeed;
    }

    public override void ApplyUpgrade()
    {
        planeController.speed += upgradeSpeed;
    }
}
