using Assets.Scripts.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private UpgradeManagerSO managerSO;
    public List<UpgradeControllerSO> UpgradeControllers=new();
    private IceCreamShopSO iceCreamShop;


    public void Setup(IceCreamShopSO shop)
    {
        iceCreamShop = shop;
        managerSO = Resources.Load<UpgradeManagerSO>("Data/UpgradeManager");
        UpgradeControllers=managerSO.UpgradeControllers;
      
        foreach (var machineName in iceCreamShop.GetMachineNames())
        {
            SignalBus.Unsubscribe<IceCreamMachineSO, Action<string, float, float>>(machineName, CalculateUpgradedValues);

            SignalBus.Subscribe<IceCreamMachineSO, Action<string, float, float>>(machineName, CalculateUpgradedValues);
        }
    }
      
    private void OnDisable()
    {
        foreach (var machineName in iceCreamShop.GetMachineNames())
        {
            SignalBus.Unsubscribe<IceCreamMachineSO, Action<string, float, float>>(machineName, CalculateUpgradedValues);
        }
    }

    private void CalculateUpgradedValues(IceCreamMachineSO machine, Action<string, float, float> callback)
    { 
        float multiplierForProductEarning = 1;
        float multiplierForProductionRate = 1;

        foreach (var upgradeController in UpgradeControllers)
        {
            foreach (var upgrade in upgradeController.Upgrades)
            {
                if (upgrade.Value.TargetMachineName == machine.Name)
                {
                    if (upgrade.Value.AffectType == AffectType.DecreaseProductionTime)
                    {
                        Debug.Log( machine.Name +" - " + upgrade.Key + " : " + upgrade.Value.Power + "X DecreaseProductionTime " );
                        multiplierForProductionRate *= upgrade.Value.Power;
                    }

                    if (upgrade.Value.AffectType == AffectType.IncreaseEarning)
                    {
                        Debug.Log(machine.Name + " - " + upgrade.Key + " : " + upgrade.Value.Power + "X IncreaseEarning  " );
                        multiplierForProductEarning *= upgrade.Value.Power;
                    }
                }
            }
        } 
        Debug.Log(  machine.Name + " Total IncreaseEarning is " + multiplierForProductEarning );
        Debug.Log(  machine.Name + " Total DecreaseProductionTime is " + multiplierForProductionRate );

        callback?.Invoke(machine.Name, multiplierForProductEarning, multiplierForProductionRate);
    }

}
