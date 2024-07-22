using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnerLab : MonoBehaviour
{
    public GameObject[] primitives;
    // Start is called before the first frame update
    public void SpawnObject(int primitiveNumber, string primitiveCharacterisitcs)
    {
        GameObject primitive = Instantiate(primitives[primitiveNumber], transform);
        primitive.GetComponentInChildren<TMP_Text>().text = primitiveCharacterisitcs;
        print("Spawned");
        StartCoroutine(DestroyPrimitive(primitive));
        StartCoroutine(RotateObject(primitive));
    }

    public IEnumerator DestroyPrimitive(GameObject primitive)
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(primitive);
        StopAllCoroutines();
    }

    public IEnumerator RotateObject(GameObject primitive)
    {
        while (true)
        {
            //primitive.GetComponentInChildren<Rigidbody>().MoveRotation(Quaternion.AngleAxis(30.0f, Vector3.right));
            primitive.GetComponentInChildren<Rigidbody>().AddTorque(new Vector3(200,100,0));
            yield return new WaitForSeconds(0.2f);
        }
    }
}
