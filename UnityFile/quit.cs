//結束程式。
using UnityEngine;
using System.Collections;

public class quit : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        Application.Quit();
        Debug.Log("EXIT!!!!");
    }
}
