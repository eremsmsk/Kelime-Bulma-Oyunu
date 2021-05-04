using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    public string[] sozluk;
    public TMPro.TextMeshProUGUI puan_txt;
    //public Text puan_txt;

    List<GameObject> isaretli_buttonlar;

    string kelime = null;
    public bool tiklandi = false;

    public GameObject bitti_panel;

    int puan = 0;
    int bulunan_kelime_sayisi = 0;

        // Start is called before the first frame update
    void Start()
    {
        isaretli_buttonlar = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tiklandi = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            tiklandi = false;

            yazi_olustur();

            puan_txt.text = puan.ToString();
        }
    }

    public void isaretli_button_olustur(GameObject button)
    {
        isaretli_buttonlar.Add(button);
        kelime = null;

        foreach (GameObject buttonlar in isaretli_buttonlar)
        {
            kelime = kelime + buttonlar.name;
            puan_txt.text = kelime;
        }
    }

    void yazi_olustur()
    {
        foreach(string kelimeler in sozluk)
        {
            if (kelimeler == kelime)
            {
                puan += 100;
                bulunan_kelime_sayisi++;

                foreach(GameObject button in isaretli_buttonlar)
                {
                    button.GetComponent<Button>().yok_ol = true;
                }
            }
        }


        isaretli_buttonlar.Clear();
        kelime = null;

        if (bulunan_kelime_sayisi == sozluk.Length)
        {
            bitti_panel.SetActive(true);
        }
    }
}
