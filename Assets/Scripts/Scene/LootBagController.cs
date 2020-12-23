using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LootBagController : MonoBehaviour
{
  [SerializeField] private GameObject _tableRowPrefab;
  public void PopulateTable(List<TableRowItem> items)
  {
    // Remove old items
    Enumerable.Range(0, transform.childCount).ToList().ForEach(i => Destroy(transform.GetChild(i).gameObject));

    // Populate with the new items
    items.ForEach(item =>
    {
      // Create an instance of an empty table row
      GameObject row = Instantiate(_tableRowPrefab, transform);

      // Initializes the row with our looted item data
      row.GetComponent<TableRow>().Init(item);
    });
  }

}
