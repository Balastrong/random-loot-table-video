using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LootGenerator : MonoBehaviour
{
  [SerializeField] private InputField _input;
  [SerializeField] private LootBagController _lootBagController;
  [SerializeField] private LootTable _lootTable;

  public void OnLootButton()
  {
    var lootedItems = Enumerable.Range(0, int.Parse(_input.text))       // Read the amount of items
        .Select(_ => _lootTable.GetRandomItem())                        // Get as many items as the read value
        .GroupBy(item => item)                                          // Group them
        .Select(group => new TableRowItem(group.Key, group.Count()))    // Count and create the Table Item for the simulation
        .OrderByDescending(tableRowItem => tableRowItem.amount)         // Sort by amount
        .ToList();

    _lootBagController.PopulateTable(lootedItems);
  }
}
