
namespace TestTask
{
    class Program
    {
        public static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        public static CancellationToken token = cancelTokenSource.Token;
        List<string> words = new List<string>();
        Models models = new Models();
        DbConnect dbConnect = new DbConnect();

        static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.Start();
        }

        private async Task Start()
        {
            Console.WriteLine("Нажмите Enter, что бы начать загрузку, Esc что бы отменить.");
            Console.ReadKey();

            await Task.Run(() =>
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    cancelTokenSource.Cancel();
            });

            ReadFullFile();

            CheckWordsList();
            
            await dbConnect.ConnectToDb();

            foreach (var finWord in models.structs)
            {
                var repl = await dbConnect.FindWord(finWord.Word.ToLower());
                if (string.IsNullOrEmpty(repl))
                {
                    await dbConnect.InsertUpdateData(finWord.Word.ToLower(), finWord.Count, "InsertProcedure");
                }
                else
                {
                    await dbConnect.InsertUpdateData(finWord.Word.ToLower(), finWord.Count + int.Parse(repl), "UpdateProcedure");
                }
                
            }
            await dbConnect.CloseConnectToDb();
        }

        /// <summary>
        /// Проверяет слово на удовлетворение параматерам <3 и >20
        /// </summary>
        /// <param name="word"></param>
        private void CheckWord(string word)
        {
            if (word.Length >= 3 && word.Length <= 20)
            {
                words.Add(word);
            }
        }

        /// <summary>
        /// Читаем весь файл и обрабатываем его
        /// </summary>
        private void ReadFullFile()
        {
            try
            {
                List<string> lines = File.ReadAllLines("Test.txt").ToList();
                foreach (string s in lines)
                {
                    var n = s.Split(' ');
                    if (n.Length > 0)
                    {
                        foreach (string word in n)
                        {
                            CheckWord(word);
                        }
                    }
                    else
                    {
                        CheckWord(n[0]);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Файл не найден");
            }
            
        }

        /// <summary>
        /// Обрабатываем лист со всеми подходящими словами из файла
        /// </summary>
        private void CheckWordsList()
        {
            foreach (string word in words)
            {
                var i = words.FindAll(x => x.ToLower() == word.ToLower());
                if (i.Count > 3)
                {
                    if (models.structs.Count >= 0 && !models.FindItem(word.ToLower(), i.Count))
                    {
                        models.AddItem(word.ToLower(), i.Count);
                    }
                }
            }
        }
    }
}
