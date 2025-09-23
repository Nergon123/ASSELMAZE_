using System.Collections;
using UnityEngine;

public class camerarandom : MonoBehaviour
{
    Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
        StartCoroutine(RandomCameraColor());
    }
    IEnumerator RandomCameraColor()
    {
        while (true)
        {
            //epilepsy hell, I know (changed delay 2 times from 0.05 to 0.2 and from 0.2 to 0.4 seconds)
            yield return new WaitForSeconds(0.4f);
            cam.backgroundColor = Random.ColorHSV();
        }

    }
}
