using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[3, 3];
    public float[,] lifeQuantity = new float[3, 3];
    public int treats;
    public treat_counter tc;
    public PlayerHealth ph;
    private float lifeAmount;

    // Start is called before the first frame update
    void Start()
    {
        tc = GetComponent<treat_counter>();
        ph = GetComponent<PlayerHealth>();
        lifeAmount = 0f;

        // Item ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;

        // Item Price
        shopItems[2, 1] = 50;
        shopItems[2, 2] = 100;

        // Item Quantity
        lifeQuantity[1, 1] = 0.5f;
        lifeQuantity[1, 2] = 0;
    }


    public void Purchase()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (treats >= shopItems[2, buttonRef.GetComponent<ShopItemInfo>().ID])
        {
            treats += shopItems[2, buttonRef.GetComponent<ShopItemInfo>().ID];
            tc.TreatDisburement(treats);

            lifeQuantity[1, buttonRef.GetComponent<ShopItemInfo>().ID]++;
            lifeAmount = lifeQuantity[1, buttonRef.GetComponent<ShopItemInfo>().ID]++;

            ph.LifePurchase(lifeAmount);
            buttonRef.GetComponent<ShopItemInfo>().quantity.text = lifeQuantity[1, buttonRef.GetComponent<ShopItemInfo>().ID].ToString();
        }
    }
}
