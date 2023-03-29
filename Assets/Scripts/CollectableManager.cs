using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectableManager : MonoBehaviour
{
    public List<GameObject> collectedCubes = new List<GameObject>();
    public Transform cubePoint, cubePointUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            if (collectedCubes.Count < 1)
            {
                other.gameObject.transform.parent = transform;
                other.gameObject.transform.DOLocalJump(cubePoint.transform.localPosition, .5f, 1, 1f);
                other.gameObject.transform.localRotation = cubePoint.transform.localRotation;
                collectedCubes.Add(other.gameObject);
                //cubePoint.transform.position += new Vector3(0, 1, 0);

            }
            if (collectedCubes.Count >= 1)
            {

                collectedCubes[collectedCubes.Count - 1].gameObject.transform.DOLocalMove(cubePointUp.transform.localPosition, .5f);
                other.gameObject.transform.parent = transform;
                other.gameObject.transform.DOLocalJump(cubePoint.transform.localPosition, .5f, 1, 1f);
                collectedCubes.Add(other.gameObject);
                other.gameObject.transform.localRotation = cubePointUp.transform.localRotation;
                cubePointUp.transform.position += new Vector3(0, 1, 0);
                other.gameObject.transform.DOLocalJump(cubePointUp.transform.localPosition, .5f, 1, 1f);

            }

        }
    }
}
