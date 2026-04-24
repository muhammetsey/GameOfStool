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

    void Start()
    {
        btnRestart.SetActive(false);
        DegerleriGuncelle(); // Artýk bu fonksiyon aþaðýda var!
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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