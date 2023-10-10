using Assets.Scripts.Core;
using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeManager", menuName = "Custom/Upgrade/UpgradeManager")]
public class UpgradeManagerSO : ScriptableObject
{
    public List<UpgradeControllerSO> UpgradeControllers = new();
}