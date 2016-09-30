using UnityEngine;
using UnityEngine.UI;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System.Collections.Generic;
using System;

public class SurveyView : View {

    public DatabaseManager DatabaseManager;
    public Dictionary<string, List<string>> brandAndVarients;
    public List<string> brands;

    

    public GameObject OTPResponsePanel;
    public Button SubmitButton;
    public GameObject FeedBackcompleted;

    public InputField MobileNumber;

    public Toggle AgeNoToggle;
    public ToggleGroup ageRadio;// age radio button
    public InputField name; // name field
    public InputField phone;  // mobile no field
    public InputField email; // email field
    public ToggleGroup age;  // age field

    public Dropdown brand;  // brand select dropdown field
    public Dropdown variant;  // variant dropdown field
    public InputField likemost; //field added
    public Dropdown obrand;  // obrand field
    public Dropdown variant2;  // variant2 field
    public InputField noofsticks;  // noofsticks field
    public ToggleGroup taste;

    public ToggleGroup triedany;
    public ToggleGroup afterburst;
    //public InputField bestthing;
    public ToggleGroup comparison;
    public ToggleGroup plytype;

    public InputField occupation;
    public InputField nooftimes;
    public InputField times;
    public InputField each;
    public ToggleGroup others; //optionall field
    public InputField otp;
           
    public InputField subtime;


    public InputField OTPNumber;
    public InputField OTPDuration;          
           
    public InputField sign;
    public InputField zone;
    public InputField outletnew;
    public InputField location;
    public InputField total;
 
    internal Signal<string> OnOTPSendClickSignal;
    internal Signal<string> OnOTPSubmitSignal;
    internal Signal<SurveyData> OnSurveyDataSubmitSignal;

    public string StartTime;
    public string StartDate;
    public void Initialize()
	{        
		OnOTPSendClickSignal = new Signal<string> ();
        OnOTPSubmitSignal = new Signal<string>();
        OnSurveyDataSubmitSignal = new Signal<SurveyData>();
        StartDate = System.DateTime.Now.ToLocalTime().Date.ToString();
        StartTime = System.DateTime.Now.ToLocalTime().TimeOfDay.ToString();
    }

    public void OnEnable()
    {        
        brand.onValueChanged.AddListener(delegate
        {
            OnBrandValueChanged(brand, variant);
        });
        obrand.onValueChanged.AddListener(delegate
        {
            OnBrandValueChanged(obrand, variant2);
        });
        brands = new List<string>();
        brandAndVarients = new Dictionary<string, List<string>>();

        brandAndVarients = DatabaseManager.brandList;
        brands = GetAllBrandNames();
        if (brands != null)
        {
            brand.AddOptions(brands);
            obrand.AddOptions(brands);
        }
        
    }

	public void OnOTPButtonClick()
	{
		string phno = MobileNumber.text.ToString();
		OnOTPSendClickSignal.Dispatch (phno);
	}

    public void OnOTPSubmit()
    {
        OnOTPSubmitSignal.Dispatch(OTPNumber.text.ToString());
    }

    public void OnSurveyDataSubmit()
    {
        SurveyData data = new SurveyData();
        data.date = StartDate;
        data.time = StartTime;
        data.OTPNumber = OTPNumber.text.ToString();
        data.DIDNumber = OTPNumber.text.ToString();
        data.subtime = System.DateTime.Now.ToLocalTime().Date.ToString();
        data.name = name.text;
        data.brand = brands[brand.value];
        data.email = email.text;
        data.variant = GetVarientValue(variant.value);
        data.phone = phone.text;
        data.age = GetActive(ageRadio);
        data.obrand = brands[obrand.value];
        data.variant = GetVarientValue(variant2.value);
        data.taste = GetActive(taste);
        data.triedany = GetActive(triedany);
        data.afterburst = GetActive(afterburst);
        data.comparison = GetActive(comparison);
        data.plytype = GetActive(plytype);
        data.occupation = occupation.text;
        data.nooftimes = nooftimes.text;
        data.times = times.text;
        data.each = each.text;
        data.others = GetActive(others);


        OnSurveyDataSubmitSignal.Dispatch(data);
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

    public List<string> GetAllBrandNames()
    {
        List<string> brands = new List<string>();
        foreach (var brandName in brandAndVarients)
        {
            brands.Add(brandName.Key);
        }
        return brands;
    }

    public void OnBrandValueChanged(Dropdown brand, Dropdown variant)
    {
        if (brands != null)
        {
            string brandName = brands[brand.value];
            variant.ClearOptions();
            List<string> varients = brandAndVarients[brandName];
            variant.AddOptions(varients);
        }
    }

    public void OnDisable()
    {
        brand.onValueChanged.RemoveAllListeners();
        obrand.onValueChanged.RemoveAllListeners();
    }

    public string GetVarientValue(int index)
    {
        string brandName = brands[brand.value];
        List<string> varients = brandAndVarients[brandName];
        return varients[index];
    }

    public void Update()
    {
        if(AgeNoToggle.isOn == true)
        {
            name.text = "";
            phone.text = "";
            email.text = "";

            brand.value = 0;
            variant.value = 0; 
            likemost.text = "";
            obrand.value  = 0;
            variant2.value = 0;
            noofsticks.text = ""; ;
        }
        
    }

}
