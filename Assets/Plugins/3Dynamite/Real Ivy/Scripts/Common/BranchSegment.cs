using System.Collections.Generic;

namespace _3Dynamite.Real_Ivy.Scripts.Common
{
	[System.Serializable]
	public class BranchSegment
	{
		public List<LeafPoint> leaves;
		public BranchPoint initSegment;
		public BranchPoint endSegment;
	}
}