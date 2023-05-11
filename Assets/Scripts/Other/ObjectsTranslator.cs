
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
        ObjectsRusNames.Add("plomba", "����������� ������ �� ���� �����    ");
        ObjectsRusNames.Add("firehose", "����� �� ������� �� ������");
        ObjectsRusNames.Add("mainPlomba", "����������� ������ �� ���� �����  ");
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
        ObjectsRusNames.Add("stairsPlomba", "����������� ������ �� ��������");
        ObjectsRusNames.Add("plombaObliqueKoridor", "���������� ������ ������������ ");
        ObjectsRusNames.Add("chekaObliqueKoridor", "���������� ���� ������������ ");
        ObjectsRusNames.Add("zolnikDirt", "������������ ����������� � ��������");
        ObjectsRusNames.Add("kotelDoor", "���������� ��������� ������ �����");
        ObjectsRusNames.Add("scraper", "����������� �������");
        ObjectsRusNames.Add("pages", "������� �������� ������� ��");
        ObjectsRusNames.Add("plombaMedKit", "����������� ������ �������");
        ObjectsRusNames.Add("chekaSmallKoridor", "���������� ���� ������������");
        ObjectsRusNames.Add("plombaSmallKoridor", "���������� ������ ������������");
        ObjectsRusNames.Add("toiletTovel", "����������� �������� ���������");
        ObjectsRusNames.Add("coalBox", "�� ������ ���� ��� ����");
        ObjectsRusNames.Add("plombaVestibuleNonWorking", "����������� ������ �� ���� ����� ");
        ObjectsRusNames.Add("coal", "������������� ���������� ����");
        ObjectsRusNames.Add("plombaKotelRoom", "����������� ������ �� ���� �����");
        ObjectsRusNames.Add("hammerOutside", "������������ ����������� �������� �� �������");
        ObjectsRusNames.Add("rastryb", "����������� ������� ������������");
        ObjectsRusNames.Add("wcTap", "������ ����");
        ObjectsRusNames.Add("fasteningBolt", "����������� ����� ��������� ������");
        ObjectsRusNames.Add("shkvorenCoupeOfficial", "�������� �� ������ �������");
        ObjectsRusNames.Add("bridge", "���������� ��������� �� �������");
        ObjectsRusNames.Add("musorKoridor", "��������� ���� ��� �������� ����� ");
        ObjectsRusNames.Add("shkvorenCoupe9", "�������� �� ������ ������� ");
        ObjectsRusNames.Add("gazetnitsa", "�������� ���� ���������");
        ObjectsRusNames.Add("tipovoeCoupeGazet", "�������� ���� ��������� ");
        ObjectsRusNames.Add("coupe9Gazet", "�������� ���� ���������  ");
        ObjectsRusNames.Add("outsideBox", "�� ������ ����");
        ObjectsRusNames.Add("metla", "����������� �������");
        ObjectsRusNames.Add("treeScraper", "����������� �������");
        ObjectsRusNames.Add("bedStuffCoupe2", "����������� ���������� �������������� ");
        ObjectsRusNames.Add("bedStuffCoupe9", "����������� ���������� ��������������  ");
        ObjectsRusNames.Add("fireExtinguisherHose", "��������� ����� ������������");
        ObjectsRusNames.Add("socketKoridor", "�� ���������� �������");
        ObjectsRusNames.Add("socketCoupeSleep", "�� ���������� ������� ");
        ObjectsRusNames.Add("socketCoupeOfficial", "�� ���������� �������  ");
        ObjectsRusNames.Add("socketCoupeNumber2", "�� ���������� �������   ");
        ObjectsRusNames.Add("socketCoupeNumber9", "�� ���������� �������    ");
        ObjectsRusNames.Add("fastenersCoupeSleep", "������ ��������� �����");
        ObjectsRusNames.Add("fastenersCoupeNumber2", "������ ��������� ����� ");
        ObjectsRusNames.Add("fastenersCoupeNumber9", "������ ��������� �����  ");
        ObjectsRusNames.Add("tableCoupeNumber2", "���������� ��������� �������");
        ObjectsRusNames.Add("tableCoupeNumber9", "���������� ��������� ������� ");
        ObjectsRusNames.Add("gazetnitsaCoupeSleep", "���������� ��������� ���������");
        ObjectsRusNames.Add("gazetnitsaCoupeNumber2", "���������� ��������� ��������� ");
        ObjectsRusNames.Add("gazetnitsaCoupeNumber9", "���������� ��������� ���������  ");
        ObjectsRusNames.Add("inventoryDoor", "���� ��� ��������� �� ������");
        ObjectsRusNames.Add("tO2TO3", "���������� ��������� (��2, ��3)");
        ObjectsRusNames.Add("ladderOutside", "����� ��������");
        ObjectsRusNames.Add("handlerOutside", "����� �����");
        ObjectsRusNames.Add("tornFireHose", "������ �����");
        ObjectsRusNames.Add("dateFire", "��������� ������������");
        ObjectsRusNames.Add("dateTO", "�������������� ���� �� ���������(��2, ��3)");
        ObjectsRusNames.Add("povodok", "������� ��������");
        ObjectsRusNames.Add("brokenLamp", "���������� �����");
        ObjectsRusNames.Add("garbageWC2", "����������� �������� �����");
        ObjectsRusNames.Add("garbageWC", "����������� �������� ����� ");



        ObjectsRusNames.Add("Kotel", "������ ������� � ��");
        ObjectsRusNames.Add("WC", "���������� ����");
        ObjectsRusNames.Add("Koridor", "�������");
        ObjectsRusNames.Add("SmallKoridor", "����� �������");
        ObjectsRusNames.Add("ObliqueKoridor", "����� �������");
        ObjectsRusNames.Add("CoupeSleep", "���� ����������(������)");
        ObjectsRusNames.Add("CoupeOfficial", "���� ����������(���������)");
        ObjectsRusNames.Add("VestibuleWorking", "������ �������");
        ObjectsRusNames.Add("VestibuleNonWorking", "������ ���������");
        ObjectsRusNames.Add("WagonOutside", "����� �������");
        ObjectsRusNames.Add("None", "��������� �������������:");
        ObjectsRusNames.Add("CoupeNumber9", "���� � 9");
        ObjectsRusNames.Add("CoupeNumber2", "���� � 2");
    }
}
