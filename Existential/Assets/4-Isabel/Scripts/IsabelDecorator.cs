/* Written by Isabel Hinkle
 * Script to implement the decorator pattern
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsabelDecorator : GiftTrigger{
    // Checks to see if we have collided with an NPC, then set to false until next collision
    void FixedUpdate(){
        if(npcCollision1){
            NPCInterTotal();
            npcCollision1 = false;
        } 
    }
    // This function helps implement decorator
    public override int NPCInterTotal(){
        Debug.Log("You have collided with " + numNPCsInter + " NPC's.");
        return numNPCsInter;
    }
    
}
