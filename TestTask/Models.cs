using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class Models
    {
        public class Struct
        {
            public string? Word { get; set; }
            public int Count { get; set; }
        }

        public List<Struct> structs = new List<Struct>();

        /// <summary>
        /// Метод добавления слов в список
        /// </summary>
        /// <param name="w">Слово</param>
        /// <param name="c">Количество</param>
        public void AddItem(string w, int c)
        {
            Struct s = new Struct();
            s.Word = w;
            s.Count = c;
            structs.Add(s);
        }

        /// <summary>
        /// Метод поиска повторений слов в списке
        /// </summary>
        /// <param name="w">Слово</param>
        /// <param name="c">Количество</param>
        /// <returns>true - Если слово есть в листе и повторно указывать его не надо</returns>
        public bool FindItem(string w, int c)
        {
            Struct s = new Struct();
            s.Word = w;
            s.Count = c;
            return true ? structs.Find(x => x.Word == w) != null : false;
        }
    }
}
