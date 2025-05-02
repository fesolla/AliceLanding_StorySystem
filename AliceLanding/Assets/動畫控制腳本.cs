using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
using Unity.VisualScripting;

public class 動畫控制腳本 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation 艾莉絲;
   

    private void Awake()
    {

        //艾莉絲.AnimationState.Complete += 完成();
        艾莉絲.AnimationState.SetAnimation(0, "NORMAL", true);

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void 改變 (int A,string B ,bool C)
    {
        艾莉絲.AnimationState.SetAnimation(A,B,C);
        //艾莉絲.AnimationState.AddAnimation(A, B, C,0);
       

    }
    public void 完成()
    {

    }
}
