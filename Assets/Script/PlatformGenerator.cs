using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform;
    public GameObject theBackground; // เพิ่ม GameObject สำหรับพื้นหลังของเกม
    public Transform generationPoint;
    public float distanceBetween;
    private float platformWidth;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    // Start is called before the first frame update
    void Start()
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;

        // สร้าง GameObject สำหรับพื้นหลังของเกม
        Instantiate(theBackground, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            Instantiate(thePlatform, transform.position, transform.rotation);
        }
    }

}
