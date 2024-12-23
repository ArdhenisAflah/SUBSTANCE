using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Components;
using UnityEngine;


public class BakeRuntime : MonoBehaviour
{
    public NavMeshSurface nvs;
    // [SerializeField] NavMeshSurface ns;
    // Start is called before the first frame update
    // void Start()
    // {
    //     nvs = GetComponent<NavMeshSurface>();
    //     StartCoroutine(UpdateBake());
    // }

    // IEnumerator UpdateBake()
    // {
    //     while(true)
    //     {
    //         yield return new WaitForSeconds(1.5f);
    //         nvs.BuildNavMesh();
    //     }
    // }

    void Update()
    {
        nvs.UpdateNavMesh(nvs.navMeshData);
    }
}
