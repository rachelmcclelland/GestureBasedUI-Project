using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public class ParentUtils
    {
        public const string BULLET_PARENT = "BulletParent";
        public const string ENEMY_PARENT = "EnemyParent";
        public const string STAR_PARENT = "StarParent";

        public static GameObject GetBulletParent()
        {
            return GetParent(BULLET_PARENT);
        }

        public static GameObject GetEnemyParent()
        {
            return GetParent(ENEMY_PARENT);
        }

        public static GameObject GetStarParent()
        {
            return GetParent(STAR_PARENT);
        }

        private static GameObject GetParent(string parentName)
        {
            // get the bullet parent
            var parent = GameObject.Find(parentName);
            if (!parent)
            {
                parent = new GameObject(parentName);
            }

            return parent;
        }
    }

}

