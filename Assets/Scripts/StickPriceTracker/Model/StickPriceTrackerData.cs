using UnityEngine;
using System.Collections;

public class StickPriceTrackerData {

	public string memid;
	public string date;
    public string time;

	public int gfk_pric;
	public int cla_price;
	public int mar_price;
	public int gfp_price;
	public int other_price;
	public int other_price2;
	public int other_price3;
	public int gfk_price_paisa;
	public int cla_price_paisa;
	public int mar_price_paisa;
	public int gfp_price_paisa;
	public int other_price1_paisa;
	public int other_price2_paisa;
	public int other_price3_paisa;

	public string obrands1;
	public string obrands2;
	public string obrands3;
	public string psename;
	public string surveycity;
	public string sarea;
	public string sareacod;
	public string wdname;

    public StickPriceTrackerData()
    {
        gfk_pric = 0;
        cla_price = 0;
        mar_price = 0;
        gfp_price = 0;
        other_price = 0;
        other_price2 = 0;
        other_price3 = 0;
        gfk_price_paisa = 0;
        cla_price_paisa = 0;
        mar_price_paisa = 0;
        gfp_price_paisa = 0;
        other_price1_paisa = 0;
        other_price2_paisa = 0;
        other_price3_paisa = 0;
        obrands1 = "";
        obrands2 = "";
        obrands3 = "";
        psename = "";
        surveycity = "";
        sarea = "";
        sareacod = "";
        wdname = "";
    }
}
