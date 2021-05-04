using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    Manager manager;

    Image renk;

    RectTransform buyukluk;

    string harf;

    bool harf_verildi = false;

    public bool yok_ol = false;

    float kuculme_miktari = 0.08f;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<Manager>();

        renk = GetComponent<Image>();

        buyukluk = GetComponent<RectTransform>();

        harf = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.tiklandi == false)
        {
            harf_verildi = false;
            renk.color = Color.white;
        }

        if (yok_ol == true)
        {
            buyukluk.localScale -= new Vector3(kuculme_miktari, kuculme_miktari, kuculme_miktari);

            if (buyukluk.localScale.x <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void yesil_ol()
    {
        if (manager.tiklandi == true)
        {
            renk.color = Color.green;

            if (harf_verildi == false)
            {
                manager.isaretli_button_olustur(gameObject);
                harf_verildi = true;
            }
        }
    }
}
