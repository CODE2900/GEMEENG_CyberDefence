using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWaveData", menuName = "WaveData")]
public class WaveData : ScriptableObject
{
    [System.Serializable]
    public class SpawnData
    {
        public GameObject EnemiesToSpawn;
        public int NumToSpawn;
    }
    public List<GameObject> EnemiesToSpawn;
    public int NumToSpawn = 1;

    public List<SpawnData> SpawnDatas;
}
