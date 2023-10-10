using Assets.Scripts.Core;
using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InGameUpgradeController", menuName = "Custom/Upgrade/InGameUpgradeController")]
public class InGameUpgradeControllerSO : UpgradeControllerSO
{
    [SerializeField] 
    private SerializedDictionary<string, Upgrade> inGameUpgrades = new();

    public override SerializedDictionary<string, Upgrade> Upgrades
    {
        get { return inGameUpgrades; }
        set { inGameUpgrades = value; }
    }
}