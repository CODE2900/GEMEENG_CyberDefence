using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTurretData", menuName = "TurretData")]
public class TurretData : ScriptableObject
{
    public GameObject TurretPrefab;
    public GameObject TurretGhostPrefab;
}
