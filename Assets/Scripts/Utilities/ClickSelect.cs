using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class ClickSelect : MonoBehaviour, IPointerClickHandler
{
    public ToggleGroup ageRadio;// age radio button

    public GameObject AgeConfirmationAlert;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        string age = GetActive(ageRadio);
        if(age == "No")
        {
            if(this.gameObject.GetComponent<Toggle>() != null)
            {
                this.gameObject.GetComponent<Toggle>().isOn = false;
            }
            else if (this.gameObject.GetComponent<InputField>() != null)
            {
                this.gameObject.GetComponent<InputField>().text = "";
            }
            else if (this.gameObject.GetComponent<Dropdown>() != null)
            {
                this.gameObject.GetComponent<Dropdown>().value = 0;
            }
            AgeConfirmationAlert.SetActive(true);
        }
    }

    public string GetActive(ToggleGroup group)
    {
        IEnumerable<Toggle> activeToggles = group.ActiveToggles();
        string valueSelected = "";
        foreach (var item in activeToggles)
        {
            valueSelected = item.name;
            Debug.Log(item.name);
            break;
        }
        return valueSelected;
    }
}