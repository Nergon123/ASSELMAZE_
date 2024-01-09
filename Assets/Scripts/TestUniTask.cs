using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class TestUniTask : MonoBehaviour
{
    private async UniTask Test()
    {
        await UniTask.Delay(1000);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
