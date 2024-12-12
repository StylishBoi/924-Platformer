using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private TextMeshProUGUI  _gemsTotal;

    void Start()
    {
        HideGoodGame();
        SetTotal();
    } 

    public void HideGoodGame() => _endPanel.SetActive(false);
    public void ShowGoodGame() => _endPanel.SetActive(true);

    public void SetTotal()
    {
        //Update the text for total of enemies left
        _gemsTotal.text = "Gems left - 4";
    }
    
    public void UpdateTotal(int gemsTotal)
    {
        //Update the text for total of enemies left
        _gemsTotal.text="Gems left - " + (gemsTotal-1).ToString();
    }
}
