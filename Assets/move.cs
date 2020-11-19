using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public GameObject calosc;
    public Canvas canvas;
    public budowaczPlytek budowacz_Plansz;
    private int kto = 0;
    private Menager.Player aktualnyPlayer;
    private List<Menager.Player> plejerowie;
    public Material glow;
    public Material zeroCztery;
    public Material zeroJeden;
    private bool czyGrac = false;
    public int randomowo = 0;
    private GameObject swiecicielKolorku;
    private GameObject masa;
    private GameObject cialko;
    private bool isGameOver = false;
    private string wygrany;
    void Start()
    {

    }

    void Update()
    {
        if (isGameOver == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                aktualnyPlayer = plejerowie[kto];
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Physics.Raycast(ray, out hit);
                GameObject collider = hit.collider.gameObject;

                if (collider.GetComponent<poruszacz>() && czyGrac == true)
                {

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
                        masa = collider.transform.gameObject;
                    }
                    Material[] materialy = masa.GetComponent<Renderer>().materials;
                    if (materialy[0].name == "swiecak (Instance)")
                    {
                        isGameOver = collider.GetComponent<poruszacz>().poruszanie(aktualnyPlayer, zeroCztery, zeroJeden, plejerowie, randomowo);
                        if(isGameOver)
                        {
                            wygrany = aktualnyPlayer.Kolor.name;
                        }
                        kto++;
                        kto = kto % 4;

                    }
                    czyGrac = false;
                    Material[] kolorkiWyswietlacza = swiecicielKolorku.GetComponent<Renderer>().materials;
                    kolorkiWyswietlacza[0] = plejerowie[kto].Kolor;
                    swiecicielKolorku.GetComponent<Renderer>().materials = kolorkiWyswietlacza;
                }
                else if (collider.GetComponent<kostkoRzucacz>() && czyGrac == false)
                {
                    bool jakiekolwiekLudziki = false;
                    randomowo = collider.GetComponent<kostkoRzucacz>().rzutKostki();
                    for (int i = 0; i < (4 - aktualnyPlayer.IleZniszczonych); i++)
                    {
                        if ((randomowo == 6) || (aktualnyPlayer.Ludziki[i].CzyZbity == false))
                        {
                            if (aktualnyPlayer.Kolor.name == "yellow")
                            {
                                cialko = plejerowie[kto].Ludziki[i].Chinczyk.transform.GetChild(0).gameObject;
                            }
                            else if (aktualnyPlayer.Kolor.name == "red")
                            {
                                cialko = plejerowie[kto].Ludziki[i].Chinczyk.transform.GetChild(1).gameObject;
                            }
                            else if (aktualnyPlayer.Kolor.name == "blue")
                            {
                                cialko = plejerowie[kto].Ludziki[i].Chinczyk.transform.GetChild(1).gameObject;
                            }
                            else
                            {
                                cialko = plejerowie[kto].Ludziki[i].Chinczyk.transform.gameObject;
                            }
                            Material[] mats = cialko.GetComponent<Renderer>().materials;
                            for (int x = 0; x < mats.Length; x++)
                            {
                                mats[x] = glow;
                            }
                            cialko.GetComponent<Renderer>().materials = mats;
                            jakiekolwiekLudziki = true;
                        }
                    }
                    if(jakiekolwiekLudziki)
                    {
                        czyGrac = true;
                    }
                    else
                    {
                        kto++;
                        kto = kto % 4;
                        aktualnyPlayer = plejerowie[kto];
                        Material[] kolorkiWyswietlacza = swiecicielKolorku.GetComponent<Renderer>().materials;
                        kolorkiWyswietlacza[0] = plejerowie[kto].Kolor;
                        swiecicielKolorku.GetComponent<Renderer>().materials = kolorkiWyswietlacza;
                    }
                }
            }
        }
        else
        {
            calosc.gameObject.SetActive(false);
            canvas.transform.GetChild(1).gameObject.SetActive(false);
            canvas.transform.GetChild(0).gameObject.SetActive(true);
            canvas.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Wygrał" + wygrany;
        }

    }
    public void ruch(List<Menager.Player> allPlayers, GameObject wyswietlaczKolorku)
    {
        plejerowie = allPlayers;
        swiecicielKolorku = wyswietlaczKolorku;
        swiecicielKolorku.transform.SetParent(calosc.transform);
    }
}