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
        _gemsTotal.text = "Gems 0/8";
    }
    
    public void UpdateTotal(int gemsTotal)
    {
        //Increase the number of gems acquired
        gemsTotal++;
        //Update the text for total of enemies left
        _gemsTotal.text="Gems " + (gemsTotal).ToString()+"/8";
    }
}
