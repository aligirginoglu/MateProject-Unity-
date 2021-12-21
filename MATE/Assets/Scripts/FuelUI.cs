using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FuelUI : MonoBehaviour
{
    Transform panelFuel;
    Sequence fuelAnim;
    void Start()
    {
        AnimationFuel();
    }

    void AnimationFuel()
    {
        //Canvas fuel animasyonu, DOTween ile sağlandı
        panelFuel = GameObject.FindGameObjectWithTag("FuelPanel").transform;
        fuelAnim = DOTween.Sequence();

        fuelAnim.Append(transform.DOMove(panelFuel.position, 2)
            .SetEase(Ease.OutBounce))
            .OnComplete(() => Destroy(gameObject));

    }
}
