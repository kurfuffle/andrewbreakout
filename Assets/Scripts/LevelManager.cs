using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Level[] levels;
    [SerializeField] int level;
    [SerializeField] GameObject blockPrefab;
    void Start(){
        Level currentLevel = levels[level];
        for(int y = 0; y < currentLevel.rows.Length; y++){
            Row row = currentLevel.rows[y];
            for(int x = 0; x < row.cols.Length; x++){
                int hp = row.cols[x];
                if (hp != 0){
                    Vector3 pos = new Vector3(x, y, 0);
                    pos.x -= row.cols.Length / 2;
                    pos.x *= blockPrefab.transform.localScale.x;
                    // pos.y -= currentLevel.rows.Length / 2;
                    pos.y *= blockPrefab.transform.localScale.y;
                    GameObject block = Instantiate(blockPrefab, pos, Quaternion.identity);
                    block.GetComponent<BlockManager>().health = hp;
                }
            }
        }
    }
}

[System.Serializable]
struct Level{
    public Row[] rows;
}
[System.Serializable]
struct Row{
    public int[] cols;
}
    