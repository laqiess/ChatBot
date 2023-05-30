/// @autor Ключерев Артемий 

//using System.Windows.Forms;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Chat
{
    // todo: зачем абстрактный класс?
    // наследуется от абстрактного класса
    public class ChatB : AbstractChatBot
    {


        // ссылка на сайт с погодой
        const string URL_WEATHER = "https://api.openweathermap.org/data/2.5/weather?q=Chita,ru&units=metric&appid=ab34896f51377943f5ff794a7f16498d";



        // имя пользователя
        private string username;

        //List<string> hist = new List<string>();
        //string hist;
        public List<string> hist = new List<string>();



        // сетер для имени пользователя
        public void username_set(string user)
        {
            username = user;
        }


        // гетер для имени пользователя
        public string username_get()
        {
            return username;
        }


        public override string answer(string s)
        {
            // перевод всех символов в нижний регистр
            s = s.ToLower();
            // удаление всех пробелов в начале и конце
            s = s.Trim();


            //поиск погоды
            Regex Weather = new Regex(@"погода|градус(ов|ы)|температура");

            MatchCollection matchesJ = Weather.Matches(s);
            // если есть совпадения, написать ответ
            if (matchesJ.Count > 0)
            {
                return this.Weather();                                 
            }

            // todo: @считывает каждый символ отдельно 
            //прив(\w *) обозначает, найти все слова, которые имеют корень "прив"
            Regex hello = new Regex(@"прив(\w*)");
            MatchCollection matchesH = hello.Matches(s);
            // если есть совпадения, написать ответ
            if (matchesH.Count > 0)
            {
                return "Здравствуй";                                  
            }


            //прив(\w *) обозначает, найти все слова, которые имеют корень "пока"
            Regex goodbuy = new Regex(@"пока(\w*)");
            MatchCollection matchesK = goodbuy.Matches(s);
            // если есть совпадения, написать ответ
            if (matchesK.Count > 0)
            {
                return "Прощай";
            }


            //поиск времени
            Regex time = new Regex(@"ча(с|сов)|врем(я|ени)");
            MatchCollection matchesT = time.Matches(s);
            if (matchesT.Count > 0)
            {
                return Time();
            }


            //поиск даты
            Regex date = new Regex(@"дата|число|день");
            MatchCollection matchesD = date.Matches(s);
            if (matchesD.Count > 0)
            {
                return Date();
            }


            //поиск суммы
            Regex Sum = new Regex(@"сложи(\w*)");
            MatchCollection matchesSum = Sum.Matches(s);
            if (matchesSum.Count > 0)
            {
                return Convert.ToString(this.Sum(s));
            }


            //поиск умножения
            Regex Mult = new Regex(@"умножь(\w*)");
            MatchCollection matchesMult = Mult.Matches(s);
            if (matchesMult.Count > 0)
            {
                return Convert.ToString(this.Mult(s));
            }


            //поиск разности
            Regex Diff = new Regex(@"разность(\w*)");
            MatchCollection matchesDiff = Diff.Matches(s);
            if (matchesDiff.Count > 0)
            {
                return Convert.ToString(this.Diff(s));
            }



            //поиск деления
            Regex Division = new Regex(@"^(раз|по)дели");
            MatchCollection matchesDivision = Division.Matches(s);
            if (matchesDivision.Count > 0)
            {
                return Convert.ToString(this.Division(s));
            }


            //в случае если не удалось распознать выражение
            else
            {
                return "запрос не определен,попробуйте снова";
            }
        }


        //вывод погоды
        public string Weather()
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL_WEATHER);
            // возврат ответа от интернет-ресурса
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;
            // считывание ответа в строку
            using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = sr.ReadToEnd();
            }

            // преобразование из формата JSON
            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
            return "Температура в " + weatherResponse.Name + ": " + weatherResponse.Main.Temp + "°C";
        }



        // вывод времени
        public string Time()
        {
            return DateTime.Now.ToString("T");
        }



        // вывод даты
        private string Date()
        {
            return DateTime.Now.ToString("D");
        }


        //сохранение данных с формы чатбота
        public void SaveToHist(string text)
        {
            //this.hist = text;
            hist.Add(text);
        }


        /// гетер для истории
        public List<string> get_hist()
        {
            return hist;
        }


        /// сохранение истории в файл
        public void SaveToFile(string path, List<string> hist)
        {
            // добавление в файл
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                for (int i = 0; i < hist.Count(); i++)
                {
                    writer.WriteLine(hist[i]);
                }

            }
        }

        public void LoadHistory(string path)
        {
            // проверка на существование файла
            // если не существует, то создать
            if (File.Exists(path))
            {
                string s;

                using (StreamReader reader = new StreamReader(path))
                {

                    do
                    {
                        // Прочитать строку из файла
                        s = reader.ReadLine();

                        hist.Add(s); // добавление строки в историю
                    }
                    while (s != null); // проверка, не конец ли файла

                    reader.Close();

                }
            }


        }





        // сумма
        private int Sum(string s)
        {
            // split делит строку на массив; каждое отдельное слово это элемент массива(различает слова благодаря пробелам между ними)
            string[] arr = s.Split();
            int a = int.Parse(arr[1]);
            int b = int.Parse(arr[3]);
            return a + b;
        }

        // умножение
        private int Mult(string s)
        {
            string[] arr = s.Split();
            int a = int.Parse(arr[1]);
            int b = int.Parse(arr[3]);
            return a * b;
        }

        // вычитание
        private int Diff(string s)
        {
            string[] arr = s.Split();
            int a = int.Parse(arr[1]);
            int b = int.Parse(arr[3]);
            return a - b;
        }

        // деление двух параметров
        private float Division(string s)
        {
            string[] arr = s.Split();
            float a = float.Parse(arr[1]);
            float b = float.Parse(arr[3]);
            return a / b;
        }
    }
}
