using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSubstance : MonoBehaviour
{
    [SerializeField] Transform[] targets;
    private float speed = 3f;
    public int counter = 0;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(Walking());
    }

    // Update is called once per frame
    void Update()
    {   
    }

    IEnumerator Walking()
    {
        Debug.Log("Move");
        while(counter < targets.Length)
        {
            float step = speed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position,targets[counter].position,step);
            if(this.transform.position == targets[counter].position){
                counter++;
            }
            yield return null;
        }
    }

}
