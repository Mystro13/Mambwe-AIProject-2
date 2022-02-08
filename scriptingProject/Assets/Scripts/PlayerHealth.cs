using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //[SerializeField]
    //public Image healthBar;
    [SerializeField]
    int health = 10;


    bool damaged;
    // Start is called before the first frame update
    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {
        if (damaged)
        {
           
        }
        damaged = false;
        //    UpdateHUD();
    }
    //void UpdateHUD()
    //{
    //    healthBar.fillAmount = (float)health / 10;
    //}
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            damaged = true;
            DepleteHealth();
        }
    }
    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Enemies")
    //    {
    //        //WandValue = WandValue + 1;
    //        GameManager.instance.DepleteHealth();
    //        //scoreText.GetComponent<Text>().text = "SCORE: " + GameManager.score / 2;
    //    }
    //}


    public void DepleteHealth()
    {
        health -= 1;
        if (health <= -1)
        {
            health = 0;
        }
    }
}