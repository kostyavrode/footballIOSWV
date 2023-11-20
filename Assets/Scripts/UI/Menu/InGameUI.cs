using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private GameObject kickCountItemParent;
    [SerializeField] private GameObject kickCountItemUI;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private HorizontalLayoutGroup layoutGroup;

    List<KickCountUiItem> kickUiItems = new List<KickCountUiItem>();


    private void OnEnable()
    {
        GameManager.shared.onKickCompleted += OnKickCompleted;
        ScoreManager.onScoreUpdated += UpdateScoreCount;
    }


    private void OnDestroy()
    {
        GameManager.shared.onKickCompleted -= OnKickCompleted;
        ScoreManager.onScoreUpdated -= UpdateScoreCount;
    }

    public void setUpIngameUI(int kickNumber)
    {
       // layoutGroup.enabled = false;
        InstantiateKickUI(kickNumber);
        UpdateScoreCount(0);

       // layoutGroup.enabled = true;
    }

    public void UpdateScoreCount(int score)
    {
        scoreText.text = "Score - " + score;
    }

    public void UpdateKickCountUI(int kickNumber, KickCountUiItem.ITEM_TYPE itemType )
    {
        kickUiItems[kickNumber].SetUP(itemType);
    }

    private void InstantiateKickUI(int count)
    {
        DestroyAllKickCountUiItems();

        for (int i=0; i<count; i++)
        {
            GameObject item = Instantiate(kickCountItemUI);
            item.transform.parent = kickCountItemParent.transform;
            item.transform.localScale = new Vector3(1, 1, 1);
            KickCountUiItem itemScript = item.GetComponent<KickCountUiItem>();
            kickUiItems.Add(itemScript);
        }
    }


    public void OnKickCompleted(int score, int currentKickNumber)
    {

        if (score > 0)
            UpdateKickCountUI(currentKickNumber, KickCountUiItem.ITEM_TYPE.RIGHT);
        else
            UpdateKickCountUI(currentKickNumber, KickCountUiItem.ITEM_TYPE.MISS);

    }


    void DestroyAllKickCountUiItems()
    {
        for (int i = 0; i < kickUiItems.Count; i++)
        {
            Destroy(kickUiItems[i].gameObject);
        }

        kickUiItems.Clear();
    }

}
