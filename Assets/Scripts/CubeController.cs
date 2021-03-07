using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public CubeSpawner cubeSpawner;
    private void Awake()
    {
        cubeSpawner = GameObject.Find("CubeContainer").GetComponent<CubeSpawner>();
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "DynamicCube")
        {
            Destroy(target.gameObject);
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            cubeSpawner.CreatedCubes.Remove(this.gameObject);
        }
    }
}
