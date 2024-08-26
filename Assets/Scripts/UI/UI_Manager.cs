using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    private static UI_Manager _instance;
    public static UI_Manager Instance
    {
        get {
            if (_instance == null)
            {
                Debug.LogError("The UI instance is Null");
            }
            return _instance;
        }
    }

    //Variables
    [SerializeField]
    private Text _playerGemCount;
    [SerializeField]
    private Image _selectionImage;
    [SerializeField]
    private Text _gemCountText;
    [SerializeField]
    private Image[] _LivesUnit;

    private void Awake()
    {
        _instance = this;
    }
    public void OpenShop(int gemCount)
    {
        _playerGemCount.text = " " + gemCount + "G";
    }
    public void UpdateSelectionShop(int Ypos)
    {
        _selectionImage.rectTransform.anchoredPosition = new Vector2(_selectionImage.rectTransform.anchoredPosition.x, Ypos);
    }
   
    public void GemCount(int GemCount)
    {
        _gemCountText.text = "" + GemCount + "G";
    }
    public void UpdateLives(int LivesRemaining)
    {
        for(int i = 0; i <= LivesRemaining;i++)
        {
            if(i == LivesRemaining)
            {
                _LivesUnit[i].enabled = false;
            }
        }
    }
}
