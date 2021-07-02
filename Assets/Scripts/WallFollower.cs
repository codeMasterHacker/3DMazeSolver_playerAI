using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFollower : MonoBehaviour
{
    public float distance = 1f;
    public float waitSecs = 0.9f;
    private bool isReady = true;

    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        if (isReady)
            StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        /*
        * # Wall follower, Right-hand Rule
        * While Not target_point
        *  If right is open Then
        *      turn_right
        *  Else If front is open Then
        *      go_forward
        *  Else If left is open Then
        *      turn_left
        *  Else
        *      Turn_around
        * Loop
        */

        isReady = false;

        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), distance))
        {
            transform.Rotate(0f, 90f, 0);

            if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), distance))
            {
                transform.Translate(Vector3.forward);
            }
        }
        else if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), distance))
        {
            transform.Translate(Vector3.forward);
        }
        else if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), distance))
        {
            transform.Rotate(0f, -90f, 0);

            if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), distance))
            {
                transform.Translate(Vector3.forward);
            }
        }
        else
        {
            transform.Rotate(0f, 180f, 0);

            if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), distance))
            {
                transform.Translate(Vector3.forward);
            }
        }

        yield return new WaitForSeconds(waitSecs);

        isReady = true;
    }
}
