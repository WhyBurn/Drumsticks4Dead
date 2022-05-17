using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public int money;
    public Text moneyDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        money = 10;
        moneyDisplay.text = money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        moneyDisplay.transform.localPosition = new Vector3(800 / 2, 800f * Screen.height / Screen.width / 2, 0);
    }

    public void addMoney(int addedMoney)
    {
        money += addedMoney;
        moneyDisplay.text = money.ToString();

    }

    public void subtractMoney(int takenMoney)
    {
        if(money - takenMoney < 0)
        {
            Debug.Log("Not Enough Money!!!");
        } else
        {
            money -= takenMoney;
            moneyDisplay.text = money.ToString();
        }
    }
}
