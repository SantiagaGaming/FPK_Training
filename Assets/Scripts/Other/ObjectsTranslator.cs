
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
        ObjectsRusNames.Add("paper", "����������� �������� ���������");
        ObjectsRusNames.Add("paddle", "������������ ���� �����");

        ObjectsRusNames.Add("Kotel", "�������� ���������");
        ObjectsRusNames.Add("WC", "���������� ����");
        ObjectsRusNames.Add("Koridor", "�������");
        ObjectsRusNames.Add("SmallKoridor", "����� �������");
        ObjectsRusNames.Add("ObliqueKoridor", "����� �������");
        ObjectsRusNames.Add("CoupeSleep", "���� ����������(������)");
        ObjectsRusNames.Add("CoupeOfficial", "���� ����������(���������)");
        ObjectsRusNames.Add("None", "��������� �������������:");
    }
}
