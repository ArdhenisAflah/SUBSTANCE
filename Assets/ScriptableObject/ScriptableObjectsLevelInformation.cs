using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelObj
{
    public int badSubstanceMax;
    public int goodSubstancePassGrade;
    public int goodSubstanceStock;

    public LevelObj(int badSubstanceMax, int goodSubstancePassGrade, int goodSubstanceStock)
    {
        this.badSubstanceMax = badSubstanceMax;
        this.goodSubstancePassGrade = goodSubstancePassGrade;
        this.goodSubstanceStock = goodSubstanceStock;
    }
}

[System.Serializable]
public class LevelTimeSpawn
{
    
    // GOOD SUBSTANCE SPAWN TIME INFO
    [HideInInspector]
    public float SubstanceTimeUntilSpawn;
    public float SubstanceMinimumTimeSpawn;
    public float SubstanceMaximumTimeSpawn;

    // BAD SUBSTANCE SPAWN TIME INFO
    [HideInInspector]
    public float BadSubstanceTimeUntilSpawn;
    public float BadSubstanceMinimumTimeSpawn;
    public float BadSubstanceMaximumTimeSpawn;

    public LevelTimeSpawn(float SubstanceMinimumTimeSpawn, float SubstanceMaximumTimeSpawn, float BadSubstanceMinimumTimeSpawn, float BadSubstanceMaximumTimeSpawn)
    {
        this.SubstanceMinimumTimeSpawn = SubstanceMinimumTimeSpawn;
        this.SubstanceMaximumTimeSpawn = SubstanceMaximumTimeSpawn;

        this.BadSubstanceMinimumTimeSpawn = BadSubstanceMinimumTimeSpawn;
        this.BadSubstanceMaximumTimeSpawn = BadSubstanceMaximumTimeSpawn;
    }
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/ScriptableObjectsLevelInformation", order = 1)]
public class ScriptableObjectsLevelInformation : ScriptableObject
{
    //FOR EFFICIENCY AND THE SAKE OF NIGGA SHIT PERFORMANCE
    public int Level;
    public bool isStoppedSpawn;
    public List<LevelObj> LevelObjectives = new List<LevelObj>();
    public List<LevelTimeSpawn> LevelTimeSpawns = new List<LevelTimeSpawn>();
    public int LevelPath;
}
