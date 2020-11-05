using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

public class move : MonoBehaviour
{
    public budowaczPlytek budowacz_Plansz;
    private int kto = 0;
    private Menager.Player aktualnyPlayer;
    private List<Menager.Player> plejerowie;
    public Material glow;
    public Material zeroCztery;
    public Material zeroJeden;
    void Start()
    {

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            aktualnyPlayer = plejerowie[kto];
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            GameObject collider = new GameObject();
            collider = hit.collider.gameObject;

            if (collider.GetComponent<poruszacz>())
            {
                GameObject masa = new GameObject();
                if (aktualnyPlayer.Kolor.name == "yellow")
                {
                    masa = collider.transform.GetChild(0).gameObject;
                }
                else if (aktualnyPlayer.Kolor.name == "red")
                {
                    masa = collider.transform.GetChild(1).gameObject;
                }
                else if (aktualnyPlayer.Kolor.name == "blue")
                {
                    masa = collider.transform.GetChild(1).gameObject;
                }
                else
                {
                    masa = collider.transform.GetChild(0).gameObject;
                }
                Material[] materialy = masa.GetComponent<Renderer>().materials;
                if (materialy[0].name == "swiecak (Instance)")
                {
                    Vector3 aktualnaPozycja;
                    aktualnaPozycja = collider.GetComponent<poruszacz>().poruszanie(aktualnyPlayer, zeroCztery, zeroJeden, plejerowie);
                    kto++;
                    kto = kto % 4;
                    for (int i = 0; i < 4; i++)
                    {
                        GameObject cialko = new GameObject();
                        if (aktualnyPlayer.Kolor.name == "yellow")
                        {
                            cialko = plejerowie[kto].Ludziki[i].Chinczyk.transform.GetChild(1).gameObject;
                        }
                        else if (aktualnyPlayer.Kolor.name == "red")
                        {
                            cialko = plejerowie[kto].Ludziki[i].Chinczyk.transform.GetChild(1).gameObject;
                        }
                        else if (aktualnyPlayer.Kolor.name == "blue")
                        {
                            cialko = plejerowie[kto].Ludziki[i].Chinczyk.transform.GetChild(0).gameObject;
                        }
                        else
                        {
                            cialko = plejerowie[kto].Ludziki[i].Chinczyk.transform.GetChild(0).gameObject;
                        }
                        Material[] mats = cialko.GetComponent<Renderer>().materials;
                        for (int x = 0; x <mats.Length; x++)
                        {
                            mats[x] = glow;
                        }
                        cialko.GetComponent<Renderer>().materials = mats;
                    }
                }
            }
        }
    }
    public void zbieraczPlayerow()
    {

    }
    public void ruch(List<Menager.Player> allPlayers)
    {
        plejerowie = allPlayers;
        for (int i = 0; i < 4; i++)
        {
            GameObject cialko = plejerowie[kto].Ludziki[i].Chinczyk.transform.GetChild(0).gameObject;
            Material[] mats = cialko.GetComponent<Renderer>().materials;
            mats[0] = glow;
            mats[1] = glow;
            cialko.GetComponent<Renderer>().materials = mats;
        }
        /*if (randomowo == 1 || randomowo == 6)

        {

        }
        */
    }
}