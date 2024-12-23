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
    public List<GameObject> pooledSubstances;
    public List<GameObject> pooledBadSubstances;
    public GameObject[] objectToPool;
    public int amountToPool;
    Transform parent;
    void Awake()
    {
        SharedInstance = this;
        parent = this.transform;
        pooledSubstances = new List<GameObject>();
        GameObject tmpSubstance;
        GameObject tmpBadSubstance;

        for(int i = 0; i < amountToPool; i++)
        {
            tmpSubstance = Instantiate(objectToPool[0],parent);
            tmpSubstance.SetActive(false);
            pooledSubstances.Add(tmpSubstance);
        }

        for(int i = 0; i < amountToPool; i++)
        {
            tmpBadSubstance = Instantiate(objectToPool[1], parent);
            tmpBadSubstance.SetActive(false);
            pooledBadSubstances.Add(tmpBadSubstance);
        }
        OnCompletePooled?.Invoke();
    }

   public GameObject GetSubstance()
   {
        for(int x = 0; x < amountToPool; x++)
        {
            // apakah game object yang di pool, aktif apa bukan? jika tidak aktif maka kasih ke caller.
            if(!pooledSubstances[x].activeInHierarchy){
                return pooledSubstances[x];
            } 
        }
        return null;
   }

     public GameObject GetBadSubstance()
   {
        for(int x = 0; x < amountToPool; x++)
        {
            // apakah game object yang di pool, aktif apa bukan? jika tidak aktif maka kasih ke caller.
            if(!pooledBadSubstances[x].activeInHierarchy){
                return pooledBadSubstances[x];
            } 
        }
        return null;
   }
}
