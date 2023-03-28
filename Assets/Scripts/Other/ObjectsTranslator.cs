
using System.Collections.Generic;

public class ObjectsTranslator 
{
    public Dictionary<string, string> ObjectsRusNames { get; private set; } = new Dictionary<string, string>();
	public ObjectsTranslator()
	{
		ObjectsRusNames.Add("gloves", "Отсутствуют рукавицы");
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
        ObjectsRusNames.Add("insertPaper", "Отсутствуют вставки на унитаз");
        ObjectsRusNames.Add("paddle", "Присутствует течь крана"); 
        ObjectsRusNames.Add("plomba", "Отсутствует пломба на стоп кране");
        ObjectsRusNames.Add("firehose", "Рукав не скручен на бобину");
        ObjectsRusNames.Add("mainPlomba", "Отсутствует пломба на стоп кране ");
        ObjectsRusNames.Add("fastening", "Сломано крепление для каната");
        ObjectsRusNames.Add("cheka", "Отсутствие чеки углекислотного огнетушителя");
        ObjectsRusNames.Add("garbageBag", "Отсутствует металический вкладыш для мусора");
        ObjectsRusNames.Add("mirror", "Отсутствует зеркало");
        ObjectsRusNames.Add("temperature", "Не греется кипятильник (термопот) ");
        ObjectsRusNames.Add("mallet", "Отсутствует киянка");
        ObjectsRusNames.Add("halfGlass", "Отсутствует подстаканник");
        ObjectsRusNames.Add("cutter", "Отсутствует резак");
        ObjectsRusNames.Add("cleaningStuff", "Отсутствуют средства для уборки");
        ObjectsRusNames.Add("cup", "Отсутствует стакан");
        ObjectsRusNames.Add("eatingStuff", "Отсутствуют столовые приборы");
        ObjectsRusNames.Add("plate", "Отсутствует тарелка");


        ObjectsRusNames.Add("Kotel", "Котловое отделение");
        ObjectsRusNames.Add("WC", "Санитарный узел");
        ObjectsRusNames.Add("Koridor", "Коридор");
        ObjectsRusNames.Add("SmallKoridor", "Малый коридор");
        ObjectsRusNames.Add("ObliqueKoridor", "Косой коридор");
        ObjectsRusNames.Add("CoupeSleep", "Купе проводника(отдыха)");
        ObjectsRusNames.Add("CoupeOfficial", "Купе проводника(служебное)");
        ObjectsRusNames.Add("VestibuleWorking", "Тамбур рабочий");
        ObjectsRusNames.Add("VestibuleNonWorking", "Тамбур нерабочий");
        ObjectsRusNames.Add("None", "Выбранные неисправности:");
    }
}
