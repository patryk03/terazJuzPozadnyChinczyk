using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering;

public class Menager : MonoBehaviour
{

    public budowaczPlytek plansza;
    public move move;
    public List<GameObject> createdObjects;
    public GameObject kolumna;
    private UnityEngine.Quaternion rotation;
    public GameObject prefab;
    public GameObject pusty;
    private GameObject klucz;
    private int a = 0;
    private int b = 0;
    public Material blue;
    public Material red;
    public Material yellow;
    public Material green;
    private List<Player> createdPlayers;

    private
    void Start()
    {

        rotation = transform.rotation;
        List<List<GameObject>> listaWszystkiego = new List<List<GameObject>>();
        createdObjects = plansza.buduj_plansze(prefab, pusty, 0, kolumna);
        for (int i = 1; i < 5; i++)
        {
            List<GameObject> obiekty = new List<GameObject>();
            klucz = Instantiate(pusty, createdObjects[a].transform.position, rotation);
            klucz.transform.Rotate(0, 90.0f * b, 0);
            obiekty = plansza.buduj_plansze(pusty, klucz, i, prefab);
            listaWszystkiego.Add(obiekty);
            a = a + 10;
            b = b + 1;
        }
        createdPlayers = tworzycielPlayerow(listaWszystkiego);
        move.ruch(createdPlayers);
    }

    void Update()
    {

    }
    public class Ludzik
    {
        public UnityEngine.Vector3 Pozycja;
        public int Poczatek;
        public bool CzyZbity;
        public int Liczba;
        public GameObject Chinczyk;
        public Ludzik(bool czyZbity, UnityEngine.GameObject chinczyk, int liczba, int poczatek, UnityEngine.Vector3 pozycja)
        {
            this.Pozycja = pozycja;
            this.Chinczyk = chinczyk;
            this.CzyZbity = czyZbity;
            this.Liczba = liczba;
            this.Poczatek = poczatek;
        }
    }
    public class Player
    {
        public Material Kolor { get; private set; }
        public List<GameObject> ListaMiejsc { get; private set; }
        public List<Ludzik> Ludziki { get; private set; }


        public Player(Material kolor, List<GameObject> listaMiejsc, List<Ludzik> ludziki)
        {
            this.Kolor = kolor;
            this.ListaMiejsc = listaMiejsc;
            this.Ludziki = ludziki;
        }
    }
    public List<Player> tworzycielPlayerow(List<List<GameObject>> myList)
    {
        List<Player> stworzeniLudzie = new List<Player>();
        List<GameObject> listaMiejsc = new List<GameObject>();
        List<Ludzik> ludziki = new List<Ludzik>();
        for (int i = 0; i < 4; i++)
        {

            listaMiejsc = myList[i];
            if (i == 0)
            {
                ludziki = tworzycielLudzikow(yellow, myList[i]);
                Player player = new Player(yellow, listaMiejsc, ludziki);
                stworzeniLudzie.Add(player);
            }
            else if (i == 1)
            {
                ludziki = tworzycielLudzikow(red, myList[i]);
                Player player = new Player(red, listaMiejsc, ludziki);
                stworzeniLudzie.Add(player);
            }
            else if (i == 2)
            {
                ludziki = tworzycielLudzikow(blue, myList[i]);
                Player player = new Player(blue, listaMiejsc, ludziki);
                stworzeniLudzie.Add(player);
            }
            else
            {
                ludziki = tworzycielLudzikow(green, myList[i]);
                Player player = new Player(green, listaMiejsc, ludziki);
                stworzeniLudzie.Add(player);
            }

        }
        return stworzeniLudzie;
    }
    public List<Ludzik> tworzycielLudzikow(Material kolor, List<GameObject> list)
    {
        int x = 44;
        List<Ludzik> stworzonePostacie = new List<Ludzik>();
        UnityEngine.Vector3 startPosition;
        for (int i = 0; i < 4; i++)
        {
            bool czyZbity = true;
            startPosition = list[x].transform.position;
            GameObject newPrefab = Instantiate(kolumna, startPosition, rotation);
            //newPrefab.tag = kolor.name;
            newPrefab.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
            newPrefab.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
            CapsuleCollider capsuleCollider = newPrefab.AddComponent<CapsuleCollider>();
            newPrefab.GetComponent<CapsuleCollider>().radius = 4.33f;
            newPrefab.GetComponent<CapsuleCollider>().height = 25.3f;
            newPrefab.name ="" + i;
            newPrefab.AddComponent<poruszacz>();
            int liczba = -1;
            UnityEngine.Vector3 pozycja = new UnityEngine.Vector3(0, 0, 0);
            Ludzik ludzik = new Ludzik(czyZbity, newPrefab, liczba, x, pozycja);
            stworzonePostacie.Add(ludzik);
            x++;
        }
        return stworzonePostacie;
    }
}