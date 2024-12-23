using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSubstance : MonoBehaviour
{
    [SerializeField] GameObject[] PathWay;
    public List<Transform> targets = new List<Transform>();
    private float speed = 3f;
    public int counter;
    public int PathTotal;

    // Start is called before the first frame update
    void OnEnable()
    {
        Transform currentPath = PathWay[Random.Range(0,4)].transform;
        // fetching data dari parent PathWay untuk dapetin koordinat dari tiap children nya.
        foreach(Transform obj in currentPath)
        {
            targets.Add(obj);
        }

        // initial spawn counter, whether it stopped because when good substance out of stock, we stop the game
        this.transform.position = targets[0].position;
        // we check spawn for good substance for stock NIGGA! DONT DELETE THIS SHIT EHHEHEH
        if(gameObject.CompareTag("Substance")){
            BehaviourSubstance.WhenGoodSpawn();
        }

        // start process walking each individual bad and good substance
        StartCoroutine(Walking());
    }
    IEnumerator Walking()
    {
        // Debug.Log("Move");
        while(counter < targets.Count)
        {
            float step = speed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position,targets[counter].position,step);
            if(this.transform.position == targets[counter].position){
                counter++;
            }
            yield return null;
        }
        yield return new WaitForSeconds(1);
        BehaviourSubstance.WhenFinish(this.gameObject);
    }

    void OnDisable()
    {
        targets.Clear();
        counter = 0;
    }

}
