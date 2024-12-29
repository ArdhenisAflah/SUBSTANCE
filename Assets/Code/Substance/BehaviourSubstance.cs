using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BehaviourSubstance : MonoBehaviour
{
    public static event Action<string> OnFinishCountObject;
    public static event Action OnSpawnGoodCountObject;
    public AudioClip explosion;

    void Awake()
    {
        
    }
    public static void WhenFinish(GameObject obj)
    {
        // this goes mainly to the substance counter
        OnFinishCountObject?.Invoke(obj.tag);
        obj.SetActive(false); 
    }

    public static void WhenGoodSpawn()
    {
        // this invocation event on EndGameManager script straight
        OnSpawnGoodCountObject?.Invoke();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Gate")){
            // explosion effect suara (plis bekerjaa jangan error lagi ya)
            AudioManager.Instance.playSFX(explosion);
            // reset
            this.gameObject.SetActive(false);
        }
    }
}
