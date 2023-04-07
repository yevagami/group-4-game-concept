/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#include "stdafx.h"
#include "BlockController.h"

// Constructor
BlockController::BlockController(int requiredItems)
{
    this->requiredItems = requiredItems;
    collectedItems = 0;
}

// OnTriggerEnter method
void BlockController::OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        // increment collected items counter
        collectedItems++;

        // check if player has collected enough items
        if (collectedItems >= requiredItems)
        {
            // enable block
            gameObject.SetActive(true);
        }
    }
}
*/