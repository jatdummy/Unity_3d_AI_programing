using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTableParser : MonoBehaviour
{
    // 파싱 대상이 된 CSV 파일 참조
    [SerializeField] private TextAsset _csvFile;

    // 파싱 결과 보관
    // private Dictionary<int, EnemyData> _enemyDatas = new();
    [SerializeField] private List<MonsterStats> _monsterStatsList = new();


    private void Awake() => LoadTable();

    // 파싱된 결과를 반환 
    
    /*
    public bool TryGetEnemy(int id, out EnemyData data)
    {
        return _enemyDatas.TryGetValue(id, out data);
    }
    */

    // 파싱
    private void LoadTable()
    {
        // 1. 줄 단위로 자른다
        //    RemoveEmptyEntries : \r, \n 사이, 파일 끝에 생기는 빈 줄 제거
        string[] lines = _csvFile.text.Split(
            new char[] { '\r', '\n' },
            StringSplitOptions.RemoveEmptyEntries
            );

        for (int i = 2; i < lines.Length; i++)
        {
            // 2. 쉼표 기준으로 나누기
            //  TSV인 경우 : Split('\t');
            string[] cells = lines[i].Split(',');

            if (cells.Length != 7)
            {
                Debug.LogError($" 요상하이 ");
                continue;
            }

            int id,maxHp, attackValue;
            string name;
            float detectRange, attackRange, speed;

            if (!int.TryParse(cells[0], out id)
                || !int.TryParse(cells[2], out maxHp)
                || !float.TryParse(cells[3], out detectRange)
                || !float.TryParse(cells[4], out attackRange)
                || !float.TryParse(cells[5], out speed)
                || !int.TryParse(cells[6], out attackValue))
            {
                Debug.LogError($" 요상하이22 ");
                continue;
            }
            
            name = cells[1];

            _monsterStatsList[i - 2].SetData(
                id,
                name,
                maxHp,
                detectRange,
                attackRange, 
                speed,
                attackValue
                );
        }
    }

}
