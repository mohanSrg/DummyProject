using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using UnityEngine.UI;
using strange.extensions.signal.impl;
using System;

public class StickPriceTrackerView : View{

    public GameObject StickPriceTrackerPanel;
    public GameObject SurveyPagePanel;
    public GameObject HeaderDetailsPanel;

    public Text LoginId;
	public InputField SurveyorName;

	public InputField Gfk_price;
	public InputField Cla_price;
	public InputField Mar_price;
	public InputField Gfp_price;
	public InputField Other_price;
	public InputField Other_price2;
	public InputField Other_price3;
	public InputField Gfk_price_paisa;
	public InputField Cla_price_paisa;
	public InputField Mar_price_paisa;
	public InputField Gfp_price_paisa;
	public InputField Other_price1_paisa;
	public InputField Other_price2_paisa;
	public InputField Other_price3_paisa;

	public InputField Obrands1;
	public InputField Obrands2;
	public InputField Obrands3;
	public InputField Psename;
	public InputField Surveycity;
	public InputField Sarea;
	public InputField Sareacod;
	public InputField Wdname;

	internal Signal<StickPriceTrackerData> OnStickPriceTrackerSubmitClickedSignal;
	public void Initialize()
	{
		OnStickPriceTrackerSubmitClickedSignal = new Signal<StickPriceTrackerData> ();
	}

	public void OnSubmitClick ()
	{
		StickPriceTrackerData data = new StickPriceTrackerData ();
        if(Gfk_price.text != "")
		    data.gfk_pric = Int32.Parse( Gfk_price.text);
        if(Gfk_price.text != "")
		    data.cla_price = Int32.Parse( Cla_price.text);
        if(Gfk_price.text != "")
		    data.mar_price = Int32.Parse( Mar_price.text);
        if (Gfk_price.text != "")
            data.gfp_price = Int32.Parse( Gfp_price.text);
        if (Gfk_price.text != "")
            data.other_price = Int32.Parse( Other_price.text);
        if (Gfk_price.text != "")
            data.other_price2 = Int32.Parse( Other_price2.text);
        if (Gfk_price.text != "")
            data.other_price3 = Int32.Parse( Other_price3.text);
        if (Gfk_price.text != "")
            data.gfk_price_paisa = Int32.Parse( Gfk_price_paisa.text);
        if (Gfk_price.text != "")
            data.cla_price_paisa = Int32.Parse( Cla_price_paisa.text);
        if (Gfk_price.text != "")
            data.mar_price_paisa = Int32.Parse( Mar_price_paisa.text);
        if (Gfk_price.text != "")
            data.gfp_price_paisa = Int32.Parse( Gfp_price_paisa.text);
        if (Gfk_price.text != "")
            data.other_price1_paisa = Int32.Parse( Other_price1_paisa.text);
        if (Gfk_price.text != "")
            data.other_price2_paisa = Int32.Parse( Other_price2_paisa.text);
        if (Gfk_price.text != "")
            data.other_price3_paisa = Int32.Parse( Other_price3_paisa.text);

        if (Gfk_price.text != null)
            data.obrands1 = Obrands1.text;
        if (Gfk_price.text != null)
            data.obrands2 = Obrands2.text;
        if (Gfk_price.text != null)
            data.obrands3 = Obrands3.text;
        if (Gfk_price.text != null)
            data.psename = Psename.text;
        if (Gfk_price.text != null)
            data.surveycity = Surveycity.text;
        if (Gfk_price.text != null)
            data.sarea = Sarea.text;
        if (Gfk_price.text != null)
            data.sareacod = Sareacod.text;
        if (Gfk_price.text != null)
            data.wdname = Wdname.text;


		OnStickPriceTrackerSubmitClickedSignal.Dispatch (data);
	}
}
