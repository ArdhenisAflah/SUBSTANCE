using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/ScriptableObjectsLevelInformation", order = 1)]
public class ScriptableObjectsLevelInformation : ScriptableObject
{
    
    public int Level;
    public bool isStoppedSpawn;
    public List<int> LevelObjective = new List<int>();
    public int LevelPath;
}
