using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int Coins { get; set; }
    private int Diamonds { get; set; }
    private bool _isAlive;

    public void AddCoins(int coinsAmount) => Coins += coinsAmount;
    public void AddDiamonds(int diamondsAmount) => Diamonds += diamondsAmount;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
