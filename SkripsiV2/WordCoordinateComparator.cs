
using System.Collections.Generic;

namespace SkripsiV2
{

	public class WordCoordinateComparator : IComparer<WordCoordinate>
	{

		public virtual int Compare(WordCoordinate o1, WordCoordinate o2)
		{
			return o2.Score - o1.Score;
		}
	}

}