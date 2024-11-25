using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interfaces : MonoBehaviour
{

}

public interface IPathfinding
{
    Vector3 FindPath();
}

public interface IDamageable
{
    void TakeDamage(float damage);
}