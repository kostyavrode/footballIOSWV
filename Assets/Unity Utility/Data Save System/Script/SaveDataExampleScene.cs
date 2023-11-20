using SaveSystem;
using UnityEngine;
using UnityEngine.UI;

public class SaveDataExampleScene : MonoBehaviour
{
    public InputField _pointField;
    public Text currentAmount;

    private string fileName = "PlayerAchicedData.json";

    private void Start()
    {
        ShowStoredData();
    }

    private string GetFilePath()
    {
        return FileHandler.GetPersistantFilePath(fileName);
    }

    public void LoadButtonClicked()
    {
        PlayerAchivedDataModel data = GetStoredData();
        data.collectedCoinNumber = GetInputValue();

        SaveDataHandler.SaveData(data, GetFilePath());

        ShowStoredData();

    }

    int GetInputValue()
    {
        int inputedValueInInt = 0;
        int.TryParse(_pointField.text, out inputedValueInInt);
        return inputedValueInInt;
    }

    PlayerAchivedDataModel GetStoredData()
    {
        return SaveDataHandler.GetData<PlayerAchivedDataModel>(GetFilePath(), GetDefaultPlayerAchivedDataModel());
    }

    void ShowStoredData()
    {
        currentAmount.text = "Current Coin Number = " + GetStoredData().collectedCoinNumber;
    }

    PlayerAchivedDataModel GetDefaultPlayerAchivedDataModel()
    {
        PlayerAchivedDataModel data = new PlayerAchivedDataModel();
        data.collectedCoinNumber = 0;
        data.maxLevelCompletedByPlayer = 1;
        return data;
    }
}
