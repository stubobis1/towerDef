using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public Text LivesText;
    public UnityEngine.UI.Image MoneyBar;
    public int Lives
    {
        get { return _lives; }
        set
        {
            this.LivesText.text = "Lives: " + _lives;
            _lives = value;
        }
    }

    public int _lives;

    public float _precentageOfMoney;
    public float PrecentageOfMoney
    {
        get { return _precentageOfMoney; }
        set
        {
            
            var theBarRectTransform = MoneyBar.transform as RectTransform;
            //THIS IS HARDCODED
            theBarRectTransform.sizeDelta = new Vector2 ((Screen.width * 4) * value  , theBarRectTransform.sizeDelta.y);
/*
            Rect r = new Rect(this.MoneyBar.rectTransform.rect);
            r.width = value / Screen.width;
            var u = new RectTransform();
            
            this.MoneyBar.rectTransform.rect = r;  
            _precentageOfMoney = value;*/
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        this.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
