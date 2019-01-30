using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ConsoleApplication2{
    class Program{
        public static List<double> NoteList;
        public static List<double> Multipliers;
        public static List<string> NoteNameList;
        public static List<double> DurationList;
        public static List<string> DurationNameList;

        public static string[] FMenu;
        public static string[] Note;

        public static int Frequency;
        public static int Returned;

        public static string FrString;
        public static string DuString;

        public static int ToneMIX;
        public static double BeatLength;

        public static double Fr;
        public static int Du;
        public static double BPM;

        public static int ToneNum;
        public static int TempNum;

        public static string Values;

        public static List<double> T;
        public static int[] StartNotes = { 277, 500, 311, 500, 349, 500, 185, 500, 415, 500, 466, 500 };

        public static bool FWrite = false;

        public static bool FrequencyHasBeenChanged = false;
        public static bool DurationHasBeenChanged = false;

        [STAThreadAttribute]
        static void Main(){
            Console.Title = "ToneMatricks 2.1.0";
            INIT();
            Du = 500;
            Fr = 500;
            Intro();
        }
        public static void ToneSelect (){
            while (true){
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Which tone would you like to change? 1 to " + ToneNum / 2 + ".");
                    Frequency = Convert.ToInt32(Console.ReadLine());
                    if (Frequency > ToneNum / 2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Tone number is too high! Does not exist.");
                    }
                    else if (Frequency < 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Tone number is less than 1. Does not exist.");
                    }
                    else if (Frequency > 0 && Frequency < ToneNum / 2)
                    {
                        break;
                    }
                } catch (FormatException)
                {
                    
                }
            }
            ToneMIX = Frequency;
            Console.WriteLine();
            Console.WriteLine("Is " + ToneMIX + " correct? Y/N");
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                ConsoleKeyInfo d = Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
                if (d.Key == ConsoleKey.Y)
                {
                    Console.WriteLine();
                    Console.WriteLine("Note(N) or Duration(D)?");
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        ConsoleKeyInfo e = Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.White;
                        if (e.Key == ConsoleKey.N)
                        {
                            FrequencySelection();
                        }
                        else if (e.Key == ConsoleKey.D)
                        {
                            DurationSelection();
                        }
                    }
                }
            }
        }
        public static void MainLoop(){
            while (true){
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("# Hz  Ms Note-Octave Duration");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
				for (int a = 0; a < ToneNum; a += 2) {
                    Console.WriteLine((a / 2 + 1) + "|" + T[a] + "|" + (int)T[a+1] + "|" + Notes(T[a]) + "|" + Duration(T[a + 1]));
                    Console.Beep((int)T[a], (int)T[a + 1]);
				}
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("End of list. What to do next?");
                    Console.WriteLine();
                Console.WriteLine();
                    Returned = InteractMenu(4, 0, FMenu);
                    if (Returned == 0)
                    {
                        ToneSelect();
                    }
                    else if (Returned == 1)
                    {
                        FileWrite();
                    }
                    else if (Returned == 2)
                    {
                        FileRead();
                    }
                    else if (Returned == 3)
                    {
                        MainLoop();
                    }
                    else
                    {}
            }
        }
        public static void FrequencySelection() {
            while (true) {
                Console.WriteLine();
                while (true)
                {
                    while (true)
                    {
                        try
                        {
                            Console.Write("Enter a new frequency ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("(37 to 32767 Hz) ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("or a Note with Octive up to ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("9 (ex. A-9)");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            FrString = Console.ReadLine();
                            if (FrString.Contains("-") || FrString.Contains("_") || FrString.Contains("/") || FrString.Contains(",") || FrString.Contains("."))
                            {
                                Fr = NoteReversed(FrString);
                                break;
                            }
                            else
                            {
                                Fr = Convert.ToInt32(FrString);
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please use the format specified above.");
                        }
                    }
                    if (Fr > 32767) {
                        Console.WriteLine("Too high!");
                    }
                    else if (Fr < 37) {
                        Console.WriteLine("Too Low!");
                    }
                    break;
                }
                Console.WriteLine();
                Console.WriteLine(Fr);
                Console.Beep((int)Fr, Du);
                Console.WriteLine("This ok? Y/N");
                Console.ForegroundColor = ConsoleColor.Black;
                ConsoleKeyInfo f = Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
                if (f.Key == ConsoleKey.Y){
                    FrequencyHasBeenChanged = true;
                    ToneChange(Fr,500);
                    while (true)
                    {
                        if (!DurationHasBeenChanged)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Would you like to change the duration? Y/N");
                            Console.ForegroundColor = ConsoleColor.Black;
                            ConsoleKeyInfo g = Console.ReadKey();
                            Console.ForegroundColor = ConsoleColor.White;
                            if (g.Key == ConsoleKey.Y)
                            {
                                DurationHasBeenChanged = false;
                                DurationSelection();
                            }
                            else if (g.Key == ConsoleKey.N)
                            {
                                MainLoop();
                            }
                        }
                        FrequencyHasBeenChanged = false;
                        DurationHasBeenChanged = false;
                        MainLoop();
                    }
                }
                else if (f.Key == ConsoleKey.N){ }
            }
        }
        public static void DurationSelection()
        {
            while (true)
            {
                Console.WriteLine();
                while (true)
                {
                        Console.Write("Enter a new duration ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("(50 to 50000000 ms) ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("or a note type ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("(ex. 'Quarter')");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                    try
                    {
                        DuString = Console.ReadLine();
                        if (DurationNameList.Contains(DuString))
                        {
                            Du = (int)DurationReversed(DuString);
                            break;
                        }
                        else
                        {
                            Du = Convert.ToInt32(DuString);
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please use the format specified above.");
                    }
                }
                if (Du > 50000000)
                {
                    Console.WriteLine("Too high!");
                }
                else if (Du < 50)
                {
                    Console.WriteLine("Too Low!");
                }
                Console.WriteLine();
                Console.WriteLine(Du);
                Console.Beep((int)Fr, Du);
                Console.WriteLine("This ok? Y/N");
                Console.ForegroundColor = ConsoleColor.Black;
                ConsoleKeyInfo f = Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
                if (f.Key == ConsoleKey.Y)
                {
                    DurationHasBeenChanged = true;
                    ToneChange(440,Du);
                    while (true)
                    {
                        if (!FrequencyHasBeenChanged)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Would you like to change the frequency? Y/N");
                            Console.ForegroundColor = ConsoleColor.Black;
                            ConsoleKeyInfo h = Console.ReadKey();
                            Console.ForegroundColor = ConsoleColor.White;
                            if (h.Key == ConsoleKey.Y)
                            {
                                FrequencyHasBeenChanged = false;
                                FrequencySelection();
                            }
                            else if (h.Key == ConsoleKey.N)
                            {
                                MainLoop();
                            }
                        }
                        FrequencyHasBeenChanged = false;
                        DurationHasBeenChanged = false;
                        MainLoop();
                    }
                }
                else if (f.Key == ConsoleKey.N)
                { }
            }
        }
        public static void ToneChange(double Frequency, double Duration)
        {
            if (DurationHasBeenChanged == true)
            {
                T[ToneMIX * 2 - 1] = Duration;
            }
            else if (FrequencyHasBeenChanged == true)
            {
                T[ToneMIX * 2 - 2] = Frequency;
            }
        }
        public static void FileWrite()
        {
            string fileName;
            Console.WriteLine();
            Console.WriteLine("This can take a while...");
            SaveFileDialog fd = new SaveFileDialog();
            fd.ShowDialog();
            fileName = fd.FileName;
/*            if (File.Exists(fileName))
            {*/
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.WriteLine("TM2.0");
                    sw.WriteLine("//Max pitch of 32766 and Min of 37");
                    sw.WriteLine(ToneNum);
                    for (int i = 0; i < ToneNum; i += 2)
                    {
                        sw.WriteLine(T[i] + "-" + (T[i + 1]) + "-");
                    }
                }
                FWrite = true;
                Console.WriteLine();
                Console.WriteLine("Done! To re-open, press O on the tone list.");
                Thread.Sleep(500);
            /*}
            else
            {
                Console.WriteLine();
                Console.WriteLine("Error");
            }*/
        }
        public static void FileRead()
        {
            string fileName;
            Console.WriteLine();
            Console.WriteLine("This can take a while...");
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            fileName = fd.FileName;
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    if (sr.ReadLine() == "TM2.0")
                    {
                        sr.ReadLine();
                        char[] delimiterChars = { '-' };
                        TempNum = Convert.ToInt32(sr.ReadLine());
                        Console.WriteLine();
                        if (TempNum > ToneNum)
                        {
                            Console.WriteLine("Do you want to clip the saved file duration to match current tone number? Y/N");
                            Console.ForegroundColor = ConsoleColor.Black;
                            ConsoleKeyInfo i = Console.ReadKey();
                            Console.ForegroundColor = ConsoleColor.White;
                            if (i.Key == ConsoleKey.Y)
                            {
                                TempNum = ToneNum;
                            }
                            else if (i.Key == ConsoleKey.N)
                            {
                                ToneNum = TempNum;
                                T.Capacity = ToneNum;
                                for (int t = T.Count; t < ToneNum; t++)
                                {
                                    T.Add(500);
                                }
                            }
                        }
                        T.Capacity = ToneNum;
                        List<string> S = new List<string>(ToneNum);
                        string[] WT = new string[19998];
                        for (int s = 0; s < ToneNum; s += 2)
                        {
                            Values = Values + sr.ReadLine();
                        }
                        if (TempNum < ToneNum)
                        {
                            Console.WriteLine("Clip the tone number to match the saved file length? " + ToneNum / 2 + " to " + TempNum / 2 + " | Y/N");
                            Console.ForegroundColor = ConsoleColor.Black;
                            ConsoleKeyInfo h = Console.ReadKey();
                            Console.ForegroundColor = ConsoleColor.White;
                            if (h.Key == ConsoleKey.Y)
                            {
                                ToneNum = TempNum;
                            }
                            else if (h.Key == ConsoleKey.N)
                            {
                                for (int i = TempNum; i < ToneNum; i += 2)
                                {
                                    Values = Values + "440-" + BeatLength;
                                }
                                TempNum = ToneNum;
                            }

                        }
                        WT = Values.Split(delimiterChars);
                        for (int i = 0; i < ToneNum; i++)
                        {
                            T[i] = Convert.ToDouble(WT[i]);
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Done! The file was loaded!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No file exists. Please save first!");
            }
        }
        public static void Intro()
        {
            if (!Console.KeyAvailable)
            {
                Console.CursorVisible = false;
                for (int a = 0; a < 12; a += 2)
                {
                    Console.WriteLine(((a / 2) + 1) + " " + StartNotes[a] + " " + "500");
                    Console.Beep(StartNotes[a], 500);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("ToneMatricks");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2500);
                Console.Clear();
                Console.CursorVisible = true;
                BPMSet();
            }
            else
            {
                Console.WriteLine("'Hi!' -A message from the creator");
                Console.WriteLine();
                Console.WriteLine("This is a one man project that started in July 2016 in the hopes of one day being a free, full-featured DAW. That will take some time.");
                Console.ReadLine();
                BPMSet();
            }
        }
        public static void ToneNumSel()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.Write("How many tones would you like in the pattern? ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("1 - 9999");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    ToneNum = (Convert.ToInt32(Console.ReadLine()) * 2);
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Not a number. Try again!");
                    Console.WriteLine();
                }
                if (ToneNum / 2 < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("MUST be at least 1");
                    }
                    else if (ToneNum / 2 > 9999)
                    {
                        Console.Clear();
                        Console.WriteLine("Limit is 9999 Tones");
                    }
                    else if (ToneNum / 2 > 0 && ToneNum / 2 < 9999)
                    {
                        break;
                    }
                }
            T = new List<double>(ToneNum + 1);
            for (int i = 0; i < ToneNum / 2; i++)
            {
                T.Add(440);
                T.Add(BeatLength);
            }
            MainLoop();
        }
        public static void INIT()
        {
            NoteList = new List<double>(17) {55.000, 58.27, 58.27, 61.74, 65.406, 69.296, 69.308, 73.416, 77.782, 77.782, 82.407, 87.307, 92.499, 92.499, 97.999, 103.83 };
            NoteNameList = new List<string>(17) { "A", "A#", "Bb", "B", "C", "C#", "Db", "D", "D#", "Eb", "E", "F", "F#", "Gb", "G", "G#", "Ab" };
            Multipliers = new List<double>(10) { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };
            FMenu = new string[] { "Change Tone", "Save File", "Open File", "Replay Sequence" };
            return;
        }
        public static string Notes(double Note)
        {
            for (int a = 0; a < 10; a++)
            {
                double FVC = Note / Multipliers[a] * 2;
                if (NoteList.Contains(FVC))
                {
                    return (NoteNameList[NoteList.IndexOf(FVC)] + "-" + a);
                }
            }
            return "null";
        }
        public static double NoteReversed(string NoteName)
        {
            char[] delimiterChars = { '-', '.', ',', '_', '/' };
            Note = NoteName.Split(delimiterChars);
            if (NoteNameList.Contains(Note[0]))
            {
                return ((NoteList[NoteNameList.IndexOf(Note[0])] * Multipliers[Convert.ToInt32(Note[1])] / 2));
            }
            else
            {
                return 440;
            }
        }
        public static string Duration(double Duration)
        {
            if (DurationList.Contains(Duration))
            {
                return (DurationNameList[DurationList.IndexOf(Duration)]);
            }
            return "null";
        }
        public static double DurationReversed(string Duration)
        {
            if (DurationNameList.Contains(Duration))
            {
                return (DurationList[DurationNameList.IndexOf(Duration)]);
            }
            return 240;
        }
        public static void BPMSet()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.Write("What is the BPM? (Beats per Minute) ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Max 500");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    BPM = (Convert.ToInt32(Console.ReadLine()));
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Not a number. Try again!");
                    Console.WriteLine();
                }
                if (BPM < 10)
                {
                    Console.Clear();
                    Console.WriteLine("MUST be at least 10");
                }
                else if (BPM > 500)
                {
                    Console.Clear();
                    Console.WriteLine("Limit is 500 BPM");
                }
                else
                {
                    Console.Clear();
                    break;
                }
            }
            BeatLength = 1000 / ((BPM * 1000) / (60 * 1000));
            DurationList = new List<double>(11) { BeatLength * 4, BeatLength * 3, BeatLength * 2, BeatLength * 1.5, BeatLength, BeatLength / 2, BeatLength / 4, BeatLength / 8, BeatLength / 16, BeatLength / 32, BeatLength / 64 };
            DurationNameList = new List<string>(11) { "Whole", "Dotted Half", "Half", "Dotted Quarter", "Quarter", "Eighth", "Sixteenth", "Thirty-Secondth", "Sixty-Forth", "One-Twenty-Eighth", "Two-Fifty-Sixth" };
            ToneNumSel();
        }
        public static int InteractMenu(int OptionNum, int Select, string[] Options)
        {
            bool done = false;
            while (!done)
            {
                for (int i = 0; i < OptionNum; i++)
                {
                    if (Select == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("> ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    Console.WriteLine(Options[i]);
                    Console.ResetColor();
                }
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        Select = Math.Max(0, Select - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        Select = Math.Min(OptionNum - 1, Select + 1);
                        break;
                    case ConsoleKey.Enter:
                        done = true;
                        break;
                }
                if (!done)
                {
                    Console.CursorTop = Console.CursorTop - OptionNum;
                }
            }
            return Select;
        }
    }
}