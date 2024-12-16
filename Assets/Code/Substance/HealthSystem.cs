using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] public Transform spawnPosition;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Wall")){
            Debug.Log("Slayed");
            this.gameObject.transform.position = spawnPosition.position;
            this.gameObject.SetActive(false);
        }
         

    }
}
