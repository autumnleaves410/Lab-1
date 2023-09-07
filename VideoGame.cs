using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Lab_1
{
	public class VideoGame : IComparable<VideoGame>
	{
	//Declare videogame.csv properties

		public string Name { get; set; }
		public string Platform { get; set; }
		public double Year { get; set; }
		public string Genre { get; set; }
		public string Publisher { get; set; }
		public decimal NA_Sales { get; set; }
		public decimal EU_Sales  { get; set; }
		public decimal JP_Sales { get; set; }
		public decimal Other_Sales { get; set; }
		public decimal Global_Sales { get; set; }


		//Default Constructor

		public VideoGame()
		{
			Name = "N/A";
			Platform = "N/A";
			Year = 0;
			Genre = "N/A";
			Publisher = "N/A";
			NA_Sales = 0;
			EU_Sales = 0;
			JP_Sales = 0;
			Other_Sales = 0;
			Global_Sales = 0;
		}


		//Copy Constructor

		public VideoGame(string name, string platform, string year, string genre, string publisher, decimal na_Sales, decimal eu_Sales, decimal jp_Sales, decimal other_Sales, decimal global_Sales)
		{
			Name = this.Name;
			Platform = this.Platform;
			Year = this.Year;
			Genre = this.Genre;
			Publisher = this.Publisher;
			NA_Sales = this.NA_Sales;
			EU_Sales = this.EU_Sales;
			JP_Sales = this.JP_Sales;
			Other_Sales = this.Other_Sales;
			Global_Sales = this.Global_Sales;

		}

		public int CompareTo(VideoGame? other)
		{
			int result = Name.CompareTo(other.Name);

			return result;
		}


        public override string ToString()
        {
			return $"{Name}, {Platform}, {Year}, {Genre}, {Publisher}, {NA_Sales}, {EU_Sales}, {JP_Sales}, {Other_Sales}, {Global_Sales}";
		}

    }
}

