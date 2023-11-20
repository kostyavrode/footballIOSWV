using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickCountUiItem : MonoBehaviour
{

    [SerializeField] private GameObject defaultObj;
    [SerializeField] private GameObject rightObj;
    [SerializeField] private GameObject missObj;

    public enum ITEM_TYPE {
        DEFAULT,
        RIGHT,
        MISS
    }

    private ITEM_TYPE _type = ITEM_TYPE.DEFAULT;


    public void SetUP(ITEM_TYPE type)
    {
        _type = type;
        HideAllObj();
        switch (type)
        {
            case ITEM_TYPE.DEFAULT:
                defaultObj.SetActive(true);
                return;

            case ITEM_TYPE.MISS:
                missObj.SetActive(true);
                return;

            case ITEM_TYPE.RIGHT:
                rightObj.SetActive(true);
                return;
        }
    }

    private void HideAllObj()
    {
        defaultObj.SetActive(false);
        rightObj.SetActive(false);
        missObj.SetActive(false);
    }

}
