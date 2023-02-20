
using System.Collections.Generic;

public class ObjectsTranslator 
{
    public Dictionary<string, string> ObjectsRusNames { get; private set; } = new Dictionary<string, string>();
    public List<string> ObjectsWithId = new List<string>();
	public ObjectsTranslator()
	{
		ObjectsRusNames.Add("gloves", "Перчатки");
        ObjectsRusNames.Add("selfHelper", "Самоспасатель");
        ObjectsRusNames.Add("firstAidKit", "Аптечка");
        ObjectsRusNames.Add("journal", "Журнал технического состояния");
        ObjectsRusNames.Add("lom", "Лом");
        ObjectsRusNames.Add("hammer", "Молоток");
        ObjectsRusNames.Add("fireExtinguisherSour", "Огнетушитель углекислотный");
        ObjectsRusNames.Add("fireExtinguisherWater", "Огнетушитель водоэмульсионный");
        ObjectsRusNames.Add("fresher", "Освежилье воздуха");
        ObjectsRusNames.Add("glasses", "Очки");
        ObjectsRusNames.Add("toiletPapper", "Бумажные полотенца");
        ObjectsRusNames.Add("bedStuff", "Постельные принадлежности");
        ObjectsRusNames.Add("rubbish", "Загрязнение в сливе");
    }
}
