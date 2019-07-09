using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetween = 0.5f;
    [SerializeField] float randomFactor = 0.2f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject getEnemy() { return enemyPrefab;  }
    public List<Transform> getPath() {
        var path = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {
            path.Add(child);
        }
        return path;
    }
    public float getTimeBetween() { return timeBetween; }
    public float getRandomFactor() { return randomFactor; }
    public int getEnemyCount() { return numberOfEnemies; }
    public float getMoveSpeed() { return moveSpeed; }

}
