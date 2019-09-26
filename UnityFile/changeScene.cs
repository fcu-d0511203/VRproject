//場景跳躍 ex.從Menu 點擊選項觸發後跳到 Main 場景。

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Threading;

public class changeScene : MonoBehaviour {
    public GameObject obj;

	// Use this for initialization
	void Start () {

        SceneManager.LoadScene("MainTest", LoadSceneMode.Additive);
        Thread.Sleep(1000);
        Destroy(obj);
    }
	
	
}
