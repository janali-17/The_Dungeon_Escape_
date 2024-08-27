using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager instance is Null");
            }
            return _instance;
        }
    }

    public bool HasKey { get; set; }
    public Player player {  get; private set; }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (player == null)
        {
            Debug.Log("Player in the GameManager is Null");
        }
    }

    private void Awake()
    {
      _instance = this;
      
    }

}
