using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private GlobalEnums.Elements _element;
    [SerializeField] private CombatManager _manager;

    public bool switcher;
    // Start is called before the first frame update
    void Start()
    {
        _health = 25;
        switcher = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int incDamage)
    {
        int damage = (int)(incDamage * _manager.ElementCalc.CalculateElement(Equipment.Instance.CurrentSwordElement, _element));

        _health -= damage;

        Debug.Log("Multi " + _manager.ElementCalc.CalculateElement(Equipment.Instance.CurrentSwordElement, _element));
        Debug.Log("Damage " + damage);

        if (_health <= 0)
        {
            _manager.EnemyDeath();
            Destroy(gameObject);
        }
        else
        {
            _manager.ExitPlayerPhase();
        }
    }

    private void OnMouseDown()
    {
        TakeDamage(Random.Range(12, 21));
    }

    public void AssignElement(GlobalEnums.Elements toAssign, CombatManager newManager)
    {
        _element = toAssign;
        _manager = newManager;
    }
}
