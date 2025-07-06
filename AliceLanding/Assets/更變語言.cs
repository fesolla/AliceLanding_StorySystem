using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;

public class 更變語言 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LanguageManagerBase.Instance.CurrentLanguage = "jp";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
