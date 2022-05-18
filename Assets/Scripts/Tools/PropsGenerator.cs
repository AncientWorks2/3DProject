using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class PropsGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabs;
    [SerializeField]
    private int numObjects;
    [SerializeField]
    private float rotX;
    [SerializeField]
    private float rotY;
    [SerializeField]
    private float rotZ;
    [SerializeField]
    private float distX;
    [SerializeField]
    private float distY;
    [SerializeField]
    private float distZ;
    [SerializeField]
    private float randomPosX;
    [SerializeField]
    private float randomPosY;
    [SerializeField]
    private float randomPosZ;
    [SerializeField]
    private float randomRotX;
    [SerializeField]
    private float randomRotY;
    [SerializeField]
    private float randomRotZ;


    public bool generateObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void GenareteProps()
    {
        if (generateObjects)
        {
            Debug.Log("Generating Platforms");

            GameObject gameo = new GameObject("StackObjects");

            Quaternion baseRotation = Quaternion.Euler(rotX, rotY, rotZ);

            for (int i = 0; i < numObjects; i++)
            {
                int numGenPrefab = UnityEngine.Random.Range(0, prefabs.Length);

                GameObject go;
                Vector3 basePosition = Vector3.right * distX + Vector3.forward * distZ + Vector3.up * distY;
                Vector3 position = RandomPosition(basePosition);
                Quaternion rotation = Quaternion.Euler(RandomRotation(baseRotation.eulerAngles));
                go = GameObject.Instantiate(prefabs[numGenPrefab], position, rotation);

                go.transform.parent = gameo.transform;
            }

            generateObjects = false;
        }
    }

    Vector3 RandomPosition(Vector3 pos)
    {
        pos += Vector3.right * UnityEngine.Random.Range(-randomPosX, randomPosX);
        pos += Vector3.up * UnityEngine.Random.Range(0, randomPosY);
        pos += Vector3.forward * UnityEngine.Random.Range(-randomPosZ, randomPosZ);

        return pos;
    }

    Vector3 RandomRotation(Vector3 rot)
    {

        rot += Vector3.right * UnityEngine.Random.Range(0, randomRotX);
        rot += Vector3.up * UnityEngine.Random.Range(0, randomRotY);
        rot += Vector3.forward * UnityEngine.Random.Range(0, randomRotZ);

        return rot;
    }

    public void DoPropGenerator()
    {
        generateObjects = true;
        GenareteProps();
    }

    [MenuItem("Custom Tools//Generate Props")]
    private static void GeneratePlatforms()
    {
        GameObject go = GameObject.Find("PropsGenerateTool");
        PropsGenerator editor = go.GetComponent<PropsGenerator>();
        editor.DoPropGenerator();
    }

}
