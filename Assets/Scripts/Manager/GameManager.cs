using Assets.Scripts.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public IceCreamShopSO iceCreamShop;
    private UpgradeManager upgradeManager; 
    // Start is called before the first frame update
    void Awake()
    { 
        iceCreamShop = Resources.Load<IceCreamShopSO> ("IceCreamShop");

        foreach (var n in iceCreamShop.GetMachineNames())
        {
            iceCreamShop.GetMachine(n).Initialize() ;
        }
        ShowBaseData();

        var created = new GameObject("UpgradeManager");
        created.AddComponent<UpgradeManager>();
        created.transform.parent = transform;
        upgradeManager = created.GetComponent<UpgradeManager>();
        upgradeManager.Setup(iceCreamShop);
    }

    private void ShowBaseData()
    {
        foreach (var machineName in iceCreamShop.GetMachineNames())
        {
            var machine = iceCreamShop.GetMachine(machineName);
            var baseProductEarning = machine.BaseProductEarning;
            var baseProductionRate = machine.BaseProductionRate;
            Debug.Log(machineName + " base earning value:" + baseProductEarning + " baseProduction rate : " + baseProductionRate);
        }
    } 

    private void ShowCurrentData()
    {
        foreach (var machineName in iceCreamShop.GetMachineNames())
        {
            var machine = iceCreamShop.GetMachine(machineName);
            
            Debug.Log(machineName + " current earning value:" + machine.CurrentProductEarning + " current Production rate : " + machine.CurrentProductionRate);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ShowCurrentData();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RecaluculateUpdates();
        }
    }

    private void Start()
    { 
        RecaluculateUpdates();
    }

    private void RecaluculateUpdates()
    {
        upgradeManager.Setup(iceCreamShop);
        foreach (var machineName in iceCreamShop.GetMachineNames())
        { 
            CalculateMachine(machineName);
        }
    }

    private void CalculateMachine(string MachineName)
    {
        IceCreamMachineSO machine = iceCreamShop.GetMachine(MachineName); 
        Debug.LogError("Calculate : "+MachineName);
        SignalBus.BroadcastSignal<IceCreamMachineSO, Action<string,float, float>>(MachineName, machine, Multiplication);
    }

    private void Multiplication(string machineName, float productEarningMultiplier, float productionRateMultiplier)
    {
        IceCreamMachineSO machine = iceCreamShop.GetMachine(machineName);
        machine.CalculateNewProductionRate(productionRateMultiplier);
        machine.CalculateNewProductEarning(productEarningMultiplier); 
    }
     
}
