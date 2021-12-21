using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GoldUI : MonoBehaviour
{
    Transform panel;
    Sequence goldAnim;
    void Start()
    {
        AnimationGold();
    }

   void AnimationGold()
    {
        //Canvas gold animasyonu, DOTween ile sağlandı
        panel = GameObject.FindGameObjectWithTag("GoldPanel").transform;
        goldAnim = DOTween.Sequence();

        goldAnim.Append(transform.DOMove(panel.position,2)
            .SetEase(Ease.OutBounce))
            .OnComplete(()=>Destroy(gameObject));
        
    }
}
