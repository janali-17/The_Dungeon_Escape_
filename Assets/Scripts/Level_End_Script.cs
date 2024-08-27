using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_End_Script : MonoBehaviour
{
    [SerializeField]
    private Animator _EndEvelAnimator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && GameManager.Instance.HasKey == true)
        {
             _EndEvelAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
            Debug.Log("Player collide with end level");
             Time.timeScale = 0.0f;
            _EndEvelAnimator.SetTrigger("GameOver");
        }
    }
}
