using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class budowaczPlytek : MonoBehaviour
{
    private UnityEngine.Quaternion rotation;
    public UnityEngine.Quaternion rroro;
    public Material blue;
    public Material red;
    public Material yellow;
    public Material green;
    public Material gray;
    void Start()
    {
        rotation = transform.rotation;
    }

    void Update()
    {

    }
    public List<GameObject> buduj_plansze(GameObject prefab, GameObject pusty, int ktore, GameObject dodatek)
    {
        Material material = yellow;
        int number = 1;
        List<GameObject> createdObjects = new List<GameObject>();
        for (int pole = 1; pole <= 40; pole++)
        {
            GameObject newPrefab = Instantiate(prefab, pusty.transform.position, rotation);
            newPrefab.GetComponent<MeshRenderer>().material = material;
            newPrefab.transform.SetParent(this.transform, true);
            newPrefab.name = "pole" + pole;
            GameObject childObj = new GameObject();
            childObj.transform.parent = newPrefab.transform;
            childObj.name = "Text Holder";
            TextMesh textMesh = childObj.AddComponent<TextMesh>();
            textMesh.characterSize = 2;
            textMesh.anchor = TextAnchor.MiddleCenter;
            textMesh.alignment = TextAlignment.Center;
            textMesh.transform.position = new UnityEngine.Vector3(newPrefab.transform.position.x, newPrefab.transform.position.y + 1, newPrefab.transform.position.z);
            textMesh.transform.Rotate(90.0f, 0.0f, 0.0f);
            textMesh.transform.rotation = rroro;
            number++;
            createdObjects.Add(newPrefab);
            if (pole < 5)
            {
                material = gray;
                pusty.transform.Translate(UnityEngine.Vector3.forward * -10);
            }
            else if (pole < 9)
            {
                if (pole == 5)
                {
                    pusty.transform.Rotate(0, 90.0f, 0);
                }
                pusty.transform.Translate(UnityEngine.Vector3.forward * 10);
            }
            else if (pole < 11)
            {
                if (pole == 9)
                {
                    pusty.transform.Rotate(0, -90.0f, 0);
                }
                pusty.transform.Translate(UnityEngine.Vector3.forward * -10);
                if (pole == 10)
                {
                    material = red;
                }
            }
            else if (pole < 15)
            {
                material = gray;
                if (pole == 11)
                {
                    pusty.transform.Rotate(0, -90.0f, 0);
                }
                pusty.transform.Translate(UnityEngine.Vector3.forward * 10);
            }

            else if (pole < 19)
            {
                if (pole == 15)
                {
                    pusty.transform.Rotate(0, 90.0f, 0);
                }
                pusty.transform.Translate(UnityEngine.Vector3.forward * -10);
            }
            else if (pole < 21)
            {
                if (pole == 19)
                {
                    pusty.transform.Rotate(0, -90.0f, 0);
                }
                pusty.transform.Translate(UnityEngine.Vector3.forward * 10);
                if (pole == 20)
                {
                    material = blue;
                }
            }
            else if (pole < 25)
            {
                material = gray;
                if (pole == 21)
                {
                    pusty.transform.Rotate(0, 90.0f, 0);
                }
                pusty.transform.Translate(UnityEngine.Vector3.forward * 10);
            }

            else if (pole < 29)
            {
                if (pole == 25)
                {
                    pusty.transform.Rotate(0, 90.0f, 0);
                }
                pusty.transform.Translate(UnityEngine.Vector3.forward * -10);
            }
            else if (pole < 31)
            {
                if (pole == 29)
                {
                    pusty.transform.Rotate(0, -90.0f, 0);
                }
                pusty.transform.Translate(UnityEngine.Vector3.forward * 10);
                if (pole == 30)
                {
                    material = green;
                }
            }
            else if (pole < 35)
            {
                material = gray;
                if (pole == 31)
                {
                    pusty.transform.Rotate(0, -90.0f, 0);
                }
                pusty.transform.Translate(UnityEngine.Vector3.forward * -10);
            }

            else if (pole < 39)
            {
                if (pole == 35)
                {
                    pusty.transform.Rotate(0, 90.0f, 0);
                }
                pusty.transform.Translate(UnityEngine.Vector3.forward * 10);
            }
            else if (pole < 40)
            {
                if (pole == 39)
                {
                    pusty.transform.Rotate(0, -90.0f, 0);
                }
                pusty.transform.Translate(UnityEngine.Vector3.forward * -10);
            }
        }
        material = yellow;
        if (ktore > 0)
        {
            for (int pole = 41; pole <= 48; pole++)
            {
                if (ktore == 1)
                {
                    material = yellow;
                }
                else if (ktore == 2)
                {
                    material = red;
                }
                else if (ktore == 3)
                {
                    material = blue;
                }
                else
                {
                    material = green;
                }
                if (pole >= 41 && pole < 45)
                {
                    if (pole == 41)
                    {
                        pusty.transform.Rotate(0, 90.0f, 0);
                    }
                    pusty.transform.Translate(UnityEngine.Vector3.forward * -10);
                }
                else if (pole > 44)
                {
                    if (pole == 45)
                    {
                        pusty.transform.Rotate(0, -90.0f, 0);
                        pusty.transform.Translate(UnityEngine.Vector3.forward * -30);
                        pusty.transform.Rotate(0, -90.0f, 0);
                        pusty.transform.Translate(UnityEngine.Vector3.forward * -20);
                    }
                    else
                    {
                        pusty.transform.Rotate(0, 90.0f, 0);
                    }
                }
                GameObject newPrefab = Instantiate(dodatek, pusty.transform.position, rotation);
                newPrefab.GetComponent<MeshRenderer>().material = material;
                newPrefab.transform.SetParent(this.transform, true);
                newPrefab.name = "pole" + pole;
                GameObject childObj = new GameObject();
                childObj.transform.parent = newPrefab.transform;
                childObj.name = "Text Holder";
                TextMesh textMesh = childObj.AddComponent<TextMesh>();
                textMesh.characterSize = 2;
                textMesh.anchor = TextAnchor.MiddleCenter;
                textMesh.alignment = TextAlignment.Center;
                textMesh.transform.position = new UnityEngine.Vector3(newPrefab.transform.position.x, newPrefab.transform.position.y + 1, newPrefab.transform.position.z);
                textMesh.transform.Rotate(90.0f, 0.0f, 0.0f);
                textMesh.transform.rotation = rroro;
                number++;
                createdObjects.Add(newPrefab);
                if (pole > 44)
                {
                    pusty.transform.Translate(UnityEngine.Vector3.forward * -10);
                }
            }
        }
        return createdObjects;
    }
}
