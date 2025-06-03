using System;

namespace Main.UI.Screens.Configs {
	[Serializable]
	public class SlicesPreset {
		public int Elements;
		public int Rows;
		public int Columns;
		
		public override bool Equals(object obj) {
			if (obj is not SlicesPreset other) return false;
			
			return Elements == other.Elements && Rows == other.Rows && Columns == other.Columns;
		}
		public override int GetHashCode() => HashCode.Combine(Elements, Rows, Columns);
	}
}