using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class budowaczPlytek : MonoBehaviour
{

    public UnityEngine.Quaternion rroro;
    public Material blue;
    public Material red;
    public Material yellow;
    public Material green;
    public Material gray;
    private int[] listaMinusow = {8,10,18,20,28,30,38};
    private int[] listaPlusow = { 4, 14, 24, 34 };
    private int[] listaKolorow = { 10, 20, 30 };
    void Start()
    {

    }
    void Update()
    {

    }
    public List<GameObject> buduj_plansze(GameObject prefab, GameObject pusty, int ktore, GameObject dodatek)
    {
        Dictionary<int, Material> dic = new Dictionary<int, Material>();
        dic.Add(10, red);
        dic.Add(20, blue);
        dic.Add(30, green);
        dic.Add(1, yellow);
        dic.Add(2, red);
        dic.Add(3, blue);
        dic.Add(4, green);
        Material material = yellow;
        List<GameObject> createdObjects = new List<GameObject>();
        for (int pole = 1; pole <= 40; pole++)
        {
            GameObject newPrefab = Instantiate(prefab, pusty.transform.position, pusty.transform.rotation);
            newPrefab.GetComponent<MeshRenderer>().material = material;
            newPrefab.transform.SetParent(this.transform, true);
            newPrefab.name = "pole" + pole;
            createdObjects.Add(newPrefab);
            pusty.transform.Translate(transform.forward * 10);
            if(listaMinusow.Contains(pole))
            {
                pusty.transform.Rotate(0, 90.0f, 0);
            }
            else if(listaPlusow.Contains(pole))
            {
                pusty.transform.Rotate(0, -90.0f, 0);
            }
            if(listaKolorow.Contains(pole))
            {
                material = dic[pole];
            }
            else
            {
                material = gray;
            }
        }
        if (ktore > 0)
        {

            pusty.transform.Translate(transform.forward * -10);
            material = dic[ktore];
            pusty.transform.Rotate(0, 90.0f, 0);
            for (int pole = 41; pole <= 48; pole++)
            {
                if (pole <=44)
                {
                    pusty.transform.Translate(transform.forward * 10);
                }
                else if (pole > 44)
                {
                    if (ktore == 1 || ktore == 4)
                    {
                        if (pole == 45)
                        {
                            pusty.transform.Rotate(0, -90.0f, 0);
                            pusty.transform.Translate(transform.forward * 30);
                            pusty.transform.Rotate(0, -90.0f, 0);
                            pusty.transform.Translate(transform.forward * 20);
                            pusty.transform.Rotate(0, 180.0f, 0);
                        }
                        else if (pole == 46)
                        {
                            pusty.transform.Translate(transform.right * -10);
                        }
                        else if (pole == 47)
                        {
                            pusty.transform.Translate(transform.forward * -10);
                        }
                        else
                        {
                            pusty.transform.Translate(transform.right * 10);
                        }
                    }
                    else
                    {
                        if (pole == 45)
                        {
                            pusty.transform.Rotate(0, -90.0f, 0);
                            pusty.transform.Translate(transform.forward * 40);
                            pusty.transform.Rotate(0, -90.0f, 0);
                            pusty.transform.Translate(transform.forward * 30);
                        }
                        else if (pole == 46)
                        {
                            pusty.transform.Translate(transform.right * -10);
                        }
                        else if (pole == 47)
                        {
                            pusty.transform.Translate(transform.forward * -10);
                        }
                        else
                        {
                            pusty.transform.Translate(transform.right * 10);
                        }
                    }
                }

                GameObject newPrefab = Instantiate(dodatek, pusty.transform.position, pusty.transform.rotation);
                newPrefab.GetComponent<MeshRenderer>().material = material;
                newPrefab.transform.SetParent(this.transform, true);
                newPrefab.name = "pole" + pole;
                createdObjects.Add(newPrefab);
            }
        }
        return createdObjects;
    }
}
