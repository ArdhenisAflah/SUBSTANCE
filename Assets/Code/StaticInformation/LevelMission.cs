using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMission : MonoBehaviour
{  //          {0,   1,     2}
   // level -  {bad, good, goodStock}
   // ini mendeskripsikan berapa banyak target yang diperlukan (jika bad = sekian maka end lose game)
     public static Dictionary<int, int[]> objective = new Dictionary<int, int[]>()
     {
        {1, new int[] {10,4, 10}},
        {2, new int[] {2,8, 20}}
     };
}
