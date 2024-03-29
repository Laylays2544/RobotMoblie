using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    //public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;

    public ObjectPooler[] theObjectPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    public float randomLaserThreshold;
    public ObjectPooler laserPool;
    public ObjectPooler laserPool2;
    public ObjectPooler laserPool3;

    // Start is called before the first frame update
    void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;

        platformWidths = new float[theObjectPools.Length];

        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, theObjectPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if(heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

            

            //Instantiate(/* thePlatform */ thePlatforms[platformSelector], transform.position, transform.rotation);


            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if(Random.Range(0f, 100f) < randomLaserThreshold)
            {
                GameObject newLaser = laserPool.GetPooledObject();

                float laserXPosition = Random.Range(-platformWidths[platformSelector] / 3f + 1f, platformWidths[platformSelector] / 3f - 1f);

                Vector3 laserPosition = new Vector3(laserXPosition, 1f, 0f);

                newLaser.transform.position = transform.position + laserPosition;
                newLaser.transform.rotation = transform.rotation;
                newLaser.SetActive(true);
            }

            if (Random.Range(0f, 200f) < randomLaserThreshold)
            {
                GameObject newLaser2 = laserPool2.GetPooledObject();

                float trapXPosition = Random.Range(-platformWidths[platformSelector] / 3f + 1f, platformWidths[platformSelector] / 3f - 1f);

                Vector3 trapPosition = new Vector3(trapXPosition, 1.5f, 0f);

                newLaser2.transform.position = transform.position + trapPosition;
                newLaser2.transform.rotation = transform.rotation;
                newLaser2.SetActive(true);
            }

            if (Random.Range(0f, 300f) < randomLaserThreshold)
            {
                GameObject newLaser2 = laserPool3.GetPooledObject();

                float trapXPosition = Random.Range(-platformWidths[platformSelector] / 3f + 1f, platformWidths[platformSelector] / 3f - 1f);

                Vector3 trapPosition = new Vector3(trapXPosition, 1f, 0f);

                newLaser2.transform.position = transform.position + trapPosition;
                newLaser2.transform.rotation = transform.rotation;
                newLaser2.SetActive(true);
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
        }
    }

}
