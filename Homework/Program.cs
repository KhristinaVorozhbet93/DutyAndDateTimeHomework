using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Задание 1
int limitOfDuty = 200;
int percentOfDuty = 15;
app.MapGet("/customs_duty", GetSummaOfDuty);

string GetSummaOfDuty(double price)
{
    double summaOfDuty = 0.0f;
    if (price > limitOfDuty)
    {
        summaOfDuty = (price - limitOfDuty) / 100 * percentOfDuty;
    }
    return $"Размер пошлины равен: {Math.Floor(summaOfDuty)}";
}

//Задание 2
app.MapGet("/dateTime", GetDateTime);
string GetDateTime(string language)
{
    if (string.IsNullOrEmpty(language)) throw new NullReferenceException(nameof(language));
    if (string.IsNullOrWhiteSpace(language)) throw new ArgumentNullException(nameof(language));

    var culture = new CultureInfo(language);
    var date = DateTime.Now;
    var dayOfWeek = culture.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek);
    var month = culture.DateTimeFormat.GetMonthName(DateTime.Today.Month);
    return $"{date} {dayOfWeek} {month}";
}

app.Run();

