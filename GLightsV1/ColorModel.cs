using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;

[SettingsSerializeAs(SettingsSerializeAs.Xml)]
public class ColorModel
{
	//Initializes on creation
	public int num { get; set; }
	public List<Color[]> colorList = new List<Color[]>();
	public ColorModel()
	{

	}
	
}
