
using System.Collections.Generic;

public class ObjectsTranslator 
{
    public Dictionary<string, string> ObjectsRusNames { get; private set; } = new Dictionary<string, string>();
    public List<string> ObjectsWithId = new List<string>();
	public ObjectsTranslator()
	{
		ObjectsRusNames.Add("gloves", "Отсутствуют перчатки");
        ObjectsRusNames.Add("selfHelper", "Отсутствует самоспасатель");
        ObjectsRusNames.Add("firstAidKit", "Отсутствует аптечка");
        ObjectsRusNames.Add("journal", "Отсутсвутет журнал технического состояния");
        ObjectsRusNames.Add("lom", "Отсутствует лом");
        ObjectsRusNames.Add("hammer", "Отсутствует молоток");
        ObjectsRusNames.Add("fireExtinguisherSour", "Отсутствует огнетушитель углекислотный");
        ObjectsRusNames.Add("fireExtinguisherWater", "Отсутствует огнетушитель водоэмульсионный");
        ObjectsRusNames.Add("fresher", "Отсутствует освежитель воздуха");
        ObjectsRusNames.Add("glasses", "Отсутствуют очки");
        ObjectsRusNames.Add("toiletPapper", "Отсутствуют бумажные полотенца");
        ObjectsRusNames.Add("bedStuff", "Отсутствуют постельные принадлежности");
        ObjectsRusNames.Add("rubbish", "Присутствует загрязнение в сливе");
    }
}
