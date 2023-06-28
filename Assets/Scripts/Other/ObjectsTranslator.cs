
using System.Collections.Generic;

public class ObjectsTranslator 
{
    public Dictionary<string, string> ObjectsRusNames { get; private set; } = new Dictionary<string, string>();
	public ObjectsTranslator()
	{
		ObjectsRusNames.Add("f_152", "����������� ��������");
        ObjectsRusNames.Add("f_156", "����������� �������������");
        ObjectsRusNames.Add("f_143", "����������� �������");
        ObjectsRusNames.Add("f_145", "����������� ������ ������������ ���������");
        ObjectsRusNames.Add("f_78", "����������� ���");
        ObjectsRusNames.Add("f_28", "���������� ������� ����� ���� 6 � 7");
        ObjectsRusNames.Add("f_27", "���������� ������� ����� ���� 2 � 3");
        ObjectsRusNames.Add("f_54_1", "����������� ������������ �������������");
        ObjectsRusNames.Add("f_171", "����������� ������������ ����������������");
        ObjectsRusNames.Add("f_188", "����������� ���������� �������");
        ObjectsRusNames.Add("f_149", "����������� ����");
        ObjectsRusNames.Add("f_179", "����������� ��������� ������");
        ObjectsRusNames.Add("f_134", "���������� ���������� ��������������� �����");
        ObjectsRusNames.Add("f_134_1", "���������� ���������� ��������������� ������");
        ObjectsRusNames.Add("f_189", "������������ ����������� � �����");
        ObjectsRusNames.Add("f_71", "���������� ��������� ������ ��������");
        ObjectsRusNames.Add("f_72", "������������ ����������� � �����");
        ObjectsRusNames.Add("f_85", "����������� �����");
        ObjectsRusNames.Add("f_191", "������� �� ��������");
        ObjectsRusNames.Add("f_180", "����������� ������� �� ������");
        ObjectsRusNames.Add("f_186", "������������ ���� �����"); 
        ObjectsRusNames.Add("f_67", "����������� ������ �� ���� �����    ");
        ObjectsRusNames.Add("f_65", "����� �� ������� �� ������");
        ObjectsRusNames.Add("f_45", "����������� ������ �� ���� �����  ");
        ObjectsRusNames.Add("f_23", "������� ��������� ������� ����� ���� 2 � 3");
        ObjectsRusNames.Add("f_24", "������� ��������� ������� ����� ���� 6 � 7");
        ObjectsRusNames.Add("f_178", "����������� ������������ ������� ��� ������");
        ObjectsRusNames.Add("f_168", "����������� �������");
        ObjectsRusNames.Add("f_54", "�� ������� ����������� (��������) ");
        ObjectsRusNames.Add("f_214", "����������� ������");
        ObjectsRusNames.Add("f_150", "����������� �������������");
        ObjectsRusNames.Add("f_84", "����������� �����");
        ObjectsRusNames.Add("f_159", "����������� �������� ��� ������");
        ObjectsRusNames.Add("f_160", "����������� �������");
        ObjectsRusNames.Add("f_161", "����������� �������� �������");
        ObjectsRusNames.Add("f_162", "����������� �������");
        ObjectsRusNames.Add("f_87", "����������� ������ �� ��������");
        ObjectsRusNames.Add("f_57", "���������� ������ ������������ ");
        ObjectsRusNames.Add("f_58", "���������� ���� ������������ ");
        ObjectsRusNames.Add("f_70", "������������ ����������� � ��������");
        ObjectsRusNames.Add("f_73", "���������� ��������� ������ �����");
        ObjectsRusNames.Add("f_80", "���������� �������������� �������");
        ObjectsRusNames.Add("f_146", "������� �������� ������� ��");
        ObjectsRusNames.Add("f_144", "����������� ������ �������");
        ObjectsRusNames.Add("f_173", "���������� ���� ������������ ����������������� ������������");
        ObjectsRusNames.Add("f_172", "���������� ������ ������������ ����������������� ������������");
        ObjectsRusNames.Add("f_190", "����������� �������� ���������");
        ObjectsRusNames.Add("f_239", "�� ������ ���� ��� ����");
        ObjectsRusNames.Add("f_219", "����������� ������ �� ���� ����� ");
        ObjectsRusNames.Add("f_238", "������������� ���������� ����");
        ObjectsRusNames.Add("f_237", "����������� ������ �� ���� �����");
        ObjectsRusNames.Add("f_92", "������������ ����������� �������� �� �������");
        ObjectsRusNames.Add("f_59", "����������� ������� ������������");
        ObjectsRusNames.Add("f_185", "������ ����");
        ObjectsRusNames.Add("f_26", "����������� ����� ��������� ������ ����� ���� 6 � 7");
        ObjectsRusNames.Add("f_25", "����������� ����� ��������� ������ ����� ���� 2 � 3");
        ObjectsRusNames.Add("f_165", "�������� �� ������ �������");
        ObjectsRusNames.Add("f_229", "���������� ��������� �� �������");
        ObjectsRusNames.Add("f_47", "��������� ���� ��� �������� ����� ");
        ObjectsRusNames.Add("f_122", "�������� �� ������ ������� ");
        ObjectsRusNames.Add("f_127", "�������� ���� ������ ���������");
        ObjectsRusNames.Add("f_128", "�������� ���� ������� ���������");
        ObjectsRusNames.Add("f_246", "�������� ���� ��������� ����� 5");
        ObjectsRusNames.Add("f_247", "�������� ���� ��������� ����� 6");
        ObjectsRusNames.Add("f_248", "�������� ���� ��������� ����� 7");
        ObjectsRusNames.Add("f_249", "�������� ���� ��������� ����� 8");            
        ObjectsRusNames.Add("f_102", "�������� ���� ��������� ����� 33");
        ObjectsRusNames.Add("f_103", "�������� ���� ��������� ����� 34");
        ObjectsRusNames.Add("f_104", "�������� ���� ��������� ����� 35");
        ObjectsRusNames.Add("f_105", "�������� ���� ��������� ����� 36");
        ObjectsRusNames.Add("f_95", "�� ������ ����");
        ObjectsRusNames.Add("f_215", "����������� �������");
        ObjectsRusNames.Add("f_209", "����������� ���������� �������");
        ObjectsRusNames.Add("f_258", "����������� ���������� �������������� ����� 8");
        ObjectsRusNames.Add("f_258_1", "����������� ���������� �������������� ����� 7");
        ObjectsRusNames.Add("f_258_2", "����������� ���������� �������������� ����� 6");
        ObjectsRusNames.Add("f_258_3", "����������� ���������� �������������� ����� 5");
        ObjectsRusNames.Add("f_114", "����������� ���������� �������������� ����� 33");
        ObjectsRusNames.Add("f_114_1", "����������� ���������� �������������� ����� 34");
        ObjectsRusNames.Add("f_114_2", "����������� ���������� �������������� ����� 35");
        ObjectsRusNames.Add("f_114_3", "����������� ���������� �������������� ����� 36");
        ObjectsRusNames.Add("f_174", "��������� ����� ����������������� ������������");
        ObjectsRusNames.Add("f_30", "�� ���������� ������� ����� ���� 2 � 3");
        ObjectsRusNames.Add("f_31", "�� ���������� ������� ����� ���� 6 � 7");
        ObjectsRusNames.Add("f_136", "�� ���������� ������ �������");
        ObjectsRusNames.Add("f_135", "�� ���������� ������� �������");
        ObjectsRusNames.Add("f_151", "�� ���������� �������");
        ObjectsRusNames.Add("f_259", "�� ���������� ������� ����� 5");
        ObjectsRusNames.Add("f_260", "�� ���������� ������� ����� 6");
        ObjectsRusNames.Add("f_261", "�� ���������� ������� ����� 7");
        ObjectsRusNames.Add("f_262", "�� ���������� ������� ����� 8");
        ObjectsRusNames.Add("f_115", "�� ���������� ������� ����� 33");
        ObjectsRusNames.Add("f_116", "�� ���������� ������� ����� 34");
        ObjectsRusNames.Add("f_117", "�� ���������� ������� ����� 35");
        ObjectsRusNames.Add("f_118", "�� ���������� ������� ����� 36");
        ObjectsRusNames.Add("f_176", "������� �� ����������");
        ObjectsRusNames.Add("f_192", "������� �� ���������� ");
        ObjectsRusNames.Add("f_207", "������� �� ����������  ");
        ObjectsRusNames.Add("f_129", "������ ��������� ������� �����");
        ObjectsRusNames.Add("f_250", "������ ��������� ����� 8");
        ObjectsRusNames.Add("f_251", "������ ��������� ����� 6");
        ObjectsRusNames.Add("f_106", "������ ��������� ����� 34");
        ObjectsRusNames.Add("f_107", "������ ��������� ����� 36");
        ObjectsRusNames.Add("f_265", "���������� ��������� �������");
        ObjectsRusNames.Add("f_121", "���������� ��������� ������� ");
        ObjectsRusNames.Add("f_126", "���������� ��������� ��������� �����");
        ObjectsRusNames.Add("f_125", "���������� ��������� ��������� ������");
        ObjectsRusNames.Add("f_242", "���������� ��������� ��������� ����� 5");
        ObjectsRusNames.Add("f_243", "���������� ��������� ��������� ����� 6");
        ObjectsRusNames.Add("f_244", "���������� ��������� ��������� ����� 7");
        ObjectsRusNames.Add("f_245", "���������� ��������� ��������� ����� 8");
        ObjectsRusNames.Add("f_98", "���������� ��������� ��������� ����� 33");
        ObjectsRusNames.Add("f_99", "���������� ��������� ��������� ����� 34");
        ObjectsRusNames.Add("f_100", "���������� ��������� ��������� ����� 35");
        ObjectsRusNames.Add("f_101", "���������� ��������� ��������� ����� 36");
        ObjectsRusNames.Add("f_223", "���� ��� ��������� �� ������");
        ObjectsRusNames.Add("f_94", "���������� ��������� (��2, ��3)");
        ObjectsRusNames.Add("f_86", "����� ��������");
        ObjectsRusNames.Add("f_88", "����� ����� � ������ ��������� �� ������� ������ ��������");
        ObjectsRusNames.Add("f_89", "����� ����� � ������ ��������� �� ������� ����������� ����");
        ObjectsRusNames.Add("f_90", "����� ����� � ������ �������");
        ObjectsRusNames.Add("f_91", "����� ����� � ������ ���. �� ������� ��������� ���������");
        ObjectsRusNames.Add("f_64", "������ �����");
        ObjectsRusNames.Add("f_60", "��������� ������������");
        ObjectsRusNames.Add("f_93", "�������������� ���� �� ���������(��2, ��3)");
        ObjectsRusNames.Add("f_29", "������� ��������");
        ObjectsRusNames.Add("f_220", "���������� ����� ��������� ����� ������� �����");
        ObjectsRusNames.Add("f_221", "���������� ����� ��������� ����� ������� ������");
        ObjectsRusNames.Add("f_222", "���������� ����� ��������� ����� ������ �����");
        ObjectsRusNames.Add("f_202", "����������� �������� �����");
        ObjectsRusNames.Add("f_187", "����������� �������� ����� ");
        ObjectsRusNames.Add("f_203", "����������� ���������� ������� ");
        ObjectsRusNames.Add("f_194", "����������� ��������� ������ ");
        ObjectsRusNames.Add("f_204", "������������ ����������� � ����� ");
        ObjectsRusNames.Add("f_206", "������� �� �������� ");
        ObjectsRusNames.Add("f_195", "����������� ������� �� ������ ");
        ObjectsRusNames.Add("f_201", "������������ ���� ����� ");
        ObjectsRusNames.Add("f_205", "����������� �������� ��������� ");
        ObjectsRusNames.Add("f_200", "������ ���� ");
        ObjectsRusNames.Add("f_55", "���������� �������");
        ObjectsRusNames.Add("f_155", "�������������� ����� �������� �������������");
        ObjectsRusNames.Add("f_154", "�������� �������� �������������");
        ObjectsRusNames.Add("f_142", "���������� �������");
        ObjectsRusNames.Add("f_175", "��������� ���������������� ������������");
        ObjectsRusNames.Add("f_56", "�������������� ���� ������������");
        ObjectsRusNames.Add("f_170", "�������������� ���� ������������ ");
        ObjectsRusNames.Add("f_193", "���������� ��������� �������������� �����");       
        ObjectsRusNames.Add("f_183", "������ ����� �� ��������");
        ObjectsRusNames.Add("f_198", "������ ����� �� �������� ");
        ObjectsRusNames.Add("f_184", "����������� ���� � �����");
        ObjectsRusNames.Add("f_199", "����������� ���� � ����� ");
        ObjectsRusNames.Add("f_169", "�� ��������� ����� ������������");
        ObjectsRusNames.Add("f_11", "���������� ��������� ���������� �������� ���� ����������");
        ObjectsRusNames.Add("f_12", "���������� ��������� ���������� �������� 1 ����");
        ObjectsRusNames.Add("f_13", "���������� ��������� ���������� �������� 2 ����");
        ObjectsRusNames.Add("f_14", "���������� ��������� ���������� �������� 3 ����");
        ObjectsRusNames.Add("f_15", "���������� ��������� ���������� �������� 4 ����");
        ObjectsRusNames.Add("f_16", "���������� ��������� ���������� �������� 5 ����");
        ObjectsRusNames.Add("f_17", "���������� ��������� ���������� �������� 6 ����");
        ObjectsRusNames.Add("f_18", "���������� ��������� ���������� �������� 7 ����");
        ObjectsRusNames.Add("f_19", "���������� ��������� ���������� �������� 8 ����");
        ObjectsRusNames.Add("f_20", "���������� ��������� ���������� �������� 9 ����");
        ObjectsRusNames.Add("f_1", "�� ����������� ���������� �������� ���� ����������");
        ObjectsRusNames.Add("f_2", "�� ����������� ���������� �������� 1 ����");
        ObjectsRusNames.Add("f_3", "�� ����������� ���������� �������� 2 ����");
        ObjectsRusNames.Add("f_4", "�� ����������� ���������� �������� 3 ����");
        ObjectsRusNames.Add("f_5", "�� ����������� ���������� �������� 4 ����");
        ObjectsRusNames.Add("f_6", "�� ����������� ���������� �������� 5 ����");
        ObjectsRusNames.Add("f_7", "�� ����������� ���������� �������� 6 ����");
        ObjectsRusNames.Add("f_8", "�� ����������� ���������� �������� 7 ����");
        ObjectsRusNames.Add("f_9", "�� ����������� ���������� �������� 8 ����");
        ObjectsRusNames.Add("f_10", "�� ����������� ���������� �������� 9 ����");        
        ObjectsRusNames.Add("f_48", "���� ��� �������� ����� ������");
        ObjectsRusNames.Add("f_257", "������� �������� ����� 8");
        ObjectsRusNames.Add("f_256", "������� �������� ����� 6");
        ObjectsRusNames.Add("f_79", "������������� ������� �� ��������� �� ��������");     
        ObjectsRusNames.Add("f_75", "����� �����");
        ObjectsRusNames.Add("f_83", "����� �����");
        ObjectsRusNames.Add("f_77", "����� ����");
        ObjectsRusNames.Add("f_82", "������ �����");
        ObjectsRusNames.Add("f_76", "�� �������������� ����");
        ObjectsRusNames.Add("f_74", "����������� ���� � �����");
        ObjectsRusNames.Add("f_164", "�� ���������� ��������� ������");
        ObjectsRusNames.Add("f_138", "�� ����������� ������");
        ObjectsRusNames.Add("f_139", "���������� ��������� �������  ");
        ObjectsRusNames.Add("f_264", "�� ����������� ������ ");
        ObjectsRusNames.Add("f_120", "�� ����������� ������  ");
        ObjectsRusNames.Add("f_44", "������������ ����� �����������");
        ObjectsRusNames.Add("f_236", "������������ ����� ����������� ");
        ObjectsRusNames.Add("f_66", "������������ ����� �����������  ");
        ObjectsRusNames.Add("f_218", "������������ ����� �����������   ");
        ObjectsRusNames.Add("f_51", "������� ������");
        ObjectsRusNames.Add("f_53", "����������� ����");
        ObjectsRusNames.Add("f_52", "�� ��������� ����");
        ObjectsRusNames.Add("f_96", "��������� �� ����������� ");
        ObjectsRusNames.Add("f_240", "��������� �� �����������  ");
        ObjectsRusNames.Add("f_123", "��������� �� �����������   ");
        ObjectsRusNames.Add("f_140", "��������� �� �����������    ");
        ObjectsRusNames.Add("f_141", "���������� ��������� ��������� ");
        ObjectsRusNames.Add("f_124", "���������� ��������� ���������  ");
        ObjectsRusNames.Add("f_241", "���������� ��������� ���������   ");
        ObjectsRusNames.Add("f_97", "���������� ��������� ���������    ");
        ObjectsRusNames.Add("f_113", "������� �������� ����� 36");
        ObjectsRusNames.Add("f_112", "������� �������� ����� 34");
        ObjectsRusNames.Add("f_133", "������� ��������  ");
        ObjectsRusNames.Add("f_224", "���������� ���������");
        ObjectsRusNames.Add("f_157", "����� ����������� ������� ��");
        ObjectsRusNames.Add("f_158", "�� ���������� �������� - �����");
        ObjectsRusNames.Add("f_163", "����� �������� ��������� ������");
        ObjectsRusNames.Add("f_46", "������� ����� ����� ��� �����");
        ObjectsRusNames.Add("c_secretkeyoff_tn", "�������� �� ��������������");
        ObjectsRusNames.Add("c_handlevertical_tp2", "���������� ��������� ������������ �����");
        ObjectsRusNames.Add("c_specialkey_tr", "�� �������������� ��������");
        ObjectsRusNames.Add("c_3grannyykey_tr", "�� �������������� ����������� ����");





        ObjectsRusNames.Add("Kotel", "�������� ���������");
        ObjectsRusNames.Add("VestibuleWorking", "������� ������");
        ObjectsRusNames.Add("WC", "���������� ����");
        ObjectsRusNames.Add("Koridor", "�������");
        ObjectsRusNames.Add("SmallKoridor", "����� �������");
        ObjectsRusNames.Add("ObliqueKoridor", "����� �������");
        ObjectsRusNames.Add("CoupeSleep", "���� ����������(������)");
        ObjectsRusNames.Add("CoupeOfficial", "���� ����������(���������)");     
        ObjectsRusNames.Add("VestibuleNonWorking", "������ ���������");
        ObjectsRusNames.Add("WagonOutside", "����� �������");
        ObjectsRusNames.Add("None", "��������� �������������:");
        ObjectsRusNames.Add("CoupeNumber9", "���� � 9");
        ObjectsRusNames.Add("CoupeNumber2", "���� � 2");
        ObjectsRusNames.Add("WC2", "���������� ���� �2");
    }
}
