using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SkripsiV2
{

	public class Generator
	{

		private Grid grid;
		private List<string> words;
        private List<GeneratedWord> generatedWords;
		private Dictionary<int, List<string>> horizontalAnnex;
		private Dictionary<int, List<string>> verticalAnnex;

		private Random rnd;

		public Generator(Grid grid, List<string> words)
		{
			this.grid = grid;
			this.words = words;

            generatedWords = new List<GeneratedWord>();
			rnd = new Random();

			orderWords();

			horizontalAnnex = new Dictionary<int, List<string>>();
			verticalAnnex = new Dictionary<int, List<string>>();
        }

		private void orderWords()
		{
            //Collection.shuffle(words);
            var rand = new Random();
            words = words.OrderBy(r => rand.Next()).ToList();
        }

		public virtual double generate()
		{
			List<string> remainingWords = new List<string>();
			foreach (string worda in words)
			{
				remainingWords.Add(worda);
			}

			//initialization
			string word = remainingWords[0].ToUpper();
			WordCoordinate coordinate = new WordCoordinate(0,0,rnd.Next(2),0);
			/*new WordCoordinate(rnd.nextInt(grid.getMaxRows()-word.length()),
			        rnd.nextInt(grid.getMaxColumns()-word.length()),rnd.nextInt(2),0);*/

			while (!string.ReferenceEquals(word, null))
			{

				writeWordToGrid(word, coordinate);
                remainingWords.Remove(word);

				addToAnnex(word, coordinate);

				object[] result = pickupWord(remainingWords);
				word = (string)result[0];
				coordinate = (WordCoordinate)result[1];
			}

            //foreach (GeneratedWord gWord in generatedWords)
            //{
            //    Console.WriteLine(gWord.getWord() + ": " + gWord.getDirection() + "(" + gWord.getStartX() + ", " + gWord.getStartY() + ")");
            //}
            int usedCount = words.Count - remainingWords.Count;
            double totalScore = calculateNumIntersectionsEachWord();
            grid.clear();
            return (totalScore / (double)usedCount) * ((double)usedCount / (double)words.Count);
		}

		private object[] pickupWord(List<string> remainingWords)
		{
			WordCoordinate maxCoordinate = null;
			string theWord = null;

			foreach (string word in remainingWords)
			{

				List<WordCoordinate> coordinates = getPossibleCoordinates(word);

				if (coordinates.Count == 0)
				{
					continue;
				}

				coordinates = coordinates.OrderBy(r => r, new WordCoordinateComparator()).ToList();

                if (maxCoordinate == null || (maxCoordinate.Score < coordinates[0].Score))
				{

					maxCoordinate = coordinates[0];
					theWord = word;
				}
			}

			return new object[]{theWord, maxCoordinate};
		}

		private List<WordCoordinate> getPossibleCoordinates(string word)
		{

			List<WordCoordinate> coordList = new List<WordCoordinate>();

			for (int k = 0; k < word.Length; k++)
			{

				for (int i = 0; i < grid.MaxRows; i++)
				{

					for (int j = 0; j < grid.MaxColumns; j++)
					{
                        //tambahi disini untuk checker 
						//horizontal
						if (j - k >= 0 && ((j - k) + word.Length < grid.MaxColumns))
						{
							coordList.Add(new WordCoordinate(i, j - k, 0, 0));
						}

						//vertical
						if (i - k >= 0 && ((i - k) + word.Length < grid.MaxRows))
						{
							coordList.Add(new WordCoordinate(i - k, j, 1, 0));
						}
					}
				}
			}

			List<WordCoordinate> toRet = new List<WordCoordinate>();

			foreach (WordCoordinate coordinate in coordList)
			{

				int score = checkScore(word, coordinate);
				if (score == 0)
				{
					continue;
				}

				toRet.Add(new WordCoordinate(coordinate.X, coordinate.Y, coordinate.Direction, score));
			}

			return toRet;
		}

		private int checkScore(string word, WordCoordinate coordinate)
		{
			int row = coordinate.X;
			int col = coordinate.Y;

			if (col < 0 || row < 0)
			{
				return 0;
			}

			int count = 1;
			int score = 1;

			foreach (char? letter in word.ToCharArray())
			{

				if (!isEmpty(row, col) && grid.getValue(row,col) != letter.Value)
				{
					return 0;
				}

				if (grid.getValue(row,col) == letter.Value)
				{
					score++;
				}

				if (coordinate.Direction == 1)
				{
					//vertical
					if (grid.getValue(row,col) != letter.Value && (!isEmpty(row, col + 1) || !isEmpty(row, col - 1)))
					{
						return 0;
					}

					if (count == 1 && !isEmpty(row - 1, col))
					{
						return 0;
					}

					if (count == word.Length && !isEmpty(row + 1,col))
					{
						return 0;
					}

					row++;

				}
				else
				{
					//Horizontal

					if (grid.getValue(row,col) != letter.Value && (!isEmpty(row - 1, col) || !isEmpty(row + 1, col)))
					{
						return 0;
					}

					if (count == 1 && !isEmpty(row, col - 1))
					{
						return 0;
					}

					if (count == word.Length && !isEmpty(row,col + 1))
					{
						return 0;
					}

					col++;
				}

				count++;
			}

			return score;
		}

        private double calculateNumIntersectionsEachWord()
        {
            for (int i = 0; i < generatedWords.Count; i++)
            {
                int wordLength = generatedWords[i].getWord().Length;
                int startX = generatedWords[i].getStartX(); // Y?
                int startY = generatedWords[i].getStartY(); // X?
                int numOfIntersections = 0;

                if (generatedWords[i].getDirection() == 0) // horizontal
                {
                    for (int j = startY; j < wordLength + startY; j++)
                    {
                    
                        if (startX == 0)
                        {
                            if (grid.getValue(startX + 1, j) != ' ')
                            {
                                numOfIntersections++;
                            }
                        }
                        else if (startX == grid.MaxRows - 1)
                        {
                            if (grid.getValue(startX - 1, j) != ' ')
                            {
                                numOfIntersections++;
                            }
                        }
                        else
                        {
                            if (grid.getValue(startX + 1, j) != ' ' || grid.getValue(startX - 1, j) != ' ')
                            {
                                numOfIntersections++;
                            }
                        }
                    }   
                }
                else if (generatedWords[i].getDirection() == 1) // vertical
                {
                    for (int j = startX; j < wordLength + startX; j++)
                    {
                        if (startY == 0)
                        {
                            if (grid.getValue(j, startY + 1) != ' ')
                            {
                                numOfIntersections++;
                            }
                        }
                        else if (startY == grid.MaxColumns - 1)
                        {
                            if (grid.getValue(j, startY - 1) != ' ')
                            {
                                numOfIntersections++;
                            }
                        }
                        else
                        {
                            if (grid.getValue(j, startY + 1) != ' ' || grid.getValue(j, startY - 1) != ' ')
                            {
                                numOfIntersections++;
                            }
                        }
                    }
                }

                generatedWords[i].setNumIntersections(numOfIntersections);
                //Console.WriteLine(generatedWords[i].getWord() + ": " + generatedWords[i].getIntersectionScore());
            }

            double total = 0;
            foreach (GeneratedWord gWord in generatedWords)
            {
                total += gWord.getIntersectionScore();
            }
            return total;
        }

		private bool isEmpty(int row, int column)
		{

			char value = grid.getValue(row, column);

			return value == ' ' || value == (char)0;
		}

		private void writeWordToGrid(string word, WordCoordinate coordinate)
		{

			int k = 0;
            int startX = 0;
            int startY = 0;

			for (int i = (coordinate.Direction == 0) ? coordinate.Y : coordinate.X; i < word.Length + ((coordinate.Direction == 0) ? coordinate.Y : coordinate.X); i++)
			{
                if (k <= 0)
                {
                    startX = coordinate.X;
                    startY = coordinate.Y;
                }
				grid.setValue(coordinate.Direction == 0 ? coordinate.X : i, coordinate.Direction == 0 ? i : coordinate.Y, word[k++]);
			}

            generatedWords.Add(new GeneratedWord(word, coordinate.Direction, startX, startY));
		}

		private void addToAnnex(string word, WordCoordinate coordinate)
		{
			if (coordinate.Direction == 0)
			{
                Console.WriteLine(horizontalAnnex);
                List<string> l;
                try
                {
                    l = horizontalAnnex[coordinate.X];
                }
                catch (Exception)
                {

                    //throw Exception;
                    l = new List<string>();
                }
				l.Add(word);
				horizontalAnnex[coordinate.X] = l;
			}
			else
			{
                List<string> l;
                try
                {
                    l = verticalAnnex[coordinate.Y];
                }
                catch (Exception)
                {

                    l = new List<string>();
                }

				l.Add(word);
				verticalAnnex[coordinate.Y] = l;
			}
		}

		internal virtual Dictionary<int, List<string>> HorizontalAnnex
		{
			get
			{
				return horizontalAnnex;
			}
		}

		internal virtual Dictionary<int, List<string>> VerticalAnnex
		{
			get
			{
				return verticalAnnex;
			}
		}
	}

}