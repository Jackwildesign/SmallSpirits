using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCurrencyManager : MonoBehaviour
{
    public int currencyTotal = 0;
    [SerializeField] TMP_Text playerCurrencyText;
    
    // Start is called before the first frame update
    void Start()
    {
        StringCurrencyTotal(0);
    }

    public void StringCurrencyTotal(int currencyUpdate)
    {
        currencyTotal = currencyTotal + currencyUpdate;
        playerCurrencyText.text = " Total Currency = " + currencyTotal.ToString();
    }
}
