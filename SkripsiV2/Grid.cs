using System;

namespace SkripsiV2
{
	public class Grid
	{

		private char[][] matrix;
        char[][] newMatrix;
        private int maxRows;
		private int maxColumns;
        public String[,] data;
        public int LastRow, LastCol;
        public Grid(int maxRows, int maxColumns)
		{
			this.maxRows = maxRows;
			this.maxColumns = maxColumns;
            
			matrix = RectangularArrays.ReturnRectangularCharArray(maxRows, maxColumns);

			initialize();
		}

		public virtual void setValue(int row, int column, char val)
		{

			if (row >= maxRows | column >= maxColumns | row < 0 | column < 0)
			{
				return;
			}

			matrix[row][column] = val;
		}

		public virtual char getValue(int row, int column)
		{

            if (row >= maxRows | column >= maxColumns | row < 0 | column < 0)
            {
                return (char)0;
            }

            return matrix[row][column];
		}

		public virtual int MaxRows
		{
			get
			{
				return maxRows;
			}
		}

		public virtual int MaxColumns
		{
			get
			{
				return maxColumns;
			}
		}

		public virtual void initialize()
		{

			for (int i = 0; i < maxRows; i++)
			{
				for (int j = 0; j < maxColumns; j++)
				{
					matrix[i][j] = ' ';
				}
			}
		}

		public virtual void show()
		{
            int hitam = 0;
            int putih = 0;

			for (int i = 0; i < maxRows; i++)
			{
				for (int j = 0; j < maxColumns; j++)
				{
                    if(matrix[i][j] == ' ')
                    {
                        hitam++;
                    }
                    else
                    {
                        putih++;
                    }
				}

				//Console.WriteLine();
			}
            //Console.WriteLine("Putih = " + putih + " Hitam = " + hitam);
		}

        public String[,] getA()
        {
            for (int i = 0; i < maxRows; i++)
            {
                for (int j = 0; j < maxColumns; j++)
                {
                    Console.Write((matrix[i][j] == ' ' ? '-' : matrix[i][j]) + "\t");
                }
            }

            return data;
        }

        public Boolean CheckIntersection()
        {
            return true;
        }

        public virtual void clear()
        {
            int lastCol = maxColumns - 1, lastRow = maxRows - 1;
            for (int i = maxRows - 1; i >= 0; i--)
            {
                char c = ' ';
                for (int j = maxColumns - 1; j >= 0; j--)
                {
                    c = this.getValue(i, j);
                    if (c != ' ')
                    {
                        lastRow = i;
                        break;
                    }
                }
                if (c != ' ') break;
            }

            for (int i = maxColumns - 1; i >= 0; i--)
            {
                char c = ' ';
                for (int j = maxRows - 1; j >= 0; j--)
                {
                    c = this.getValue(j, i);
                    if (c != ' ')
                    {
                        lastCol = i;
                        break;
                    }
                }
                if (c != ' ') break;
            }
            Console.WriteLine(lastCol + " " + lastRow);

            this.LastCol = lastCol;
            this.LastRow = lastRow;
            //for (int lrow = 0; lrow <= lastRow; lrow++) {
            //    for (int lcol = 0; lcol <= lastCol; lcol++)
            //    {
            //        newMatrix[lrow][lcol] = matrix[lrow][lcol];
            //    }
            //}
            //matrix = newMatrix;
        }
    }

}