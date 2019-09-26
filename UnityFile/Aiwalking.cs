//使用方法
//要導航自動尋走的object 就把Aiwalking 和 NavMeshAgent 兩個Scripts 加到該object裡(目標object不用)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiwalking : MonoBehaviour {

    public NavMeshAgent agent;    //宣告NavMeshAgent 要用來掛載此Script

    public GameObject Master;     // 主人 變數 (CameraRig)
    public Transform MasterRot;   // 用於判斷 Master 之方向
    public GameObject Slave;      // 僕人 變數   放 尋路NPC 自己本身

    public GameObject Navtarget;    //導航之目標物件   放目標物
    public int NPCMode, NPCFloor/* TargetFloor, TargetTemp*/ ;
    //         NPC模式  NPC所在樓層  目標所在樓層   目標位置暫存


    // Use this for initialization
    void Start () {  
        agent = GetComponent<NavMeshAgent> ();        //接收 NavMeshAgent
        Master = GameObject.Find("[CameraRig]");      // 把 [CameraRig] 自動設成master(不用自己拖)
        NPCMode = 1; // 1為 導航Nav模式 0為 跟隨玩家模式
        NPCFloor = 1;   // 0為 B1 1 為 一樓 以此類推
        Slave = GameObject.Find("NavNPC");            //將  設為 slave 之物件
        moveMenu temp = GetComponent<moveMenu>();
        temp.onclik = false;
    }
	
	// Update is called once per frame
	void Update () {

        if ( NPCMode == 1 )     //有尋路目標 代表NPC為尋路模式
        {
            
            agent.SetDestination(Navtarget.transform.position);    //讓object往目標物的座標移動


            Vector3 distance_MtoS = Master.transform.position - Slave.transform.position; //取得主 和 NPC 之間的向量
            Vector3 distance_goal = Navtarget.transform.position - Slave.transform.position; //取得目標點到方塊之間的向量
            float len_MtoS = distance_MtoS.magnitude;     // len 即 主 跟 僕 之距離
            float len_goal = distance_goal.magnitude;     // len 即 目標地點 跟 NavNPC 之距離
            distance_MtoS.Normalize();
            distance_goal.Normalize();

            if (len_MtoS > 10) //若 距離 >10 (離CameraRig 太遠)
            {
                agent.Stop();   //導航暫停
                transform.LookAt(MasterRot);   //轉向玩家
            }

            else
            {
                agent.Resume(); //導航狀態恢復
            }

            if( len_goal < 6)   //判斷是否到終點
            {
                  transform.LookAt(MasterRot);   //轉向玩家                
                Debug.Log("We have arrived!!!");
                Navtarget = GameObject.Find("[CameraRig]");               
                NPCMode = 0;                
                agent.Resume();
            }
        }
        else
        {            
            agent.SetDestination(Navtarget.transform.position);    //讓object往目標物的座標移動   
            if(temp.onclik = true)
            {
                agent.Stop();
            }
            else
            {
                agent.Resume();
            }
        }
    }
}
