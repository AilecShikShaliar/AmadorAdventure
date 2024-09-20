using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackgroundController : MonoBehaviour
{
    public bool isSwitched = false;
    public Image bgraund1;
    public Image bgraund2;
    public Animator animator;

    public void SwitchImage(Sprite sprite) 
    {
        if (!isSwitched)
        {
            bgraund2.sprite = sprite;
            animator.SetTrigger("SwichtFirst");
        }
        else
        {
            bgraund1.sprite = sprite;
            animator.SetTrigger("SwichtSecond");
        }
        isSwitched = !isSwitched;
    }

    public void SetImage(Sprite sprite)
    {
        if (!isSwitched)
        {
            bgraund2.sprite = sprite;
            
        }
        else
        {
            bgraund1.sprite = sprite;
            
        }
    }
}
