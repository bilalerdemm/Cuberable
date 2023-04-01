using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class CollectableManager : MonoBehaviour
{
    public List<GameObject> collectedCubes = new List<GameObject>();
    public Transform cubePoint;

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            string s = "";

            for (int i = 0; i < collectedCubes.Count; ++i)
                s += collectedCubes[i].gameObject.name;

            Debug.Log(s);
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            other.gameObject.transform.parent = transform;
            other.gameObject.transform.DOLocalJump(cubePoint.transform.localPosition, .5f, 1, .1f);
            other.gameObject.transform.localRotation = cubePoint.transform.localRotation;
            collectedCubes.Add(other.gameObject);


            if (collectedCubes.Count >= 1)
            {
                for (int i = 0; i < collectedCubes.Count - 1; i++)
                {
                    collectedCubes[i].gameObject.transform.position += new Vector3(0, 1, 0);
                }
                //other.gameObject.transform.parent = transform;
                //collectedCubes.Add(other.gameObject);
                //other.gameObject.transform.DOLocalJump(cubePoint.transform.localPosition, .5f, 1, 1f);
                //other.gameObject.transform.localRotation = cubePointUp.transform.localRotation;
            }





            //cubePoint.transform.position += new Vector3(0, 1, 0);


            //if (collectedCubes.Count > 1)
            //{
            //    for (int i = collectedCubes.Count - 1; i <= 0; i--)
            //    {
            //        collectedCubes[i].gameObject.transform.position += new Vector3(0, 1 * collectedCubes.Count, 0);
            //        collectedCubes2.Add(collectedCubes[i].gameObject);
            //        collectedCubes.Remove(collectedCubes[collectedCubes.Count - 1].gameObject);
            //    }
            //}



            //if (collectedCubes.Count >= 1)
            //{
            //    other.gameObject.transform.parent = transform;
            //    other.gameObject.transform.DOLocalJump(cubePoint.transform.localPosition, .5f, 1, 1f);
            //    for (int i = 0; i < collectedCubes.Count; i++)
            //    {
            //        collectedCubes[i].gameObject.transform.position += new Vector3(0, 1, 0);
            //    }
            //    //collectedCubes[collectedCubes.Count - 1].gameObject.transform.DOLocalMove(cubePointUp.transform.localPosition, .5f);

            //    collectedCubes.Add(other.gameObject);
            //    other.gameObject.transform.localRotation = cubePointUp.transform.localRotation;
            //    //cubePointUp.transform.position += new Vector3(0, 1, 0);
            //    other.gameObject.transform.DOLocalJump(cubePointUp.transform.localPosition, .5f, 1, 1f);

            //}

        }
    }
}
