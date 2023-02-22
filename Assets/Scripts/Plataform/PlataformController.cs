using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformController : MonoBehaviour
{
    public Rigidbody platafromRB;
    public Transform[] platafromPositions;
    public float speed;

    int actualPosition = 0;
    int nextPosition = 1;

    public bool moveToTheNext = true;
    public float waitTime;

    // Update is called once per frame
    void Update()
    {
        movePlatfrom(); 
    }

    private void movePlatfrom()
    {
        if (moveToTheNext)
        {
            StopCoroutine(WaitForMove(0));
            platafromRB.MovePosition(Vector3.MoveTowards
                (platafromRB.position, platafromPositions[nextPosition].position,
                speed * Time.deltaTime));
        }
        if (Vector3.Distance(platafromRB.position,
            platafromPositions[nextPosition].position) <= 0)
        {
            StartCoroutine(WaitForMove(waitTime));
            actualPosition = nextPosition;
            nextPosition = AddNextPosition();
        }
    }

    private int AddNextPosition()
    {
        if (nextPosition +1 > platafromPositions.Length - 1)
        {
            return 0;
        }
        else
        {
            return nextPosition + 1;
        }
    }

    private IEnumerator WaitForMove(float time)
    {
        moveToTheNext = false;
        yield return new WaitForSeconds(time);
        moveToTheNext = true;
    }
}
