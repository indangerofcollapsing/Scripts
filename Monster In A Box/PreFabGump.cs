﻿/*

	Credits to Talow for this code
	
	Note: 
	Depending on what emulator and version of that emulator you're using you may need to make certain changes to AddTextEntry.
	While writing this code, gumps were reverted back to the original Runuo. 
	
	AddTextEntry( x, y, width, height, hue, entryID, initialText, size, null, name );
	** has been changed to **
	AddTextEntry( x, y, width, height, hue, entryID, initialText, size );

*/
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using Server.Engines.XmlSpawner2;
using Server.ContextMenus;

namespace Server.Gumps 
{
	public class PreFabGump
	{
		// text entry with tiled image background
		public static void AddTextEntryPreFab( Gump g, int imageid, int x, int y, int width, int height, int hue, int entryID, string initialText, int size, string name = "")
		{
			g.AddImageTiled( x - 1, y - 1, width + 2, height + 2, 9204);
			g.AddImageTiled( x, y, width, height, imageid);
			g.AddTextEntry( x, y, width, height, hue, entryID, initialText, size );
		}
		
		// same as above but with two entries side by side and label included
		public static void AddTextEntryMinMax( Gump g, string s, int imageid, int labelX, int entryX , int y, int hue, int entryIdMin, int entryIdMax, string initialText, int size, string name = "")
		{
			//Label
			g.AddLabel(labelX, y, hue, s);
			
			// Min
			g.AddImageTiled( entryX - 1, y - 2, 52 + 2, 20 + 2, 9204);
			g.AddImageTiled( entryX, y -1 , /*height*/ 52, /*width*/ 20, imageid);
			g.AddTextEntry( entryX, y- 1 , 52, 20, hue, entryIdMin, "Min", size );
			
			// Max
			g.AddImageTiled( entryX + 62 - 1, y - 2, 52 + 2, 20 + 2, 9204);
			g.AddImageTiled( entryX + 62 , y -1 , 52, 20, imageid);
			g.AddTextEntry( entryX + 62 , y -1 , 52, 20, hue, entryIdMax, "Max", size );
		}
		
		// same as above but with two entries side by side and label included
		public static void AddTextEntryMinMaxLabel( Gump g, string s, int imageid, int x, int y, int hue, int entryIdMin, int entryIdMax, string initialText, int size, string name = "")
		{
			//Label
			g.AddLabel(x, y, hue, s);
			
			// Min
			g.AddImageTiled( (x + 10 -  (StringWitdth(s) / 2)) + 35 , y -1 , /*height*/ 52, /*width*/ 20, imageid);
			g.AddTextEntry( (x + 10 - (StringWitdth(s) / 2))+ 35 , y- 1 , 52, 20, hue, entryIdMin, "Min", size);
			
			// Max
			g.AddImageTiled( (x + 10 - (StringWitdth(s) / 2)) + 97 , y -1 , 52, 20, imageid);
			g.AddTextEntry( (x + 10 - (StringWitdth(s) / 2)) + 97 , y -1 , 52, 20, hue, entryIdMax, "Max", size );
		}
		
		// creates an outline effect around text
		public static void AddHtmlOutlined( Gump g, int x, int y, int width, int height, string outline, string s, bool background, bool scrollbar)
		{
			g.AddHtml( x - 1,  y,  width,  height,  outline,  background,  scrollbar);
			g.AddHtml( x - 1,  y - 1,  width,  height,  outline,  background,  scrollbar);
			g.AddHtml( x - 1,  y + 1,  width,  height,  outline,  background,  scrollbar);
			
			g.AddHtml( x,  y - 1,  width,  height,  outline,  background,  scrollbar);
			g.AddHtml( x,  y + 1 ,  width,  height,  outline,  background,  scrollbar);
			
			g.AddHtml( x + 1,  y,  width,  height,  outline,  background,  scrollbar);
			g.AddHtml( x + 1,  y - 1,  width,  height,  outline,  background,  scrollbar);
			g.AddHtml( x + 1,  y + 1,  width,  height,  outline,  background,  scrollbar);
			
			g.AddHtml( x,  y,  width,  height,  s,  background,  scrollbar);
			
		
		}
		
		
		public static int StringWitdth(String s)
		{
			Dictionary<string, int> sw = m_stringWidth();
			
			int tot = 0;
			foreach(char b in s)
			{
				string a = b.ToString();
				if(sw.ContainsKey(a))
					tot += sw[a];
			}
			
			return tot;
		}
		
		private static Dictionary<string, int> m_stringWidth()
		{
			Dictionary<string, int> d = new Dictionary<string, int>();
			d.Add("A",9);
			d.Add("B",9);
			d.Add("C",9);
			d.Add("D",9);
			d.Add("E",8);
			d.Add("F",8);
			d.Add("G",9);
			d.Add("H",9);
			d.Add("I",4);
			d.Add("J",9);
			d.Add("K",9);
			d.Add("L",8);
			d.Add("M",11);
			d.Add("N",9);
			d.Add("O",9);
			d.Add("P",9);
			d.Add("Q",10);
			d.Add("R",9);
			d.Add("S",9);
			d.Add("T",8);
			d.Add("U",9);
			d.Add("V",9);
			d.Add("W",13);
			d.Add("X",9);
			d.Add("Y",11);
			d.Add("Z",9);
			d.Add("a",7);
			d.Add("b",7);
			d.Add("c",7);
			d.Add("d",7);
			d.Add("e",7);
			d.Add("f",7);
			d.Add("g",7);
			d.Add("h",7);
			d.Add("i",4);
			d.Add("j",7);
			d.Add("k",7);
			d.Add("l",4);
			d.Add("m",10);
			d.Add("n",7);
			d.Add("o",7);
			d.Add("p",7);
			d.Add("q",7);
			d.Add("r",7);
			d.Add("s",7);
			d.Add("t",7);
			d.Add("u",7);
			d.Add("v",7);
			d.Add("w",9);
			d.Add("x",7);
			d.Add("y",7);
			d.Add("z",7);
			d.Add("0",9);
			d.Add("1",5);
			d.Add("2",9);
			d.Add("3",9);
			d.Add("4",9);
			d.Add("5",9);
			d.Add("6",9);
			d.Add("7",9);
			d.Add("8",9);
			d.Add("9",9);
			d.Add("!",4);
			d.Add("@",13);
			d.Add("#",13);
			d.Add("$",10);
			d.Add("%",10);
			d.Add("^",10);
			d.Add("&",12);
			d.Add("*",11);
			d.Add("(",5);
			d.Add(")",5);
			d.Add("-",6);
			d.Add("_",9);
			d.Add("=",7);
			d.Add("+",10);
			d.Add("\\",10);
			d.Add("|",3);
			d.Add("]",6);
			d.Add("}",6);
			d.Add("[",5);
			d.Add("{",5);
			d.Add("'",4);
			d.Add("\"",5);
			d.Add(";",4);
			d.Add(":",4);
			d.Add("/",10);
			d.Add("?",8);
			d.Add(".",4);
			d.Add(">",9);
			d.Add(",",4);
			d.Add("<",8);
			d.Add("`",4);
			d.Add("~",7);
			d.Add(" ",3);
			return d;
		}

	}
}