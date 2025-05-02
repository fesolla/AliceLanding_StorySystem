using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
//using static 動畫控制腳本;

public class 物理下墜 : MonoBehaviour
{
    [SerializeField][Range(0,100)] float 重力=9.8f;
    //[SerializeField][Range(0, 100)] float 上升力=10;
    [SerializeField] float 默認阻尼係數=1;
    [SerializeField] float 收裙子阻尼係數=2;
    [SerializeField] KeyCode 裙子按鈕 = KeyCode.S;
    [SerializeField] Transform 相機;
    [SerializeField] float 自由落體最大速A = 30;
    [SerializeField] float 自由落體最大速B = 60;
    float 阻尼=0;
    [SerializeField] float 當前速度 = 0;
    float 加速度 =0;
    [SerializeField]float 自由落體最大速 = 0;
    float[] E = {0.368f,0.135f,0.49f,0.007f,0f };
    int 計數器=0;
    float 時間=0;
    動畫控制腳本 ANI ;




    // Start is called before the first frame update
    void Start()
    {
        float 阻尼 = 0;
        float 當前速度 = 0;
        float 加速度 = 0;
        float[] E = { 0.368f, 0.135f, 0.49f, 0.007f, 0f };
        int 計數器 = 0;
        float 時間 = 0;
        float 自由落體最大速 = 0;
        ANI  = this.gameObject.GetComponent<動畫控制腳本>();
        //艾莉絲.AnimationState.SetAnimation(0, "FAST", true);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(裙子按鈕))
        {
            阻尼 = 收裙子阻尼係數;
            自由落體最大速 = 自由落體最大速B;
            //動畫控制腳本.instance.改變(0,"FAST",true);
            
            
        }
        else
        {
            阻尼 = 默認阻尼係數;
            自由落體最大速 = 自由落體最大速A;
            //動畫控制腳本.instance.改變(0,"NORMAL", true);
        }
        if (Input.GetKeyDown(裙子按鈕)) {

            當前速度 += 20;
            ANI.改變(0, "FAST", true);

        }
        else if (Input.GetKeyUp(裙子按鈕))
        {
            ANI.改變(0, "NORMAL", true);
        }
        加速度 = 重力 * (阻尼 / (阻尼 + 當前速度));
        當前速度 += 加速度 * Time.deltaTime;
        當前速度 = Mathf.Min(當前速度, 自由落體最大速);
        this.gameObject.transform.position -= new Vector3(0, 當前速度, 0) * Time.deltaTime;
        相機.transform.position -= new Vector3(0, 當前速度, 0) * Time.deltaTime;
    }

   
}

