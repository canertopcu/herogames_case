using UnityEngine;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "IceCreamShop", menuName = "Custom/IceCreamShop")]
public class IceCreamShopSO : ScriptableObject
{
    [SerializeField]
    private SerializedDictionary<string, IceCreamMachineSO> machines = new();

    public IceCreamMachineSO GetMachine(string name)
    {
        return machines.ContainsKey(name) ? machines[name] : null;
    }

    public List<string> GetMachineNames()
    {
        return new List<string>(machines.Keys);
    } 
}
