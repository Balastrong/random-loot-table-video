using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "LootTable", menuName = "Loot Table")]
public class LootTable : ScriptableObject
{
  // This list is populated from the editor
  [SerializeField] private List<RewardItem> _items;

  // This is NonSerialized as we need it false everytime we run the game.
  // Without this tag, once set to true it will be true even after closing and restarting the game
  // Which means any future modification of our item list is not properly considered
  [System.NonSerialized] private bool isInitialized = false;

  private float _totalWeight;

  private void Initialize()
  {
    if (!isInitialized)
    {
      _totalWeight = _items.Sum(item => item.weight);
      isInitialized = true;
    }
  }

  #region Alternative Initialize()
  // An alternative version that does the same operation, puts in _totalWeight the sum of the weight of each item
  private void AltInitialize()
  {
    if (!isInitialized)
    {
      _totalWeight = 0;
      foreach (var item in _items)
      {
        _totalWeight += item.weight;
        //_totalWeight = _totalWeight + item.weight;
      }

      isInitialized = true;
    }
  }
  #endregion

  public RewardItem GetRandomItem()
  {
    // Make sure it is initalized
    Initialize();

    // Roll our dice with _totalWeight faces
    float diceRoll = Random.Range(0f, _totalWeight);

    // Cycle through our items
    foreach (var item in _items)
    {
      // If item.weight is greater (or equal) than our diceRoll, we take that item and return
      if (item.weight >= diceRoll)
      {
        // Return here, so that the cycle doesn't keep running
        return item;
      }

      // If we didn't return, we substract the weight to our diceRoll and cycle to the next item
      diceRoll -= item.weight;
    }
    
    // As long as everything works we'll never reach this point, but better be notified if this happens!
    throw new System.Exception("Reward generation failed!");
  }
}

[System.Serializable]
public class RewardItem
{
  public string itemName;
  public float weight;
  public Sprite sprite;
  // your item stats go here
}
