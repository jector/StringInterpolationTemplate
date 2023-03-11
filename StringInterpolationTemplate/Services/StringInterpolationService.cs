using System;
using Microsoft.Extensions.Logging;
using StringInterpolationTemplate.Utils;

namespace StringInterpolationTemplate.Services;

public class StringInterpolationService : IStringInterpolationService
{
    private readonly ISystemDate _date;
    private readonly ILogger<IStringInterpolationService> _logger;

    public StringInterpolationService(ISystemDate date, ILogger<IStringInterpolationService> logger)
    {
        _date = date;
        _logger = logger;
        _logger.Log(LogLevel.Information, "Executing the StringInterpolationService");
    }

    //1. January 22, 2019 (right aligned in a 40 character field)
    public string Number01()
    {
        var date = _date.Now.ToString("MMMM dd, yyyy");
        var answer = $"{date,40}";
        return answer;
    }

    public string Number02()
    {
        var today = _date.Now;
        return $"{today:yyyy.MM.dd}";
    }

    public string Number03()
    {
        var today = _date.Now;
        return $"{today:'Day' dd 'of' MMMM, yyyy}";
    }
//"Year: 2019, Month: 01, Day: 22"
    public string Number04()
    {
        var today = _date.Now;
        return $"{today:'Year:' yyyy, 'Month:' MM, 'Day:' dd}";
    }
//"   Tuesday"
    public string Number05()
    {
        var date = _date.Now.ToString("dddd");
        var answer = $"{date,10}";
        return answer;
    }
//"  11:01 PM   Tuesday"
    public string Number06()
    {
        var date = _date.Now.ToString("dddd");
        var time = _date.Now.ToString("t");
        var answer = $"{time,10}{date,10}";
        return answer;
    }
//"h:11, m:01, s:27"
    public string Number07()
    {
        var today = _date.Now;
        return $"{today:'h:'hh, 'm:'mm, 's:'ss}";
    }
//"2019.01.22.11.01.27"
    public string Number08()
    {
        var today = _date.Now;
        return $"{today:yyyy.MM.dd.hh.mm.ss}";
    }
//"$3.14"
    public string Number09()
    {
        var pi = Math.PI;
        var answer = $"{pi:C}";
        return answer;
    }
//"     3.142"
    public string Number10()
    {
        var pi = Math.PI;
        var answer = $"{pi,10:F3}";
        return answer;
    }
//"7E7"
    public string Number11()
    {
        var date = DateTime.Now.ToString("yyyy");
        var numberyear = Convert.ToInt16(date);
        var answer = $"{numberyear:X}";
        return answer;
    }
}
