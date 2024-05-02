using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private int money = 0;

    private PlaneController planeController;

    private SpeedUpgrade upgrade;

    private void Start()
    {
        planeController = FindObjectOfType<PlaneController>();

        upgrade = new SpeedUpgrade(planeController, 5,500f);
    }

    public void PurchaseUpgrade()
    {
        upgrade.ApplyUpgrade();
    }
}
