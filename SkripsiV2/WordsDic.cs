
using System.Collections.Generic;
using System.IO;

namespace SkripsiV2
{

	public class WordsDic
	{

		private Dictionary<string, string> dictionary;

		public WordsDic()
		{

			dictionary = new Dictionary<string, string>();

			try
			{

				readDictionary();

			}
			catch (IOException)
			{

				dictionary = new Dictionary<string, string>();
			}
		}

        private void readDictionary()
		{

			string fileName = "soal.txt";
			System.IO.StreamReader reader = new System.IO.StreamReader(fileName);
			string str;

			while (!string.ReferenceEquals((str = reader.ReadLine()), null))
			{

				string[] line = str.Split("/", true);

				dictionary[line[0].Trim()] = line[1].Trim();
			}
			reader.Close();
		}

		public virtual Dictionary<string, string> Dictionary
		{
			get
			{
				return dictionary;
			}
		}

	}

}