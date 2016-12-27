using System; //Объявление using System дает возможность ссылаться на классы, которые находятся в пространстве имен System, так что их можно использовать, не добавляя System. перед именем типа.
using System.ComponentModel;
using System.Diagnostics;//System.Diagnostics Пространство имен предоставляет классы, позволяющие взаимодействовать с системными процессами, журналами событий и счетчики производительности.
using System.IO;//Пространство имен System.IO содержит типы, позволяющие осуществлять чтение и запись в файлы и потоки данных, а также типы для базовой поддержки файлов и папок.
using System.Windows.Forms;//System.Windows.Forms Пространство имен содержит классы для создания приложений Windows, пользующихся преимуществами полного пользовательского интерфейса, предоставляемых в операционной системе Microsoft Windows.
using Ncc.Helper;
using Excel = Microsoft.Office.Interop.Excel;

namespace LightStroreFileConverter //Ключевое слово namespace используется для объявления область, которая содержит набор связанных объектов. Можно использовать пространство имен для организации элементов кода, а затем создать глобальную уникальность типы.
{
    public partial class Form1 : Form //partial - говорит о том, что код класса находится в нескольких файлах, т.е. часть непосредственно в указанном вами примере, а часть непосредственно в файле дизайнера этой же формы.Form1 : Form - это говорит о том, что класс Form1 наследуется от класса Form.
    {
        public delegate void LongActionDelegate();//Ключевое слово delegate используется для объявления ссылочного типа, который может быть использован для инкапсуляции именованного или анонимного метода. Делегаты аналогичны используемым в языке C++ указателям на функции, но являются типобезопасными и безопасными. 

        readonly NamingHelper _helper = new NamingHelper();//Ключевое слово readonly — это модификатор, который можно использовать для полей. Если объявление поля содержит модификатор readonly, присвоение значений таким полям может происходить только как часть объявления или в конструкторе в том же классе.

        private InputFolderInfo _currentFolderInfo = new InputFolderInfo();///

        public string OutPutFolderPath { get; set; } ///

        public bool OutPutFolderExist { get; set; }///

        public Form1()//
        {
            InitializeComponent(); ///  
            _helper.ReadDictionary(); ///
            _currentFolderInfo.TotalItemsCountChanged += InfoChangedHandler;//

            OutPutFolderPath = @"C:\Output\";///

            OutPutFolderExist = false;///

            PrepareOutPutFolder();///
        }

        private void PrepareOutPutFolder()///
        {
            richTextBox1.WriteLine(string.Format("Проверка выходной директории: {0}", OutPutFolderPath));///
            var exist = Directory.Exists(OutPutFolderPath);///

            if (exist)///
            {
                richTextBox1.WriteLine("Выходная директория присутствует...");///
                OutPutFolderExist = true;///
            }
            else
            {
                richTextBox1.WriteLine("Выходная директория отсутствует... Попытка создания");

                try
                {
                    Directory.CreateDirectory(OutPutFolderPath);
                    OutPutFolderExist = true;
                    richTextBox1.WriteLine(string.Format("Выходная директория: {0} успешно создана", OutPutFolderPath));
                }
                catch (Exception)
                {
                    richTextBox1.WriteLine("Ошибка создания выходной директории...");
                    richTextBox1.WriteLine("Основная функциональность недоступна...");
                    OutPutFolderExist = false;
                }
            }
        }

        private void InfoChangedHandler(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            bttnTransform.Enabled = false;
            if (_currentFolderInfo.TotalItemsCount > 0)
            {
           //     checkBox1.Enabled = true;
                bttnTransform.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxFolderPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void LongOperationWraper(LongActionDelegate dl)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            dl();

            stopwatch.Stop();
            richTextBox1.WriteLine(string.Format("Время выполнения операции: {0}", stopwatch.Elapsed));
        }

        private void ProcessDocuments()
        {
            ProcessDocuments(false);
        }

        private void ProcessDocuments(bool reportProgress)
        {
            if (string.IsNullOrEmpty(textBoxFolderPath.Text))
            {
                return;
            }

            var dirs = Directory.GetFiles(textBoxFolderPath.Text);
            foreach (var dir in dirs)
            {
                if (dir.Contains("~$"))
                {
                    continue;
                }
                richTextBox1.WriteLine(dir);

                var saveName = NewNameFromPath(dir);

                var savePath = String.Format("{0}{1}", Outputpath(), saveName);

                var excelApp = new Excel.Application();
                excelApp.Workbooks.Open(dir);
                //TODO: обрабоать ситуации нестабильной работы с некоторыми файлами вида ""C:\\Users\\Victor\\Desktop\\Товары\\~$Книга1.xlsx""
                //~$Книга1.xlsx" - похоже на временный невидимый файл
                // будем пропустать все что содержит ~$

                excelApp.ActiveWorkbook.SaveAs(savePath, Excel.XlFileFormat.xlOpenXMLWorkbook);

                excelApp.Workbooks.Close();
                excelApp.Quit();
            }
        }

        public void ProcessDocumentsWarper()
        {
            LongOperationWraper(() => ProcessDocuments());
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            // ProcessDocumentsWarper();

            backgroundWorker1.RunWorkerAsync();
        }
    
        public string NewNameFromPath(string path)// Я не знаю что он делает  - а почитать что внутри? в поезде зарядки небыло? или этого небыло в поставах?
        {
            var f = new FileInfo(path);
            return _helper.GetNameFromDictionary(f.Name);
        }

        /// <summary>
        /// Выходная директория  
        /// Output
        /// path
        /// </summary>
        /// <returns>Возвращает путь выходной директории</returns>
        public string Outputpath()
        {
            return OutPutFolderPath;
        }

        private void bttnAnalyzeFolder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFolderPath.Text))
            {
                MessageBox.Show("Для старта анализа сначала выбирите папку");
                return;
            }

            var exist = Directory.Exists(textBoxFolderPath.Text);

            if (!exist)
            {
                MessageBox.Show("Данная попка не найдена или не существует, проверте путь, или выбирите другую папку");
                return;
            }

            AnalyzeFolder(textBoxFolderPath.Text);
        }

        private void AnalyzeFolder(string pathToFolder)
        {
            _currentFolderInfo = _helper.AnalyzeFolder(pathToFolder);

            richTextBox1.WriteLine(string.Format("Результаты анализа папки: {0}", pathToFolder) );
            richTextBox1.WriteLine(_currentFolderInfo.ToString());

            if (_currentFolderInfo.TotalItemsCount > 0)
            {
                InfoChangedHandler(this, EventArgs.Empty);
            }

            backgroundWorker1.ReportProgress(0);
        }

        private void textBoxFolderPath_TextChanged(object sender, EventArgs e)
        {
            bttnAnalyzeFolder.Enabled = !string.IsNullOrEmpty(textBoxFolderPath.Text);
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            LongOperationWraper(() =>
            {
                backgroundWorker1.ReportProgress(0);
                if (string.IsNullOrEmpty(textBoxFolderPath.Text))
                {
                    return;
                }

                var h = _currentFolderInfo.TotalItemsCount;

                float d =  100f / h;

                var curent = 0;
    
                string[] dirs = Directory.GetFiles(textBoxFolderPath.Text);
                foreach (string dir in dirs)
                {
                    if (dir.Contains("~$"))
                    {
                        continue;
                    }
                    richTextBox1.WriteLine(dir);

                    var saveName = NewNameFromPath(dir);

                    var savePath = string.Format("{0}{1}", Outputpath(), saveName);

                    var excelApp = new Excel.Application();
                    excelApp.Workbooks.Open(dir);

                    excelApp.ActiveWorkbook.SaveAs(savePath, Excel.XlFileFormat.xlOpenXMLWorkbook);

                    excelApp.Workbooks.Close();
                    excelApp.Quit();

                    curent++;
                    backgroundWorker1.ReportProgress((int) (curent * d));

                    if (curent >= h)
                    {
                        backgroundWorker1.ReportProgress(100);
                    }
                }
            });
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            // Start the BackgroundWorker.
            //  backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_ProgressChanged(object sender,ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            progressBar1.Value = e.ProgressPercentage;
            // Set the text.
           // this.Text = e.ProgressPercentage.ToString();
        }
    }

  
}
