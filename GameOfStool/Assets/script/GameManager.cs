using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Barlarý")]
    public Slider militaryBar;
    public Slider moraleBar;
    public Slider treasuryBar;
    public Slider prosperityBar;

    [Header("Olay Görseli")]
    public Image olayResmi;

    [Header("Oyun Sonu Resimleri (0'a Düþtüðünde)")]
    public Sprite militarySifirResmi;
    public Sprite moraleSifirResmi;
    public Sprite treasurySifirResmi;
    public Sprite prosperitySifirResmi;

    [Header("Oyun Sonu Resimleri (100'e Çýktýðýnda)")]
    public Sprite militaryYuzResmi;
    public Sprite moraleYuzResmi;
    public Sprite treasuryYuzResmi;
    public Sprite prosperityYuzResmi;

    [Header("Buton Kontrolleri")]
    public GameObject btnYes;
    public GameObject btnNo;
    public GameObject btnRestart;

    [Header("Oyun Verileri")]
    public List<OlayKarti> olayDestesi;
    private int aktifKartIndeksi = 0;
    private OlayKarti aktifKart;

    private float militaryValue = 50f;
    private float moraleValue = 50f;
    private float treasuryValue = 50f;
    private float prosperityValue = 50f;

    [Header("Hanedan Bayraklarý")]
    public Image hanedanBayragiEkrani; // Sað üstteki UI Image
    public Sprite bayrak1; // 1. Hanedan (Sarý)
    public Sprite bayrak2; // 2. Hanedan (Siyah)
    public Sprite bayrak3; // 3. Hanedan (Kýrmýzý)
    public Sprite bayrak4; // 4. Hanedan (Yeþil)

    // ... (Diðer deðiþkenlerin aynen kalsýn) ...

    void Start()
    {
        btnRestart.SetActive(false);

        // HAFÝZADAN KÝMÝN SEÇÝLDÝÐÝNE BAKIYORUZ
        if (OyunVerileri.secilenHanedanID == 1)
        {
            militaryValue = 70f; moraleValue = 50f; treasuryValue = 50f; prosperityValue = 50f;
            hanedanBayragiEkrani.sprite = bayrak1; // BÝZE LAZIM OLAN KOD BU!
        }
        else if (OyunVerileri.secilenHanedanID == 2)
        {
            militaryValue = 50f; moraleValue = 70f; treasuryValue = 50f; prosperityValue = 50f;
            hanedanBayragiEkrani.sprite = bayrak2;
        }
        else if (OyunVerileri.secilenHanedanID == 3)
        {
            militaryValue = 50f; moraleValue = 50f; treasuryValue = 70f; prosperityValue = 50f;
            hanedanBayragiEkrani.sprite = bayrak3;
        }
        else if (OyunVerileri.secilenHanedanID == 4)
        {
            militaryValue = 50f; moraleValue = 50f; treasuryValue = 50f; prosperityValue = 70f;
            hanedanBayragiEkrani.sprite = bayrak4;
        }
        else
        {
            militaryValue = 50f; moraleValue = 50f; treasuryValue = 50f; prosperityValue = 50f;
            // Eðer menüden gelmediyse bayrak kutusunu gizle (hata vermesin diye)
            hanedanBayragiEkrani.gameObject.SetActive(false);
        }

        DegerleriGuncelle();
        YeniKartYukle();
    }

    public void YeniKartYukle()
    {
        if (aktifKartIndeksi < olayDestesi.Count)
        {
            aktifKart = olayDestesi[aktifKartIndeksi];
            olayResmi.sprite = aktifKart.kartResmi;
        }
        else
        {
            aktifKartIndeksi = 0;
            YeniKartYukle();
        }
    }

    public void YesButton()
    {
        militaryValue += aktifKart.yesMilitary;
        moraleValue += aktifKart.yesMorale;
        treasuryValue += aktifKart.yesTreasury;
        prosperityValue += aktifKart.yesProsperity;
        SonrakiTuraGec();
    }

    public void NoButton()
    {
        militaryValue += aktifKart.noMilitary;
        moraleValue += aktifKart.noMorale;
        treasuryValue += aktifKart.noTreasury;
        prosperityValue += aktifKart.noProsperity;
        SonrakiTuraGec();
    }

    private void SonrakiTuraGec()
    {
        DegerleriGuncelle();

        if (OyunBittiMiKontrolEt() == true)
        {
            return;
        }

        aktifKartIndeksi++;
        YeniKartYukle();
    }

    private bool OyunBittiMiKontrolEt()
    {
        if (militaryValue <= 0) { OyunuBitir(militarySifirResmi); return true; }
        if (moraleValue <= 0) { OyunuBitir(moraleSifirResmi); return true; }
        if (treasuryValue <= 0) { OyunuBitir(treasurySifirResmi); return true; }
        if (prosperityValue <= 0) { OyunuBitir(prosperitySifirResmi); return true; }

        if (militaryValue >= 100) { OyunuBitir(militaryYuzResmi); return true; }
        if (moraleValue >= 100) { OyunuBitir(moraleYuzResmi); return true; }
        if (treasuryValue >= 100) { OyunuBitir(treasuryYuzResmi); return true; }
        if (prosperityValue >= 100) { OyunuBitir(prosperityYuzResmi); return true; }

        return false;
    }

    private void OyunuBitir(Sprite bitisGorseli)
    {
        olayResmi.sprite = bitisGorseli;
        btnYes.SetActive(false);
        btnNo.SetActive(false);
        btnRestart.SetActive(true);
    }

    public void OyunuYenidenBaslat()
    {
        // 0 numaralý sahneye (Ana Menüye) geri dön
        SceneManager.LoadScene(0);
    }

    // ÝÞTE UNUTTUÐUM O KRÝTÝK FONKSÝYON BURADA :)
    private void DegerleriGuncelle()
    {
        militaryBar.value = militaryValue;
        moraleBar.value = moraleValue;
        treasuryBar.value = treasuryValue;
        prosperityBar.value = prosperityValue;
    }
}