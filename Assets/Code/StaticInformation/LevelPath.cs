using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPath : MonoBehaviour
{
    // level - {goodSpawn} 
    // ini mendeskripsikan berapa banyak yang di spawn
    public static Dictionary<int, int> paths = new Dictionary<int, int>()
    {
       {1, 4},
       {2, 6}
    };

}
