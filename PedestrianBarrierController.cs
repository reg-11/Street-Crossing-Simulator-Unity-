using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianBarrierController : MonoBehaviour
{
    Collider barrier;
    public string lightColor = "green";

    void Start()
    {
        barrier = this.gameObject.GetComponent<Collider>();
        
        StartCoroutine("WaitAndExecute");
    }

    void StopExecution()
    {
        StopCoroutine("WaitAndExecute");
    }

    IEnumerator WaitAndExecute()
    {
        yield return new WaitForSeconds(25f);
        lightColor = "yellow";

        yield return new WaitForSeconds(5f);
        lightColor = "red";
        barrier.enabled = !barrier.enabled;

        yield return new WaitForSeconds(10f);
        lightColor = "green";
        barrier.enabled = !barrier.enabled;

        StartCoroutine("WaitAndExecute");
    }

}
