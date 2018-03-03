using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

	public List<Texture2D> map;
	public ColorToPrefab[] colorMappings;
	private float _timeUntilNextSpawn = 5.3333333333333333333333f;
	// did math with coin spawn rate, hardcoded cause lazy.

	private int _rangeLength = 3;

	void Start()
	{
		map = map.OrderBy(t=>t.name).ToList();
		StartCoroutine(GenerateLevel());
	}

	IEnumerator GenerateLevel()
	{

		while (true)
		{
			int mapToSpawn = GetMapToSpawn();

			for (int x = 0; x < map[mapToSpawn].width; x++)
			{
				for (int y = 0; y < map[mapToSpawn].height; y++)
				{
					GenerateTile(x, y, mapToSpawn);
				}
			}

			yield return new WaitForSeconds(_timeUntilNextSpawn);
		}
	}

	int GetMapToSpawn()
	{
		int rand;
		int min;
		int max;
		int d;
		d = GameManager._Difficulty;

		int addedRange = (d + _rangeLength);
		int subRange = (d - _rangeLength);

		if (subRange >= map.Count + _rangeLength)
		{
			max = map.Count;
			min = max - _rangeLength;
		}
		else
		{
			if (subRange < 0)
				min = 0;
			else
				min = d - _rangeLength;
			if ((int)addedRange >= (int)map.Count)
				max = map.Count;
			else
				max = (d + _rangeLength);
			if (max > map.Count)
				max = map.Count;

			if ((int)min > (int)max || (int)min == (int)max || min == map.Count)
				min = min - _rangeLength;
		}

		rand = Random.Range(min, max);
		return rand;

	}

	void GenerateTile(int _x, int _y, int mapToSpawn)
	{
		Color pixelColor = map[mapToSpawn].GetPixel(_x, _y);

		if (pixelColor.a == 0)
			return;

		foreach (ColorToPrefab colorMapping in colorMappings)
		{
			if (colorMapping.color.Equals(pixelColor))
			{
				Vector2 position = new Vector2(_x, _y);
				Instantiate(colorMapping.prefab, (Vector2)transform.position + position, Quaternion.identity, transform);
			}
		}
	}
}

















// WHY DOES THIS NOT WORK?!

// int rand, min, max, d;
// 		d = GameManager._Difficulty;

// 		int addedRange = (d + _rangeLength); 
// 		int subRange = (d - _rangeLength); 

// 		if (subRange < 0)
// 			min = 0;
// 		else
// 			min = d - _rangeLength;

// 		if ((int)addedRange >= (int)map.Length)
// 			max = map.Length;
// 		else
// 			max = (d + _rangeLength);

// 		if(min >= max || min == max)
// 			min = min - _rangeLength;

// 		if(min < 0)
// 			min = 0;

// 		if(max > map.Length)
// 			max = map.Length;

// 		print(min + " " + max);

// 		rand = Random.Range(min, max);
// 		return rand;
