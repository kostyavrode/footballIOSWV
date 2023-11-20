using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;

    [Header("Dialog Spawn Parent")]
    [SerializeField] private GameObject _dialogParent;
    [Header("Dialog Prefab List (Dialog Base Type)")]
    [SerializeField] private List<DialogBase> _dialogPrefabList;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    #region Public Api
    public void SpawnDialogBasedOnDialogType(DialogTypeEnum.DialogType type,DialogClass dialogClass)
    {
        GameObject dialogObj = GetSpecificDialogBasedOnType(type);
        if (dialogObj != null)
        {
            IDialog iDialog = InstantiateDialog(dialogObj);
            SetDialog(iDialog, dialogClass);
        }  
    }

    public void SpawnDialogBasedOnPrefabObj(GameObject dialogObj,DialogClass dialogClass)
    {
        if (dialogObj != null)
        {
            IDialog iDialog = InstantiateDialog(dialogObj);
            SetDialog(iDialog, dialogClass);
        }
    }
    #endregion Public Api


    #region Private Function 
    private void SetDialog(IDialog iDialog,DialogClass dialogClass)
    {
        if(iDialog != null && dialogClass != null)
        {
            iDialog.SetDialogUI(dialogClass);
        }  
    }

    private IDialog InstantiateDialog(GameObject dialog)
    {
        GameObject newObj = Instantiate(dialog, _dialogParent.transform);
        newObj.transform.parent = _dialogParent.transform;
        IDialog iDialog = newObj.GetComponent<IDialog>();
        return iDialog;
    }

    private GameObject GetSpecificDialogBasedOnType(DialogTypeEnum.DialogType type)
    {
        for (int i = 0; i < _dialogPrefabList.Count; i++)
        {
            if (type == _dialogPrefabList[i].GetDialogType())
            {
                return _dialogPrefabList[i].gameObject;
            }
        }
        return null;
    }
    #endregion Private Function 

}
