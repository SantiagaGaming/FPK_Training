

using System;

public class DateParser 
{
    private TimeSpan _timeSpan;
    private DateTime _dateTime;
    public DateParser(TimeSpan timeSpan)
    {
        _timeSpan= timeSpan;
    }
    public DateParser(DateTime timeSpan)
    {
        _dateTime = timeSpan;
    }

    public string ParserTime()
    {
        string temp = "";
        string timeString = _timeSpan.ToString();
        for (int i = 0; i < timeString.Length; i++)
        { if (timeString[i] == '.')
                return temp;
            temp+= timeString[i];
        }

        return temp;
       
    }
    public string ParseDate()
    {

        string temp = "";
        string timeString = _dateTime.ToString();
        for (int i = 0; i < timeString.Length; i++)
        {
            if (timeString[i] == ':')
                continue;
            temp += timeString[i];
        }

        return temp;
    }
}
