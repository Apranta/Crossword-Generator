namespace SkripsiV2
{
	public class WordCoordinate
	{

		private int x;
		private int y;
		private int score;

		public WordCoordinate(int x, int y, int direction, int score)
		{
			this.x = x;
			this.y = y;
			this.direction = direction;
			this.score = score;
		}

		private int direction; // 0 => hor, 1 => ver

		public virtual int X
		{
			get
			{
				return x;
			}
		}

		public virtual int Y
		{
			get
			{
				return y;
			}
		}

		public virtual int Direction
		{
			get
			{
				return direction;
			}
		}

		public virtual int Score
		{
			get
			{
				return score;
			}
		}
	}

}