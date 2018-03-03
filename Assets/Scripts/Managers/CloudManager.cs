using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour 
{

	public GameObject cloudSpriteSheetGO;
	public Sprite[] spriteArray;
	public int numberOfCloudsToSpawn = 12;
	float spawnRadius = 2f;

	Transform cloudSpawnPoint;


	void Start()
	{
		cloudSpawnPoint = transform;
		StartCoroutine(SpawnCloud(numberOfCloudsToSpawn));
	}

	IEnumerator SpawnCloud(int _numberOfCloudsToSpawn)
	{	
		for (int i = 0; i < _numberOfCloudsToSpawn; i++)
		{
			GameObject clone = Instantiate(cloudSpriteSheetGO, (Vector2) cloudSpawnPoint.position + Random.insideUnitCircle * spawnRadius, Quaternion.identity);
			SpriteRenderer cloneSR = clone.GetComponent<SpriteRenderer>();

			cloneSR.sprite = spriteArray[Random.Range(0, spriteArray.Length) ];
			if(Random.Range(0, 2) == 1)
				cloneSR.flipX = true;
			
			clone.transform.localScale = Vector2.one * Random.Range(0.8f, 6f);
			cloneSR.color = new Color(1f, 1f, 1f, Random.Range(0.1f, 1f));

			if(cloneSR.color.a <= 0.4f)
				cloneSR.sortingLayerName = "Foreground";
			
			clone.transform.SetParent(transform);
			yield return new WaitForSeconds(0.2f);
		}
	}

	public void ResetCloud(Transform _cloud)
	{
		_cloud.position = (Vector2) cloudSpawnPoint.position + Random.insideUnitCircle * spawnRadius;
	}

}
