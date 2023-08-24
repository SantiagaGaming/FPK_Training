using System.Collections.Generic;
public class OtkazModel
{
    public string Place { get; set; }
    private List<string> _checkedItems = new List<string>();
    public List<string> Checked => _checkedItems;
    public void AddOtaz(string newOtkaz)
    {
        _checkedItems.Add(newOtkaz);    }
}
