using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AD移動 : MonoBehaviour
{
    [SerializeField]KeyCode 左 = KeyCode.A;
    [SerializeField] KeyCode 右 = KeyCode.D;
    [SerializeField] GameObject 角色;
    [SerializeField] float 左邊界;
    [SerializeField] float 右邊界;
    [SerializeField][Range(1,100)] float 速度=1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(左) && this.transform.position.x > 左邊界)
        {
            this.gameObject.transform.position += new Vector3(-速度, 0, 0)*Time.deltaTime;
            角色.transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKey(右) &&  this.transform.position.x < 右邊界)
        {
            this.gameObject.transform.position += new Vector3(速度, 0, 0) * Time.deltaTime;
            角色.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (this.transform.position.x < 左邊界) this.transform.position = new Vector3(左邊界, this.transform.position.y, this.transform.position.z);
        if (this.transform.position.x > 右邊界) this.transform.position = new Vector3(右邊界, this.transform.position.y, this.transform.position.z);
    }
}
