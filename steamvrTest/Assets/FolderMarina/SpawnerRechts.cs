using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRechts : MonoBehaviour
{

    public GameObject[] cubes;
    public Transform[] points;
    public float beat = (60 / 100);
    public float timer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int show = Random.Range(1, 7);
        //Debug.Log(show);
        if (show < 4)
        {
            GameObject cube;
            if (timer > beat)
            {
                int index = 13;
                int number = Random.Range(0, 15);

                if (number < index)
                {
                    cube = Instantiate(cubes[0], points[Random.Range(0, points.Length)]);
                    //welcher Würfel + anwelher Position
                }else{
                    cube = Instantiate(cubes[1], points[Random.Range(0, points.Length)]);
                }
                // GameObject cube = Instantiate(cubes[Random.Range(0, cubes.Length)], points[Random.Range(0, points.Length)]);
                cube.transform.localPosition = Vector3.zero;
                //cube.transform.localPosition = new Vector3(0, Range.Random(0, 4), 0); -> variable Position
                cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
                timer -= beat;
            }
            timer += Time.deltaTime;
        }
        show = 0;
    }
}

