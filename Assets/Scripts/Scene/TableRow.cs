using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableRow : MonoBehaviour
{
  [SerializeField] private Image _image;
  [SerializeField] private Text _itemNameText;
  [SerializeField] private Text _weightText;
  [SerializeField] private Text _amountText;

  public void Init(TableRowItem rowItem)
  {
    if (rowItem.sprite != null)
    {
      _image.sprite = rowItem.sprite;
    }
    _itemNameText.text = rowItem.itemName;
    _weightText.text = rowItem.weight.ToString();
    _amountText.text = rowItem.amount.ToString();
  }
}

public class TableRowItem
{
  public Sprite sprite;
  public string itemName;
  public float weight;
  public int amount;

  public TableRowItem(RewardItem item, int lootAmount)
  {
    sprite = item.sprite;
    itemName = item.itemName;
    weight = item.weight;
    amount = lootAmount;
  }
}
