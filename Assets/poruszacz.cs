using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class poruszacz : MonoBehaviour
{
    private GameObject cialko;
    void Start()
    {

    }
    void Update()
    {

    }
    public bool poruszanie(Menager.Player aktualnyPlayer, Material zeroCztery, Material zeroJeden, List<Menager.Player> plejerowie, int randomowo)
    {
        bool isGameOver = false;
        int b = 0;
        bool granica = true;
        for (int i = 0; i < (4 - aktualnyPlayer.IleZniszczonych); i++)
        {
            if (aktualnyPlayer.Ludziki[i].Chinczyk == transform.gameObject)
            {
                b = i;
                break;
            }
        }
        if (aktualnyPlayer.Ludziki[b].CzyZbity == true)
        {
            aktualnyPlayer.Ludziki[b].Liczba = 0;
            aktualnyPlayer.Ludziki[b].CzyZbity = false;
        }
        else if (aktualnyPlayer.Ludziki[b].Liczba + randomowo < 44)
        {
            aktualnyPlayer.Ludziki[b].Liczba = aktualnyPlayer.Ludziki[b].Liczba + randomowo;
        }
        else if (aktualnyPlayer.Ludziki[b].Liczba + randomowo == 44)
        {
            aktualnyPlayer.Ludziki.Remove(aktualnyPlayer.Ludziki[b]);
            Destroy(gameObject);
            aktualnyPlayer.IleZniszczonych += 1;
            if (aktualnyPlayer.IleZniszczonych == 4)
            {
                isGameOver = true;
            }
            granica = false;
        }
        else
        {
            granica = false;
        }
        if (granica)
        {
            transform.position = aktualnyPlayer.ListaMiejsc[aktualnyPlayer.Ludziki[b].Liczba].transform.position;
            transform.rotation = aktualnyPlayer.ListaMiejsc[aktualnyPlayer.Ludziki[b].Liczba].transform.rotation;
            if (aktualnyPlayer.Kolor.name == "green")
            {
                transform.Rotate(-90, 90.0f, 0);
            }
            else
            {
                transform.Rotate(0, 90.0f, 0);
            }
        }

        float g = transform.position.x;
        float p = transform.position.z;
        float y = transform.position.y;
        System.Math.Round(g);
        System.Math.Round(p);
        transform.position = new Vector3(g, y,p );
        for (int x = 0; x < 4; x++)
        {
            Menager.Player playerDoTestowania = plejerowie[x];
            if (playerDoTestowania != aktualnyPlayer)
            {
                for (int i = 0; i < (4-playerDoTestowania.IleZniszczonych); i++)
                {
                    Menager.Ludzik ludzikTeraz = playerDoTestowania.Ludziki[i];
                    if (ludzikTeraz.CzyZbity == false)
                    {
                        double a;
                        double k;
                        double l;
                        double z;
                        a = Math.Round(ludzikTeraz.Chinczyk.transform.position.x);
                        k = Math.Round(transform.position.x);
                        l = Math.Round(ludzikTeraz.Chinczyk.transform.position.z);
                        z = Math.Round(transform.position.z);
                        if ((a == k) && (l == z))
                        {
                            ludzikTeraz.Chinczyk.transform.position = playerDoTestowania.ListaMiejsc[ludzikTeraz.Poczatek].transform.position;
                            ludzikTeraz.Chinczyk.transform.rotation = ludzikTeraz.PoczatkowaRotacja;
                            ludzikTeraz.CzyZbity = true;
                        }
                    }
                }
            }
        }
        for (int i = 0; i < (4 - aktualnyPlayer.IleZniszczonych); i++)
        {
            
            if (aktualnyPlayer.Kolor.name == "yellow")
            {
                cialko = aktualnyPlayer.Ludziki[i].Chinczyk.transform.GetChild(0).gameObject;
            }
            else if (aktualnyPlayer.Kolor.name == "red")
            {
                cialko = aktualnyPlayer.Ludziki[i].Chinczyk.transform.GetChild(1).gameObject;
            }
            else if (aktualnyPlayer.Kolor.name == "blue")
            {
                cialko = aktualnyPlayer.Ludziki[i].Chinczyk.transform.GetChild(1).gameObject;
            }
            else
            {
                cialko = aktualnyPlayer.Ludziki[i].Chinczyk.transform.gameObject;
            }
            Material[] mats = cialko.GetComponent<Renderer>().materials;
            for (int x = 0; x < mats.Length; x++)
            {
                mats[x] = aktualnyPlayer.KoloryLudzikow[x];
            }
            cialko.GetComponent<Renderer>().materials = mats;
        }
        return isGameOver;
    }
}
