using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace OOTP13
{
    class MVSLog
    {
        private FileInfo file;
        private FileInfo file2;
        public MVSLog()
        {
            file = new FileInfo("D:\\MVSlogfile.txt");
            file2 = new FileInfo("D:\\test.txt");
        }
        public void Add(string a)
        {
            using (StreamWriter writer = new StreamWriter(file.ToString(), true, System.Text.Encoding.Default))
            {
                writer.WriteLine(DateTime.Now + " - " + a);
            }
        }
        public int Cnv(string a, int o)
        {
            int b, c, m, s;
            c = 3600 * int.Parse(a.Substring(0 + o, 2));
            m = 60 * int.Parse(a.Substring(3 + o, 2));
            s = int.Parse(a.Substring(6 + o, 2));
            b = c + m + s;
            return b;
        }
        public void Read()
        {
            using (StreamReader reader = new StreamReader(file.ToString(), System.Text.Encoding.Default))
            {
                int a = 0;
                while (true)
                {
                    if (reader.EndOfStream)
                    {
                        break;
                    }
                    Console.WriteLine(reader.ReadLine());
                    a++;
                }
                Console.WriteLine("Кол.-во записей в файле: " + a);
            }
        }
        public void DeleteTime()
        {
            using (StreamWriter fs = new StreamWriter(file2.ToString(), false, System.Text.Encoding.Default))
            {
                string pl = DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString() + " " + DateTime.Now.Hour.ToString() + ":";

                string aye = "";
                Console.WriteLine(pl);
                using (StreamReader reader = new StreamReader(file.ToString(), System.Text.Encoding.Default))
                {
                    while (true)
                    {
                        if (reader.EndOfStream)
                        {
                            break;
                        }
                        aye = reader.ReadLine();
                        if (aye.Contains(pl))
                        {
                            fs.WriteLine(aye);
                        }
                    }
                }
            }
            file.Delete();
            file2.MoveTo("D:\\MVSlogfile.txt");
        }
        public void Search()
        {

            Console.WriteLine("Поиск: \n1. Указать дату.\n2. Указать диапазон времени.\n3. Указать ключевое слово.");
            string a, b;
            int r;
            r = int.Parse(Console.ReadLine());
            switch (r)
            {
                case 1:
                    using (StreamReader reader = new StreamReader(file.ToString(), System.Text.Encoding.Default))
                    {
                        Console.WriteLine("Укажите дату в формате 01.01.2001: ");
                        a = Console.ReadLine();
                        while (true)
                        {
                            if (reader.EndOfStream)
                            {
                                break;
                            }
                            if (reader.ReadLine().Contains(a))
                            {
                                Console.WriteLine(reader.ReadLine());
                            }
                        }
                    }
                    break;
                case 2:
                    using (StreamReader reader = new StreamReader(file.ToString(), System.Text.Encoding.Default))
                    {
                        Console.WriteLine("Укажите первую часть времени: ");
                        a = Console.ReadLine();
                        Console.WriteLine("Укажите вторую часть времени: ");
                        b = Console.ReadLine();
                        Cnv(a, 0);
                        Cnv(b, 0);
                        string aye;
                        while (true)
                        {
                            if (reader.EndOfStream)
                            {
                                break;
                            }
                            aye = reader.ReadLine();
                            if (Cnv(aye, 11) >= Cnv(a, 0) && Cnv(aye, 11) <= Cnv(b, 0))
                            {
                                Console.WriteLine(aye);
                            }

                        }
                    }

                    break;
                case 3:
                    using (StreamReader reader = new StreamReader(file.ToString(), System.Text.Encoding.Default))
                    {
                        Console.WriteLine("Введите ключевое слово: ");
                        a = Console.ReadLine();
                        while (true)
                        {
                            if (reader.EndOfStream)
                            {
                                break;
                            }
                            if (reader.ReadLine().Contains(a))
                            {
                                Console.WriteLine(reader.ReadLine());
                            }
                        }
                    }
                    break;
            }

        }

    }
    class DiskInfoMVS:MVSLog
    {
        public void FreePlace()
        {
            Add("Получаем информацию о дисках системы.");
            var allinfo = DriveInfo.GetDrives();
            foreach(var d in allinfo)
            {
                if (!d.IsReady) continue;
                Console.WriteLine("Метка тома: {0}", d.RootDirectory);
                Console.WriteLine("Имя диска: {0}", d.Name);
                Console.WriteLine("Обьём: {0}", d.TotalSize);
                Console.WriteLine("Доступный Обьём: {0}", d.AvailableFreeSpace);
                Console.WriteLine("Свободно места: {0}", d.TotalFreeSpace);
                Console.WriteLine("Файловая система: {0}", d.DriveFormat);
                Console.WriteLine("Свободно места: {0}", d.TotalFreeSpace);

            }
        }
    }
    class MVSFileInfo:MVSLog
    {
        private FileInfo file;
        public MVSFileInfo()
        {
            file = new FileInfo("D:\\MVSlogfile.txt");
        }
        public void fileInfo()
        {
                Add("Выполняем вывод информации о файле " + file.ToString());
                Console.WriteLine($"Полный путь: {file.DirectoryName}");
                Console.WriteLine($"Имя: {file.Name}");
                Console.WriteLine($"Расширение: {file.Extension}");
                Console.WriteLine($"Время создания: {file.CreationTime}");
        }
    }
    class MVSDirInfo:MVSLog
    {
        private string dir = "D:\\Games";
        public void DirInfo()
        {
            if (Directory.Exists(dir))
            {
                Add("Получаем информацию о файлах и директориях в " + dir);
                string[] files = Directory.GetFiles(dir);
                string[] subdir = Directory.GetDirectories(dir);
                int a = 0;
                int b = 0;
                foreach (string s in files)
                {
                    a++;
                }
                foreach (string s in subdir)
                {
                    b++;
                }
                Console.WriteLine("Количество файлов в папке: " + a);
                Console.WriteLine("Время создания папки: " + Directory.GetCreationTime(dir));
                Console.WriteLine("Количетсво поддиректориев в папке: " + b);
                Console.WriteLine("Список родительских директориев: " + Directory.GetParent(dir));
            }
        }
    }
    class MVSFileManager:MVSLog
    {
        private string disk = "D:\\";
        private DirectoryInfo[] directory;
        private FileInfo file;
        private string[] directoryes;
        private string[] files;
        public MVSFileManager()
        {
            Add("Получаем файлы и директории в " + disk);
            directoryes = Directory.GetDirectories(disk);
            files = Directory.GetFiles(disk);
            directory = new DirectoryInfo[2];
            directory[0] = new DirectoryInfo("D:\\MVSInspect");
            directory[1] = new DirectoryInfo("D:\\MVSFiles");
            if (directory[0].Exists)
            {
                Add(directory[0].ToString() + " - существует. Удаляем.");
                directory[0].Delete(true);
            }
            if (directory[1].Exists)
            {
                Add(directory[1].ToString() + " - существует. Удаляем.");
                directory[1].Delete();
            }
            if (File.Exists("D:\\ya.zip"))
            {
                Add("D:\\ya.zip - существует. Удаляем.");
                File.Delete("D:\\ya.zip");
            }
            if (Directory.Exists("D:\\LASTPAPKAFROMARHIV"))
            {
                Add("D:\\LASTPAPKAFROMARHIV - существует. Удаляем.");
                Directory.Delete("D:\\LASTPAPKAFROMARHIV", true);
            }
        }
        public void Worker()
        {
            directory[0].Create();
            directory[1].Create();
            file = new FileInfo("D:\\MVSInspect\\MVSdirinfo.txt");
            Add("Создаем файл" + file.ToString());
            Add("Записываем информацию о файлах и папках в " + file.ToString());
            using (StreamWriter fs = new StreamWriter(file.ToString(), true, System.Text.Encoding.Default))
            {
                foreach (string s in files)
                {
                    fs.WriteLine(s);
                }
                foreach (string s in directoryes)
                {
                    fs.WriteLine(s);
                }
                Console.WriteLine("Текст записан в файл.");
            }
            File.Delete("D:\\MVSInspect\\bong.txt");
            Add("Перемещаем файл " + file.ToString() + " в " + "D:\\MVSInspect\\bong.txt");
            file.CopyTo("D:\\MVSInspect\\bong.txt");
            file.Delete();
            DirectoryInfo dir = new DirectoryInfo("D:\\good");
            Add("Получаем информацию о jpg файлах в D:\\good");
            FileInfo[] f = dir.GetFiles("*.jpg");
            Add("Копируем файлы jpg из D:\\good в D:\\MVSInspect\\");
            foreach (FileInfo s in f)
            {
               s.CopyTo("D:\\MVSFiles\\"+s.Name,true);
            }
            Add("Перемещаем " + directory[1].ToString() + " в " + directory[0].ToString());
            directory[1].MoveTo("D:\\MVSInspect\\MVSFiles");
            ZipFile.CreateFromDirectory(directory[1].ToString(), "D:\\ya.zip");
            Add("Разархивируем D:\\ya.zip в D:\\");
            ZipFile.ExtractToDirectory("D:\\ya.zip", "D:\\");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DiskInfoMVS second = new DiskInfoMVS();
            second.FreePlace();
            Console.WriteLine();
            MVSFileInfo third = new MVSFileInfo();
            third.fileInfo();
            Console.WriteLine();
            MVSDirInfo fourth = new MVSDirInfo();
            fourth.DirInfo();
            Console.WriteLine();
            MVSFileManager fileManager = new MVSFileManager();
            fileManager.Worker();
            //Console.WriteLine(DateTime.Now);
            //MVSLog log = new MVSLog();
            //log.Read();
            //Console.WriteLine(DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
            //log.Search();
            //log.DeleteTime();
        }
    }
}
