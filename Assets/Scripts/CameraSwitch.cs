using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject PlayerCam;
    public GameObject OverviewCam;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SwitchTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SwitchTime()

    {
       yield return new WaitForSeconds(17f);
       OverviewCam.SetActive(false);
       PlayerCam.SetActive(true);


    }
}
