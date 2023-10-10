using Assets.Scripts.Core;
using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemUpgradeController", menuName = "Custom/Upgrade/ItemUpgradeController")]
public class ItemUpgradeControllerSO : UpgradeControllerSO
{
    [SerializeField]
    private SerializedDictionary<string, Upgrade> itemUpgrades = new();
    public override SerializedDictionary<string, Upgrade> Upgrades
    {
        get { return itemUpgrades; }
        set { itemUpgrades = value; }
    }
}