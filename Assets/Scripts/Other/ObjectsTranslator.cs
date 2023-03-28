
using System.Collections.Generic;

public class ObjectsTranslator 
{
    public Dictionary<string, string> ObjectsRusNames { get; private set; } = new Dictionary<string, string>();
	public ObjectsTranslator()
	{
		ObjectsRusNames.Add("gloves", "����������� ��������");
        ObjectsRusNames.Add("selfHelper", "����������� �������������");
        ObjectsRusNames.Add("firstAidKit", "����������� �������");
        ObjectsRusNames.Add("journal", "����������� ������ ������������ ���������");
        ObjectsRusNames.Add("lom", "����������� ���");
        ObjectsRusNames.Add("hammer", "����������� �������");
        ObjectsRusNames.Add("fireExtinguisherSour", "����������� ������������ �������������");
        ObjectsRusNames.Add("fireExtinguisherWater", "����������� ������������ ����������������");
        ObjectsRusNames.Add("fresher", "����������� ���������� �������");
        ObjectsRusNames.Add("glasses", "����������� ����");
        ObjectsRusNames.Add("toiletPapper", "����������� ��������� ������");
        ObjectsRusNames.Add("bedStuff", "����������� ���������� ��������������");
        ObjectsRusNames.Add("rubbish", "������������ ����������� � �����");
        ObjectsRusNames.Add("zolnik", "���������� ��������� ������ ��������");
        ObjectsRusNames.Add("kotel", "������������ ����������� � �����");
        ObjectsRusNames.Add("sovok", "����������� �����");
        ObjectsRusNames.Add("crack", "������� �� ��������");
        ObjectsRusNames.Add("insertPaper", "����������� ������� �� ������");
        ObjectsRusNames.Add("paddle", "������������ ���� �����"); 
        ObjectsRusNames.Add("plomba", "����������� ������ �� ���� �����");
        ObjectsRusNames.Add("firehose", "����� �� ������� �� ������");
        ObjectsRusNames.Add("mainPlomba", "����������� ������ �� ���� ����� ");
        ObjectsRusNames.Add("fastening", "������� ��������� ��� ������");
        ObjectsRusNames.Add("cheka", "���������� ���� �������������� ������������");
        ObjectsRusNames.Add("garbageBag", "����������� ������������ ������� ��� ������");
        ObjectsRusNames.Add("mirror", "����������� �������");
        ObjectsRusNames.Add("temperature", "�� ������� ����������� (��������) ");
        ObjectsRusNames.Add("mallet", "����������� ������");
        ObjectsRusNames.Add("halfGlass", "����������� ������������");
        ObjectsRusNames.Add("cutter", "����������� �����");
        ObjectsRusNames.Add("cleaningStuff", "����������� �������� ��� ������");
        ObjectsRusNames.Add("cup", "����������� ������");
        ObjectsRusNames.Add("eatingStuff", "����������� �������� �������");
        ObjectsRusNames.Add("plate", "����������� �������");


        ObjectsRusNames.Add("Kotel", "�������� ���������");
        ObjectsRusNames.Add("WC", "���������� ����");
        ObjectsRusNames.Add("Koridor", "�������");
        ObjectsRusNames.Add("SmallKoridor", "����� �������");
        ObjectsRusNames.Add("ObliqueKoridor", "����� �������");
        ObjectsRusNames.Add("CoupeSleep", "���� ����������(������)");
        ObjectsRusNames.Add("CoupeOfficial", "���� ����������(���������)");
        ObjectsRusNames.Add("VestibuleWorking", "������ �������");
        ObjectsRusNames.Add("VestibuleNonWorking", "������ ���������");
        ObjectsRusNames.Add("None", "��������� �������������:");
    }
}
