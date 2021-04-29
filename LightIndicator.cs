using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightIndicator : MonoBehaviour
{
    public Sprite GreenLight;
    public Sprite YellowLight;
    public Sprite RedLight;
    public static string lightColor = "green";

    void Start()
    {
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

        yield return new WaitForSeconds(10f);
        lightColor = "green";

        StartCoroutine("WaitAndExecute");
    }

    void Update()
    {
        if(lightColor == "green")
        {
            this.gameObject.GetComponent<Image>().sprite = GreenLight;
        }
        else if(lightColor == "yellow")
        {
            this.gameObject.GetComponent<Image>().sprite = YellowLight;
        }
        else
        {
            this.gameObject.GetComponent<Image>().sprite = RedLight;
        }
    }
}
