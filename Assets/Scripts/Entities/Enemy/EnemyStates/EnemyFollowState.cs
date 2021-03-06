using UnityEngine;

public class EnemyFollowState<T> : State<T>
{
    #region Properties

    private Enemy _enemy;
    private T _inputPatrol;
    private iNode _root;

    private Transform _target;
    private Transform _transform;

    private ISteering _seek;
    private ObstacleAvoidance _obstacleAvoidance;
    
    #endregion

    public EnemyFollowState(Enemy enemy,T inputPatrol, iNode root, ObstacleAvoidance obs)
    {
        _enemy = enemy;
        _root = root;
        _inputPatrol = inputPatrol;
        _target = _enemy.target.transform;
        _transform = _enemy.transform;
        _obstacleAvoidance = obs;
    }

    public override void Execute()
    {
        _enemy.Move(Chase(),_enemy.tank.Speed);
        _root.Execute();

    }
    private Vector3 Chase()
    {
        _seek = new Seek(_transform, _target);
        _obstacleAvoidance.SetTarget(_target);
        _obstacleAvoidance.SetSelf(_transform);
    
        return _obstacleAvoidance.GetDir(_seek.GetDir());
    }
}
