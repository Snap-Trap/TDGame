using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interfaces : MonoBehaviour
{

}

public interface IDamageable
{
    void TakeDamage(float damage);
}

public interface IUpgradeable
{
    void Upgrade();
}