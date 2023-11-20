using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class PanelBase : MonoBehaviour
{
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }



    public void PlayAppearingAnimation (Action action)
    {
        this.gameObject.transform.localScale = Vector3.zero;
        this.gameObject.transform.DOScale(1, 0.5f).SetEase(Ease.InOutSine).OnComplete(action.Invoke);
    }

    public void PlayDisAppearingAnimation(Action action)
    {
        this.gameObject.transform.DOScale(0, 2).SetEase(Ease.InBounce).OnComplete(action.Invoke);
    }


    public void PlaySlideAnimation(Action action)
    {
       // this.gameObject.GetComponent<Image>().DOFillAmount(1, 1).SetLoops(2, LoopType.Yoyo).OnComplete(action.Invoke);

        this.gameObject.GetComponent<Image>().DOFillAmount(1, 1).OnComplete(() => {
            this.gameObject.GetComponent<Image>().DOFillAmount(0, 0.5f).OnComplete(action.Invoke);
        });
    }

}
