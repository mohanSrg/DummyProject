using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System.Linq;
using System.Collections.Generic;

public class SurveyView : View {

    public DatabaseManager DatabaseManager;

    public GameObject EnterOTPPanel;
    public Button SubmitButton;
    public GameObject FeedBackcompleted;

    public InputField MobileNumber;
    
    public ToggleGroup ageRadio;// age radio button
    public InputField name; // name field
    public InputField phone;  // mobile no field
    public InputField email; // email field
    public ToggleGroup age;  // age field

    public InputField brand;  // brand select dropdown field
    public InputField variant;  // variant dropdown field
    public InputField likemost; //field added
    public InputField obrand;  // obrand field
    public InputField variant2;  // variant2 field
    public InputField noofsticks;  // noofsticks field
    public InputField started;  // started field
    public InputField sstylishness;  // pack field
    public InputField filter;  // taste field
    public InputField taste;
    // $mintaftertaste=$myArray['mintaftertaste'];
    // $crystallball=$myArray['crystallball'];

    public string beforeburst;

    public ToggleGroup triedany;
    public InputField afterburst;
    public InputField bestthing;
    public ToggleGroup comparison;
    public InputField plytype;

    //public InputField psecity;  // psecity field
    //public InputField sarea;
    //public InputField psename;
    //public InputField mmname;
    //public InputField cuname;
    //public InputField sareacode;
    public string brandname = "Black Prince";    

    public string memberId;  // memberId field

    //newly added fields
    public InputField occupation;
    public InputField nooftimes;
    public InputField times;
    public InputField each;
    public InputField others; //optionall field
    public InputField otp;
           
    public InputField subtime;
    /*$exotel = $myArray['exotel'];

    $callsid=$myArray['callsid1'];*/
    public InputField DIDNumber;
    public InputField did_st;
    public InputField did_et;
    public InputField OTPNumber;
    public InputField OTPDuration;
           
    public InputField LFCurrentbrand;
    public InputField LFVariant;
    public InputField LFOtherbrand;
    public InputField LFVariant2;
    public InputField RFVBrand;
    public InputField RFVVariant;
    public InputField RFVOtherbrand;
    public InputField RFVOthervariant;
    public InputField LFnoofcigarettes;
    public InputField RFVnoofcigarettes;
           
    public InputField sign;
    public InputField zone;
    public InputField outletnew;
    public InputField location;
    public InputField total;
 
    internal Signal<string> OnOTPSendClickSignal;
    internal Signal<string> OnOTPSubmitSignal;
    internal Signal<SurveyData> OnSurveyDataSubmitSignal;

    public void Initialize()
	{
		OnOTPSendClickSignal = new Signal<string> ();
        OnOTPSubmitSignal = new Signal<string>();
        OnSurveyDataSubmitSignal = new Signal<SurveyData>();
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
        data.OTPNumber = OTPNumber.text.ToString();
        data.DIDNumber = OTPNumber.text.ToString();
        data.date = System.DateTime.Now.Date.ToString();
        data.time = System.DateTime.Now.TimeOfDay.ToString();
        //ageRadio = GetActive().;
        data.name = name.ToString();
        data.brand = brand.ToString();
        data.email = email.ToString();
        data.phone = phone.ToString();
        

        OnSurveyDataSubmitSignal.Dispatch(data);
    }

    public Toggle GetActive(ToggleGroup group)
    {
        IEnumerable<Toggle> activeToggles = group.ActiveToggles();
        
        return null;
    }

}
