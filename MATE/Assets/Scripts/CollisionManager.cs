using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionManager : MonoBehaviour
{
    public Controller controllerScript;

    public int coin; //Gold sayısı int
    public Text coinText; //Gold text

    public GameObject Tekne;

    [SerializeField] GameObject goldPrefab;
    [SerializeField] GameObject goldpanel;
    [SerializeField] GameObject fuelPrefab;
    [SerializeField] GameObject fuelpanel;
    [SerializeField] GameObject WinGamePanel;

    public Fuel fuelScript;
    private GameObject moreGold;
    private GameObject moreFuel;
    private ParticleSystem moreGoldParticle;
    private ParticleSystem moreFuelParticle;
    public Text GoldText;
    public Text Goldx2Text;
    private float coin2x;
    
    void Start()
    {
        moreFuel = GameObject.FindGameObjectWithTag("_moreFuel");
        moreGold = GameObject.FindGameObjectWithTag("_moreGold");
        moreGoldParticle = GameObject.Find("MoreGoldParticle").GetComponent<ParticleSystem>();
        moreFuelParticle = GameObject.Find("MoreFuelParticle").GetComponent<ParticleSystem>();
       
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "_barrelObs")
        {
            //barrel dışına farklı bir collider oluşturuldu, animasyonun çalışması sağlandı
            CapsuleCollider Cap = collision.gameObject.GetComponent<CapsuleCollider>();
            Cap.enabled = false;
            collision.gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
        }

        if (collision.gameObject.tag == "_barrel")
        {   
            //barrel canvas animasyon 
            Instantiate(goldPrefab, Camera.main.WorldToScreenPoint(transform.position), goldpanel.transform.rotation, goldpanel.transform);
            // gold +1
            coin++;
            coinText.text = coin.ToString();
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "_moreGold")
        {
            //Tunnel(Gold) ile etkileşime girdiğinde;
            coin += 10;
            coinText.text = coin.ToString();
            moreFuel.SetActive(false);
            moreGold.SetActive(false);
            Instantiate(goldPrefab, Camera.main.WorldToScreenPoint(transform.position), goldpanel.transform.rotation, goldpanel.transform);
            moreGoldParticle.Play();
        }

        if (collision.gameObject.tag == "_moreFuel")
        {
            //Tunnel(Fuel) ile etkileşime girdiğinde;
            fuelScript.fuel += 10;
            moreFuel.SetActive(false);
            moreGold.SetActive(false);
            Instantiate(fuelPrefab, Camera.main.WorldToScreenPoint(transform.position), fuelpanel.transform.rotation, fuelpanel.transform);
            moreFuelParticle.Play();
        }

        if (collision.gameObject.tag == "_finishLine")
        {
            //Finish Line ile etkileşime girdiğinde;
            fuelScript.fuelBool = false;
            WinGamePanel.SetActive(true);
            GoldText.text = coin.ToString();
            coin2x = coin * 2;
            Goldx2Text.text = coin2x.ToString();
            controllerScript.enabled = false;
        }
    }

}
