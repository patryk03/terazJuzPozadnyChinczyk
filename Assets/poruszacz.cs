using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class poruszacz : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {

    }
    public Vector3 poruszanie(Menager.Player aktualnyPlayer, Material zeroCztery, Material zeroJeden, List<Menager.Player> plejerowie)
    {
        System.Random rnd = new System.Random();
        int b = 0;
        int randomowo = rnd.Next(1, 6);
        for (int i = 0; i < 4; i++)
        {
            if (aktualnyPlayer.Ludziki[i].Chinczyk.transform.position == transform.position)
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
        else
        {
            aktualnyPlayer.Ludziki[b].Liczba = aktualnyPlayer.Ludziki[b].Liczba + randomowo - 44;
        }
        transform.position = aktualnyPlayer.ListaMiejsc[aktualnyPlayer.Ludziki[b].Liczba].transform.position;
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
                for (int i = 0; i < 4; i++)
                {
                    Menager.Ludzik ludzikTeraz = playerDoTestowania.Ludziki[x];
                    if (ludzikTeraz.CzyZbity == false)
                    {
                        if (ludzikTeraz.Chinczyk.transform.position == transform.position)
                        {
                            ludzikTeraz.Chinczyk.transform.position = playerDoTestowania.ListaMiejsc[ludzikTeraz.Poczatek].transform.position;
                            ludzikTeraz.CzyZbity = true;
                        }
                    }
                }
            }
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject cialko = aktualnyPlayer.Ludziki[i].Chinczyk.transform.GetChild(0).gameObject;
            Material[] mats = cialko.GetComponent<Renderer>().materials;
            mats[0] = zeroCztery;
            mats[1] = zeroJeden;
            cialko.GetComponent<Renderer>().materials = mats;
        }
        return transform.position;
    }
}
