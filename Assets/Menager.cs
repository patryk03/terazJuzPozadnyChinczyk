using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Menager : MonoBehaviour
{
    public GameObject kostka;
    public GameObject trzymaczLudzikow;
    public Canvas canvas;
    public Material samuraj;
    public budowaczPlytek plansza;
    public move move;
    public List<GameObject> createdObjects;
    public GameObject kolumna1;
    public GameObject kolumna2;
    public GameObject kolumna3;
    public GameObject kolumna4;
    public GameObject prefab;
    public GameObject pusty;
    private GameObject klucz;
    private int a = 0;
    private int b = 1;
    public Material blue;
    public Material red;
    public Material yellow;
    public Material green;
    private List<Player> createdPlayers;
    public GameObject wyswietlaczKolorku;

    private
    void Start()
    {

        UnityEngine.Quaternion rotation = transform.rotation;
        List<List<GameObject>> listaWszystkiego = new List<List<GameObject>>();
        createdObjects = plansza.buduj_plansze(prefab, pusty, 0, pusty);
        for (int i = 1; i < 5; i++)
        {
            List<GameObject> obiekty = new List<GameObject>();
            klucz = Instantiate(pusty, createdObjects[a].transform.position, rotation);
            klucz.transform.Rotate(0, 90.0f * b, 0);
            obiekty = plansza.buduj_plansze(pusty, klucz, i, prefab);
            listaWszystkiego.Add(obiekty);
            a = a + 10;
            b = b + 1;
            Destroy(klucz);
        }
        createdPlayers = tworzycielPlayerow(listaWszystkiego);
        GameObject wyswietlacz = Instantiate(wyswietlaczKolorku, wyswietlaczKolorku.transform.position, wyswietlaczKolorku.transform.rotation);
        canvas.transform.GetChild(1).gameObject.SetActive(true);
        move.ruch(createdPlayers, wyswietlacz);
        kostka.SetActive(true);
    }

    void Update()
    {

    }
    public class Ludzik
    {
        public int Poczatek;
        public bool CzyZbity;
        public int Liczba;
        public UnityEngine.Quaternion PoczatkowaRotacja;
        public GameObject Chinczyk;
        public Ludzik(bool czyZbity, UnityEngine.GameObject chinczyk, int liczba, int poczatek, UnityEngine.Quaternion poczatkowaRotacja)
        {
            this.Chinczyk = chinczyk;
            this.CzyZbity = czyZbity;
            this.Liczba = liczba;
            this.Poczatek = poczatek;
            this.PoczatkowaRotacja = poczatkowaRotacja;
        }
    }
    public class Player
    {

        public Material Kolor { get; private set; }
        public List<GameObject> ListaMiejsc { get; private set; }
        public List<Ludzik> Ludziki { get; private set; }

        public Material[] KoloryLudzikow;
        public int IleZniszczonych;

        public Player(Material kolor, List<GameObject> listaMiejsc, List<Ludzik> ludziki, Material[] koloryLudzikow, int ileZniszczonych )
        {
            this.KoloryLudzikow = koloryLudzikow;
            this.Kolor = kolor;
            this.ListaMiejsc = listaMiejsc;
            this.Ludziki = ludziki;
            this.IleZniszczonych = ileZniszczonych;
 
        }
    }
    public List<Player> tworzycielPlayerow(List<List<GameObject>> myList)
    {
        List<Player> stworzeniLudzie = new List<Player>();
        List<GameObject> listaMiejsc;
        List<Ludzik> ludziki;
        for (int i = 0; i < 4; i++)
        {

            listaMiejsc = myList[i];
            if (i == 0)
            {
                ludziki = tworzycielLudzikow(yellow, myList[i], i);
                GameObject cialko = ludziki[i].Chinczyk.transform.GetChild(0).gameObject;
                Material[] mats = cialko.GetComponent<Renderer>().materials;
                Player player = new Player(yellow, listaMiejsc, ludziki, mats, 0);
                stworzeniLudzie.Add(player);
            }
            else if (i == 1)
            {
                ludziki = tworzycielLudzikow(red, myList[i], i);
                GameObject cialko = ludziki[i].Chinczyk.transform.GetChild(1).gameObject;
                Material[] mats = cialko.GetComponent<Renderer>().materials;
                Player player = new Player(red, listaMiejsc, ludziki, mats, 0);
                stworzeniLudzie.Add(player);
            }
            else if (i == 2)
            {
                ludziki = tworzycielLudzikow(blue, myList[i], i);
                GameObject cialko = ludziki[i].Chinczyk.transform.GetChild(1).gameObject;
                Material[] mats = cialko.GetComponent<Renderer>().materials;
                Player player = new Player(blue, listaMiejsc, ludziki, mats, 0);
                stworzeniLudzie.Add(player);
            }
            else
            {
                ludziki = tworzycielLudzikow(green, myList[i], i);
                GameObject cialko = ludziki[i].Chinczyk.transform.gameObject;
                Material[] mats = cialko.GetComponent<Renderer>().materials;
                Player player = new Player(green, listaMiejsc, ludziki, mats, 0);
                stworzeniLudzie.Add(player);
            }

        }
        return stworzeniLudzie;
    }
    public List<Ludzik> tworzycielLudzikow(Material kolor, List<GameObject> list, int u)
    {
        bool czyZbity = true;
        int x = 44;
        List<Ludzik> stworzonePostacie = new List<Ludzik>();
        UnityEngine.Vector3 startPosition;
        UnityEngine.Quaternion poczatkowaRotacja;
        for (int i = 0; i < 4; i++)
        {
            GameObject newPrefab;
            startPosition = list[x].transform.position;
            UnityEngine.Quaternion rotowanie = list[x].transform.rotation;

            if (u == 0)
            {
   
                newPrefab = Instantiate(kolumna1, startPosition, rotowanie);
                newPrefab.transform.Rotate(0, 90, 0);
                newPrefab.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
                newPrefab.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
                CapsuleCollider capsuleCollider = newPrefab.AddComponent<CapsuleCollider>();
                newPrefab.GetComponent<CapsuleCollider>().radius = 4.33f;
                newPrefab.GetComponent<CapsuleCollider>().height = 25.3f;
            }
            else if (u == 1)
            {

                newPrefab = Instantiate(kolumna2, startPosition, rotowanie);
                newPrefab.transform.GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
                CapsuleCollider capsuleCollider = newPrefab.AddComponent<CapsuleCollider>();
                newPrefab.GetComponent<CapsuleCollider>().radius = 4.33f;
                newPrefab.GetComponent<CapsuleCollider>().height = 25.3f;
            }
            else if (u == 2)
            {

                newPrefab = Instantiate(kolumna3, startPosition, rotowanie);
                newPrefab.transform.Rotate(0, -90, 0);
                newPrefab.transform.GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
                CapsuleCollider capsuleCollider = newPrefab.AddComponent<CapsuleCollider>();

                newPrefab.GetComponent<CapsuleCollider>().radius = 4.33f;
                newPrefab.GetComponent<CapsuleCollider>().height = 25.3f;
            }
            else
            {
 
                newPrefab = Instantiate(kolumna4, startPosition, rotowanie);
                newPrefab.transform.Rotate(-90, 180, 0);
                Material[] materialy = newPrefab.GetComponent<Renderer>().materials;
                materialy[0] = samuraj;
                newPrefab.GetComponent<Renderer>().materials = materialy;
                newPrefab.transform.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
                SphereCollider sphereCollider = newPrefab.AddComponent<SphereCollider>();
                newPrefab.GetComponent<SphereCollider>().radius = 0.06f;
                newPrefab.GetComponent<SphereCollider>().center = new UnityEngine.Vector3(0,0,0.05f);
            }
            newPrefab.transform.SetParent(trzymaczLudzikow.transform);
            newPrefab.name ="" + i;
            newPrefab.AddComponent<poruszacz>();
            int liczba = -1;
            poczatkowaRotacja = newPrefab.transform.rotation;
            Ludzik ludzik = new Ludzik(czyZbity, newPrefab, liczba, x, poczatkowaRotacja);
            stworzonePostacie.Add(ludzik);
            x++;
        }
        return stworzonePostacie;
    }
}