using AYellowpaper.SerializedCollections;
using UnityEngine;

public class UpgradeControllerSO : ScriptableObject
{
    private SerializedDictionary<string, Upgrade> upgrades = new();

    public virtual SerializedDictionary<string, Upgrade> Upgrades
    {
        get { return upgrades; }
        set { upgrades = value; }
    }
}
