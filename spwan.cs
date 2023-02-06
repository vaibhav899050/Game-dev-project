using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwan : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject source;
    public GameObject cloneprefab;
    public float timeer = 3f;
    private float nextActionTime = 0.0f;
    public float period = 2f;
    int i = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            i++;
            if (i < 5)
            {
                spwanobj();
            }
        }


    }
    void spwanobj()
    {
        Vector2 v = new Vector2(source.transform.position.x-1f, 0f);
        Instantiate(cloneprefab, v, source.transform.rotation);
    }
}
