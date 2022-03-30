using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWaveData", menuName = "WaveData")]
public class WaveData : ScriptableObject
{
    public List<GameObject> EnemiesToSpawn;
    public int NumToSpawn = 1;

}
