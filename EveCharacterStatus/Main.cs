using System;
using System.Collections.Generic;
//using EveAI.Live;


namespace EveCharacterStatus
{
	class MainClass
	{
		public static void Main (string[] args)
	{
			AttributeWriter attributeWriter = new AttributeWriter();

			ClientForAPI api = new ClientForAPI(1904964, "zesRGv3T3jsETycEd0gChWLvA4VCj1xPN7c5kGgfdwRgrXIE80ARYe1EDcvAUZw7",  268435455);

			Character character = api.getCharacter(false);

			Console.WriteLine ("Name: " + character.name);

			foreach (KeyValuePair<string, double> attrib in character.attributes)
			{
				attributeWriter.PrintAttribute(attrib);
			}

			foreach (KeyValuePair<string, double> attribAug in character.attributeAugmentations)
			{
				attributeWriter.PrintAttributeAugmentors(attribAug);
			}

			foreach (KeyValuePair<string,double> attribTotal in character.attributeTotals)
			{
				attributeWriter.PrintAttributeTotals (attribTotal);
			}

			foreach(KeyValuePair<string,double> attrib in character.attributes)
			{
				string currentAttribute = attrib.Key;

				KeyValuePair<string,double> augmentor = new KeyValuePair<string,double>(currentAttribute, character.attributeAugmentations.GetValue(currentAttribute,));
				KeyValuePair<string,double> total = new KeyValuePair<string, double>(currentAttribute, character.attributeTotals.GetValue(currentAttribute,));

				attributeWriter.PrintAttributeBreakdown (attrib, augmentor, total );

			}

			// attributeWriter.PrintIntelligence(character);
			// attributeWriter.PrintPerception(character);
			// attributeWriter.PrintCharisma(character);
			// attributeWriter.PrintWillpower(character);
			// attributeWriter.PrintMemory(character);



			Console.ReadLine();

		}
	}
}
