using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public enum CombatPhase { PLAYER, ENEMY, RESULT };
    [SerializeField] private CombatPhase combatState;

    public GameObject[] EnemySpots;
    public Sprite[] EnemySprites;
    public ElementCalculator ElementCalc;

    private int _enemyNum;
    private float _defenseMulti;

    // Start is called before the first frame update
    void Start()
    {
        StartCombat();
        EnterPlayerPhase();
    }

    // Update is called once per frame
    void Update()
    {
        RunState();
    }

    void StartCombat()
    {
        _enemyNum = Random.Range(1, 5);

        _defenseMulti = 1f;

        Debug.Log(_enemyNum);

        for (int i = 0; i < 4; i++)
        {
            if (i < _enemyNum)
            {
                Enemy ene = EnemySpots[i].GetComponent<Enemy>();
                int j = Random.Range(0, 4);
                ene.AssignElement((GlobalEnums.Elements)j, this);

                float k = Random.Range(0f, 1f);
                if (k <=0.75f)
                {
                    ene.switcher = true;
                }

                EnemySpots[i].GetComponent<SpriteRenderer>().sprite = EnemySprites[j];
            }
            else
            {
                EnemySpots[i].SetActive(false);
            }

        }
    }

    public void EnemyDeath()
    {
        _enemyNum--;

        if (_enemyNum <= 0)
        {
            float rand = Random.Range(0f, 1f);

            if(rand <= 0.75f)
            {
                Equipment.Instance.PotionNum++;
            }
            else
            {
                Equipment.Instance.SupPotionNum++;
            }

            SceneLoader.Instance.LoadLastLevel();
        }
    }

    public void Defending()
    {
        _defenseMulti = 0.5f;
        ExitPlayerPhase();
    }

    void RunState()
    {
        if (combatState == CombatPhase.PLAYER)
        {
            RunPlayerPhase();
        }
        if (combatState == CombatPhase.ENEMY)
        {
            RunEnemyPhase();
        }
        if (combatState == CombatPhase.RESULT)
        {
            RunResultPhase();
        }
    }

    void EnterPlayerPhase()
    {
        combatState = CombatPhase.PLAYER;

        foreach (GameObject enemy in EnemySpots)
        {
            if (enemy != null)
            {
                enemy.GetComponent<Collider2D>().enabled = true;
            }
        }
    }

    void RunPlayerPhase()
    {

    }

    public void ExitPlayerPhase()
    {
        foreach (GameObject enemy in EnemySpots)
        {
            if (enemy != null)
            {
                enemy.GetComponent<Collider2D>().enabled = false;
            }
        }

        EnterEnemyPhase();
    }

    void EnterEnemyPhase()
    {
        combatState = CombatPhase.ENEMY;

        int damage = 0;

        for (int i = 0; i < _enemyNum; i++)
        {
            damage += Random.Range(1, 16);
        }

        damage = (int)(damage * _defenseMulti);
        _defenseMulti = 1f;

        Equipment.Instance.TakeDamage(damage);
        ExitEnemyPhase();
    }

    void RunEnemyPhase()
    {

    }

    void ExitEnemyPhase()
    {
        foreach (GameObject ene in EnemySpots)
        {
            if(ene != null)
            {
                Enemy enemy = ene.GetComponent<Enemy>();
                if (enemy.switcher)
                {
                    int j = Random.Range(0, 4);
                    enemy.AssignElement((GlobalEnums.Elements)j, this);
                    enemy.GetComponent<SpriteRenderer>().sprite = EnemySprites[j];
                }
            }
        }

        EnterResultPhase();
    }

    void EnterResultPhase()
    {
        combatState = CombatPhase.RESULT;
        ExitResultPhase();
    }

    void RunResultPhase()
    {

    }

    void ExitResultPhase()
    {
        EnterPlayerPhase();
    }
}
