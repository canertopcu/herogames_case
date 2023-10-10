using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "IceCreamMachine", menuName = "Custom/IceCreamMachine")]
public class IceCreamMachineSO : ScriptableObject
{
    public string Name;
    public float BaseProductionRate;
    public float BaseProductEarning;
    public float CurrentProductionRate;
    public float CurrentProductEarning;
       
    public void Initialize( )
    {  
        CurrentProductionRate = BaseProductionRate;
        CurrentProductEarning = BaseProductEarning;
    }
    public void CalculateNewProductionRate(float multiplier)
    {
        CurrentProductionRate = BaseProductionRate * multiplier;
        Debug.Log(Name + " Base ProductionRate: " + BaseProductionRate + " calculated CurrentProductionRate: " + CurrentProductionRate);
    }

    public void CalculateNewProductEarning(float multiplier)
    {
        CurrentProductEarning = BaseProductEarning * multiplier;
        Debug.Log(Name +" Base Earning: "+BaseProductEarning+ " calculated CurrentProductEarning: " + CurrentProductEarning);
    }
}
