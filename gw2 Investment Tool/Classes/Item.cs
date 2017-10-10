﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gw2_Investment_Tool.Classes
{
	public class Item 
	{
		public int ItemId { get; set; }
		public int Quantity { get; set; }
		public string Discipline { get; set; }
		public Decimal? KarmaPerItem { get; set; }
		public bool Active { get; set; }
		public string Name { get; set; }
		public float? TotalKarma { get; set; }
	}
}
