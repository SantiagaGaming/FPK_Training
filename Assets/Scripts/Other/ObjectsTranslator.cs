
using System.Collections.Generic;

public class ObjectsTranslator 
{
    public Dictionary<string, string> ObjectsRusNames { get; private set; } = new Dictionary<string, string>();
    public List<string> ObjectsWithId = new List<string>();
	public ObjectsTranslator()
	{
		ObjectsRusNames.Add("gloves", "��������");
        ObjectsRusNames.Add("selfHelper", "�������������");
        ObjectsRusNames.Add("firstAidKit", "�������");
        ObjectsRusNames.Add("journal", "������ ������������ ���������");
        ObjectsRusNames.Add("lom", "���");
        ObjectsRusNames.Add("hammer", "�������");
        ObjectsRusNames.Add("fireExtinguisherSour", "������������ �������������");
        ObjectsRusNames.Add("fireExtinguisherWater", "������������ ����������������");
        ObjectsRusNames.Add("fresher", "��������� �������");
        ObjectsRusNames.Add("glasses", "����");
        ObjectsRusNames.Add("toiletPapper", "�������� ���������");
        ObjectsRusNames.Add("bedStuff", "���������� ��������������");
        ObjectsRusNames.Add("rubbish", "����������� � �����");
    }
}
