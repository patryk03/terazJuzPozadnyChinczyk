using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kostkoRzucacz : MonoBehaviour
{
    public Material dice1;
    public Material dice2;
    public Material dice3;
    public Material dice4;
    public Material dice5;
    public Material dice6;
    public bool kostkaWTrakcieRzutu = false;
    private int iloscRzutow = 0;
    public float czas;
    private float odjety;
    private int randomowo;
    public int wyjsciowa;
    private Dictionary<int, Material> dic = new Dictionary<int, Material>();
    // Start is called before the first frame update
    void Start()
    {
        dic.Add(1, dice1);
        dic.Add(2, dice2);
        dic.Add(3, dice3);
        dic.Add(4, dice4);
        dic.Add(5, dice5);
        dic.Add(6, dice6);
    }

    // Update is called once per frame
    void Update()
    {
        if (kostkaWTrakcieRzutu)
        {
            odjety = Time.time;
        }
        if(kostkaWTrakcieRzutu && ((iloscRzutow<15 && (odjety - czas) > 0.15) || iloscRzutow == 0))
        {
            
            System.Random rnd = new System.Random();
            randomowo = rnd.Next(1, 7);

            Material[] mats = gameObject.GetComponent<Renderer>().materials;
            mats[0] = dic[randomowo];
            gameObject.GetComponent<Renderer>().materials = mats;
            iloscRzutow += 1;
            czas = Time.time;
        }
        else if(iloscRzutow>=10)
        {
            kostkaWTrakcieRzutu = false;
            iloscRzutow = 0;
            wyjsciowa = randomowo;
        }
    }
}
