using System;
using System.IO;
using System.Text.Json;

namespace TerrariaWorldNameGenerator
{
	class Program
	{
		static void Main(string[] args)
		{
			for (int i = 0; i < 1000; i++)
			{
				Console.WriteLine(GetRandomWorldName());
			}
		}

		static Program()
		{
			var json = File.ReadAllText("data.json");
			data = JsonSerializer.Deserialize<RandomWorldNameData>(json);
		}

		static RandomWorldNameData data;
		static Random random = new Random();

		static string GetRandomWorldName()
		{
			var composition = data.RandomWorldName_Composition[
				random.Next(0, data.RandomWorldName_Composition.Length)
			];

			var adjective = data.RandomWorldName_Adjective[
				random.Next(0, data.RandomWorldName_Adjective.Length)
			];

			var location = data.RandomWorldName_Location[
				random.Next(0, data.RandomWorldName_Location.Length)
			];

			var noun = data.RandomWorldName_Noun[
				random.Next(0, data.RandomWorldName_Noun.Length)
			];

			var name = composition.Replace("{", "");
			name = name.Replace("}", "");
			name = name.Replace("Adjective", adjective);
			name = name.Replace("Location", location);
			name = name.Replace("Noun", noun);

			return name;
		}
	}

	class RandomWorldNameData
	{
		public string[] RandomWorldName_Composition { get; set; }
		public string[] RandomWorldName_Adjective { get; set; }
		public string[] RandomWorldName_Location { get; set; }
		public string[] RandomWorldName_Noun { get; set; }
	}
}
