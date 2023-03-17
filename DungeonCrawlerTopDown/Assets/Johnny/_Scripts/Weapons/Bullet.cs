using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    //protected BulletDataSO bulletData;

    //public BulletDataSO BulletData
    //{
    //    get { return bulletData; }
    //    set { bulletData = value; }
    //}


    [field: SerializeField]
    public virtual BulletDataSO BulletData { get; set; }




}
