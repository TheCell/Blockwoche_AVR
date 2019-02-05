using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMarina : MonoBehaviour {

        public GameObject[] cubes;
        public Transform[] points;
        public float beat = (60 / 130);
        public float timer;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (timer > beat)
            {
            int index = 80;


                GameObject cube = Instantiate(cubes[Random.Range(0, cubes.Length)], points[Random.Range(0, points.Length)]);
            // programmieren über 

                cube.transform.localPosition = Vector3.zero;
                cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
                timer -= beat;
            }

            timer += Time.deltaTime;
        }
}

