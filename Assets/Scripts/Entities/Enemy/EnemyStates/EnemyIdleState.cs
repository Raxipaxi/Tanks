using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState<T> : State<T>
{
    //private T _inputPatrol;
   // private T _inputFollow;
    private Enemy _enemy;
    private iNode _root;

    public EnemyIdleState(Enemy enemy, T inputPatrol, iNode root)
    {
        _enemy = enemy;
        _root = root;
        //_inputPatrol = inputPatrol;
    }

    public override void Execute()
    {
        _enemy.Idle();

        _root.Execute();
 

    }


}
