using TMPro;
using UnityEngine;

public class PropertyStudy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PropData pd = new PropData();
        pd.PValue = 50;
        Debug.Log("pValue is : " + pd.PValue);
        pd.PStr = "데이터 체크 합니다.";
        pd.dataCheck();
    }

 
}

public class PropData
{
    private float _maxHP = 10;
    private float _heroHP;

    public float HeroHP
    {
        get { return _heroHP; }
        set 
        {
            if (_heroHP - value < 0) _heroHP = 0;
            if(_heroHP + value > _maxHP) _heroHP = _maxHP;
        }
    }

    private int _def;



    private int _pValue;
    public int PValue { get { return _pValue; } set { _pValue = value; } }

    private string _pStr = "";
    public string PStr { get; set; }

    public void dataCheck()
    {
        Debug.Log($"_pvalue : {_pValue}, PValue : {PValue}, PStr : {PStr}, _pstr : {_pStr}");
    }
}