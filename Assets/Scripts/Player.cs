using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(speed * Time.deltaTime * Vector3.forward);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(speed * Time.deltaTime * Vector3.back);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(0f, 0.5f, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(0f, -0.5f, 0);
    }
}
