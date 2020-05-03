/**********************
 * Sydney - Static and Dynamic binding
 *
 * There are two classes: SpiritOrbs and the child of the spiritorbs orange
 *********************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Spiritorbs : MonoBehaviour
    {
        //all child classes will contain isSpawn since it is virtual
        //function creates random value between 1 and spawnspeed, 
        //if value is under 2f, and we are not out of objects (based on iterators isDone),
        //spawn the object
        virtual public bool isSpawn(int numOfObjects, float spawnSpeed)
        {
            float poss;
            poss = Random.Range(1f, spawnSpeed);
            if (poss <= 2f && !SydneyIterate.isDone(numOfObjects))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //we still have a virtual function, but we override this in the children classes
        //could not implement with static for some reason
        //just set to spawn bunny
        public virtual void spawnOrb(GameObject obj)
        {
            Vector2 SpawnLocation = new Vector2(1, 5);
            GameObject orb = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Spirit"));
            orb.transform.position = SpawnLocation;
        }
    }

    //child class
    //Since there is a singleton on the cat, the spawner will only spawn one using the instantiatecat function.
    //You can see there are no other cats being spawned in the level.
    // Even though they are set to spawn.s
    public class OrangeOrb : Spiritorbs
{
        //override the Spawn function
        public override void spawnOrb(GameObject obj)
        {
            Vector2 SpawnLocation = new Vector2(2, 4);
            GameObject orb = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Spirit1"));
            orb.transform.position = SpawnLocation;
        }
    }

