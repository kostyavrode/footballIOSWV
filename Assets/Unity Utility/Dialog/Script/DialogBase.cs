using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBase : MonoBehaviour
{
    [SerializeField] private Text _txtTitle;
    [SerializeField] private Text _txtMessage;
    [SerializeField] private Button _positiveButton;
    [SerializeField] private Button _negativeButton;

    [SerializeField] private DialogTypeEnum.DialogType _dialogType;

    private DialogClass _dialogClass ;

    #region Setting_Dialog

    public void SetDialogUI(DialogClass dialogClass)
    {
        _dialogClass = dialogClass;

        if(_txtTitle  != null)
            _txtTitle.text = dialogClass.title;

        if (_txtMessage != null)
            _txtMessage.text = dialogClass.message;

        if (_positiveButton != null && _positiveButton.GetComponentInChildren<Text>() != null)
            _positiveButton.GetComponentInChildren<Text>().text = dialogClass.positiveButtonText;

        if (_negativeButton != null && _negativeButton.GetComponentInChildren<Text>() != null)
            _negativeButton.GetComponentInChildren<Text>().text = dialogClass.negativeButtonText;

    }

    #endregion Setting_Dialog

    protected DialogClass GetDialogClass()
    {
        return _dialogClass;
    }

    protected void HideDialogPanel()
    {
        Destroy( this.gameObject);
    }

    public DialogTypeEnum.DialogType GetDialogType()
    {
        return _dialogType;
    }
}
