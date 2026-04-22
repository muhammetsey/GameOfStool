using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [Header("UI Barlarý")]
    public Slider militaryBar;
    public Slider moraleBar;
    public Slider treasuryBar;
    public Slider prosperityBar;

    [Header("Olay Görseli")]
    public Image olayResmi;

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
            Debug.Log("Oyun Bitti veya Kartlar Baþa Sardý!");
            
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
        aktifKartIndeksi++;
        YeniKartYukle();
    }

    private void DegerleriGuncelle()
    {
     
        militaryBar.value = militaryValue;
        moraleBar.value = moraleValue;
        treasuryBar.value = treasuryValue;
        prosperityBar.value = prosperityValue;
    }
}
