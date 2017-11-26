using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScriptHolderBehavior : MonoBehaviour
{
	// Use this for initialization
//	void Start ()
//    {
//		
//	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Test Sonar random object");
//            GameObject.Find("CubeRandom").GetComponent<SonarEffect>().CastWave();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Test Sonar JSON");
//            GameObject.Find("CubeJson").GetComponent<SonarEffect>().CastWave();
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            GameObject.Find("Main Camera").GetComponent<SonarFx>().enabled = !GameObject.Find("Main Camera").GetComponent<SonarFx>().enabled;
        }

	}
}
