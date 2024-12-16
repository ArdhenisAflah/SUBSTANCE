using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstancePool : MonoBehaviour
{
    // pake observer pattern (substance pool akan memberikan signal ke Spawner biar bisa Nge-spawn)
    public static event Action OnCompletePooled;
    // gua perlus static agar ketika gua setactive true atau setactive false gua merujuk ke instance yang sama.
    // kenapa perlu instance yang sama? karena biar enak ngelacak object yang udah di pooled makanya namanya SharedInstance.
    public static SubstancePool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    Transform parent;
    void Awake()
    {
        SharedInstance = this;
        parent = this.transform;
        pooledObjects = new List<GameObject>();
        GameObject tmp;

        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool,parent);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
        OnCompletePooled?.Invoke();
    }

   void Start()
   {
    
   }

   public GameObject GetSubstance()
   {
        for(int x = 0; x < amountToPool; x++)
        {
            // apakah game object yang di pool, aktif apa bukan? jika tidak aktif maka kasih ke caller.
            if(!pooledObjects[x].activeInHierarchy){
                return pooledObjects[x];
            } 
        }
        return null;
   }
}
