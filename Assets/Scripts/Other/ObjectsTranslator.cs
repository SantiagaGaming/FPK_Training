
using System.Collections.Generic;

public class ObjectsTranslator 
{
    public Dictionary<string, string> ObjectsRusNames { get; private set; } = new Dictionary<string, string>();
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
        ObjectsRusNames.Add("toiletPapper", "Отсутствует туалетная бумага");
        ObjectsRusNames.Add("bedStuff", "Отсутствуют постельные принадлежности");
        ObjectsRusNames.Add("rubbish", "Присутствует загрязнение в сливе");
        ObjectsRusNames.Add("zolnik", "Неисправно крепление дверки зольника");
        ObjectsRusNames.Add("kotel", "Присутствует загрязнение в котле");
        ObjectsRusNames.Add("sovok", "Отсутствует совок");
        ObjectsRusNames.Add("crack", "Трещина на раковине");
        ObjectsRusNames.Add("paper", "Отсутствуют бумажные полотенца");
        ObjectsRusNames.Add("paddle", "Присутствует течь крана");

        ObjectsRusNames.Add("Kotel", "Котловое отделение");
        ObjectsRusNames.Add("WC", "Санитарный узел");
        ObjectsRusNames.Add("Koridor", "Коридор");
        ObjectsRusNames.Add("SmallKoridor", "Малый коридор");
        ObjectsRusNames.Add("ObliqueKoridor", "Косой коридор");
        ObjectsRusNames.Add("CoupeSleep", "Купе проводника(отдыха)");
        ObjectsRusNames.Add("CoupeOfficial", "Купе проводника(служебное)");
        ObjectsRusNames.Add("None", "Выбранные неисправности:");
    }
}
