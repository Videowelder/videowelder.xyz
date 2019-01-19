using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ConsoleApplication2
{
    class Program
    {
        public static List<Double> NoteList;
        public static List<string> Octave;
        public static List<string> NoteNameList;
        public static List<int> DurationList;
        public static List<int> NewDurationList;
        public static List<string> DurationNameList;
        public static List<string> PRESES;

        public static string[] FMenu;
        public static string[] TMenu;
        public static string[] OMenu;
        public static string[] DMenu;
        public static string[] Note;

        protected static int origRow;
        protected static int origCol;

        public static int Frequency;
        public static int Returned;
        public static Double TempLength;
        public static int TempBPM;

        public static string FrString;
        public static string DuString;

        public static int ToneMIX;
        public static Double BeatLength;

        public static Double Fr;
        public static int Oc;
        public static int Du;
        public static Double BPM;

        public static int ToneNum;
        public static int TempNum;

        public static string Values;

        public static List<Double> T;
        public static int[] StartNotes = { 277, 500, 311, 500, 349, 500, 185, 500, 415, 500, 466, 500 };

        public static bool FWrite = false;

        public static bool FrequencyHasBeenChanged = false;
        public static bool DurationHasBeenChanged = false;
        public static bool Loop = false;

        [STAThreadAttribute]
        static void Main(string[] args)
        {
            Console.Title = "ToneMatricks 2.1.0";
            INIT();
            Du = 500;
            Fr = 500;
            PRESES = new List<string>();
            if (args.Length != 0)
            {
                if (args[0].Length > 0)
                {
                    Console.WriteLine(args[0]);
                    Console.ReadLine();
                    FileRead(args[0]);
                }
            }
            Intro();
            BPMSet();
            ToneNumSel();
        }
        public static void ToneSelect()
        {
            List<string> stuff = T.ConvertAll(new Converter<double, string>(IntToString));
            for (int i = stuff.Count-1; i > 0; i-=2)
            {
                stuff.RemoveAt(i);
            }
            string[] stuff2 = stuff.ToArray();
            ToneMIX = InteractMenu(ToneNum / 2, 0, stuff2, "Sel", "Which tone to change?");
            while (true)
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
                    else if (e.Key == ConsoleKey.Escape)
                    {
                        MainLoop();
                    }
                }
            }
        }
        public static void MainLoop()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Tone #\tHertz\tMs\tNote\tDuration");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                while (!Console.KeyAvailable)
                {
                    for (int a = 0; a < ToneNum; a += 2)
                    {
                        Console.WriteLine((a / 2 + 1) + "\t" + (int)T[a] + "\t" + (int)T[a + 1] + "\t" + Notes(T[a]) + "\t" + Duration((int)T[a + 1]));
                        Console.Beep((int)T[a], (int)T[a + 1]);
                    }
                    if (Loop)
                    {
                        Console.Clear();
                    }
                    else
                    {
                        break;
                    }
                    
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Returned = InteractMenu(5, 0, FMenu, "Sel", "End of list. What to do next?");
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
                    FileRead(null);
                }
                else if (Returned == 3)
                {
                    MainLoop();
                }
                else if (Returned == 4)
                {
                    Loop = true;
                }
                else
                { }
            }
        }
        public static void FrequencySelection()
        {
            while (true)
            {
                Console.WriteLine();
                while (true)
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        TMenu = NoteNameList.ToArray();
                        OMenu = Octave.ToArray();
                        Fr = NoteList[InteractMenu(17, 0, TMenu, "Freq", "Select a note from the menu")];
                        Console.WriteLine();
                        Oc = InteractMenu(7, 0, OMenu, "Oct", "Octave?") + 1;
                        Fr = Convert.ToDouble(Fr * (Math.Pow(2, Convert.ToDouble(Octave[Oc])) / 2));
                        break;
                    }
                    Console.WriteLine();
                    Console.WriteLine(Fr.ToString());
                    Console.Beep((int)Fr, Du);
                    Console.WriteLine("This ok? Y/N");
                    Console.ForegroundColor = ConsoleColor.Black;
                    ConsoleKeyInfo f = Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.White;
                    if (f.Key == ConsoleKey.Y)
                    {
                        FrequencyHasBeenChanged = true;
                        ToneChange(Fr, 500);
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
                                else if (g.Key == ConsoleKey.Escape)
                                {
                                    MainLoop();
                                }
                            }
                            FrequencyHasBeenChanged = false;
                            DurationHasBeenChanged = false;
                            MainLoop();
                        }
                    }
                    else if (f.Key == ConsoleKey.N) { }
                    else if (f.Key == ConsoleKey.Escape)
                    {
                        MainLoop();
                    }
                }
            }
        }
        public static void DurationSelection()
        {
            while (true)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                DMenu = DurationNameList.ToArray();
                Du = Convert.ToInt32(DurationList[InteractMenu(11, 4, DMenu, "Dur", "Select a note type from the menu")]);
                Console.WriteLine();
                Console.WriteLine(Du.ToString());
                Console.Beep((int)Fr, Du);
                Console.WriteLine("This ok? Y/N");
                Console.ForegroundColor = ConsoleColor.Black;
                ConsoleKeyInfo f = Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
                if (f.Key == ConsoleKey.Y)
                {
                    DurationHasBeenChanged = true;
                    ToneChange(440, Du);
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
                            else if (h.Key == ConsoleKey.Escape)
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
                else if (f.Key == ConsoleKey.Escape)
                {
                    MainLoop();
                }
            }
        }
        public static void ToneChange(Double Frequency, Double Duration)
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
            fd.Filter = "Text files|*.txt";
            fd.ShowDialog();
            fileName = fd.FileName;
            if (File.Exists(fileName))
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.WriteLine("TM2.1");
                    sw.WriteLine("//Max pitch of 32766 and Min of 37");
                    sw.WriteLine(ToneNum);
                    sw.WriteLine(BeatLength);
                    sw.WriteLine(BPM);
                    for (int i = 0; i < ToneNum; i += 2)
                    {
                        sw.WriteLine(T[i] + "-" + (T[i + 1]) + "-");
                    }
                }
                FWrite = true;
                Console.WriteLine();
                Console.WriteLine("Done! To re-open, press O on the tone list.");
                Thread.Sleep(500);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Error");
            }
        }
        public static void FileRead(string filename)
        {
            string fileName;
            fileName = "0";
            if (filename == null)
            {
                Console.WriteLine();
                Console.WriteLine("This can take a while...");
                OpenFileDialog fd = new OpenFileDialog();
                fd.Filter = "Text files|*.txt";
                fd.ShowDialog();
                fileName = fd.FileName;
            }
            else { fileName = filename; }
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    if (sr.ReadLine() == "TM2.1")
                    {
                        sr.ReadLine();
                        char[] delimiterChars = { '-' };
                        TempNum = Convert.ToInt32(sr.ReadLine());
                        TempLength = Convert.ToDouble(sr.ReadLine());
                        TempBPM = Convert.ToInt32(sr.ReadLine());
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
                        List<int> DUpdt = new List<int>(19998);
                        List<string> WT = new List<string>(19998);
                        for (int s = 0; s < ToneNum; s += 2)
                        {
                            Values = Values + sr.ReadLine();
                        }
                        if (TempNum < ToneNum)
                        {
                            Console.WriteLine("Clip the tone number to match the saved tone number? Y/N " + ToneNum / 2 + " to " + TempNum / 2);
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
                        WT = Values.Split(delimiterChars).ToList();
                        if (TempLength != BeatLength || TempBPM != BPM)
                        {
                            Console.WriteLine();
                            Console.Write("Match the BPM to the saved BPM? Y/N ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(BPM + " to " + TempBPM);
                            Console.ForegroundColor = ConsoleColor.Black;
                            ConsoleKeyInfo h = Console.ReadKey();
                            Console.ForegroundColor = ConsoleColor.White;
                            if (h.Key == ConsoleKey.Y)
                            {
                                BeatLength = TempLength;
                                BPM = TempBPM;
                                NewDurationList = new List<int>(11) { (int)BeatLength * 4, (int)BeatLength * 3, (int)BeatLength * 2, (int)Convert.ToDouble(BeatLength * 1.5), (int)BeatLength, (int)BeatLength / 2, (int)BeatLength / 4, (int)BeatLength / 8, (int)BeatLength / 16, (int)BeatLength / 32, (int)BeatLength / 64 };
                                DurationList = NewDurationList;
                            }
                            else if (h.Key == ConsoleKey.N)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Adjust the notes to the new BPM? Y/N");
                                Console.ForegroundColor = ConsoleColor.Black;
                                ConsoleKeyInfo i = Console.ReadKey();
                                Console.ForegroundColor = ConsoleColor.White;
                                if (i.Key == ConsoleKey.Y)
                                {
                                    List<string> TEMP4 = WT.ToList();
                                    for (int z = TEMP4.Count - 1; z > 0; z -= 2)
                                    {
                                        TEMP4.RemoveAt(z);
                                    }
                                    foreach (string s in TEMP4)
                                    {
                                        Console.WriteLine(s);
                                    }
                                    //DUpdt = WT.ConvertAll(new Converter<string, int>(StringToInt));
                                }
                            }
                        }
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

        public static double StringToDouble(string input)
        {
            return Convert.ToDouble(input);
        }

        public static void Intro()
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
            if (!Console.KeyAvailable)
            {
                return;
            }
            else
            {
                Console.WriteLine("'Hi!' -A message from the creator");
                Console.WriteLine();
                Console.WriteLine("This is a one man project that started in July 2016 in the hopes of one day being a free, full-featured DAW. That will take some time.");
                Console.ReadLine();
                return;
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
                    Console.Write("1 - 999");
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
                }
                else if (ToneNum / 2 > 999)
                {
                    Console.Clear();
                }
                else if (ToneNum / 2 > 0 && ToneNum / 2 < 999)
                {
                    break;
                }
            }
            T = new List<Double>(ToneNum + 1);
            for (int i = 0; i < ToneNum / 2; i++)
            {
                T.Add(440);
                T.Add(BeatLength);
            }
            MainLoop();
        }
        public static void INIT()
        {
            NoteList = new List<Double>(17) { Convert.ToDouble(65.4064), Convert.ToDouble(69.2957), Convert.ToDouble(69.2957), Convert.ToDouble(73.4162), Convert.ToDouble(77.7817), Convert.ToDouble(77.7817), Convert.ToDouble(82.4069), Convert.ToDouble(87.3071), Convert.ToDouble(92.4986), Convert.ToDouble(92.4986), Convert.ToDouble(97.9989), Convert.ToDouble(103.826), Convert.ToDouble(103.826), Convert.ToDouble(110.000), Convert.ToDouble(116.541), Convert.ToDouble(116.541), Convert.ToDouble(123.471) };
            NoteNameList = new List<string>(17) { "C", "C#", "Db", "D", "D#", "Eb", "E", "F", "F#", "Gb", "G", "G#", "Ab", "A", "A#", "Bb", "B" };
            Octave = new List<string>(8) { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            FMenu = new string[] { "Change Tone", "Save File", "Open File", "Replay Sequence", "Loop Sequence" };
            return;
        }
        public static string Notes(Double Note)
        {
            for (int a = 0; a < 8; a++)
            {
                Double FVC = Convert.ToDouble(Note / (Math.Pow(2, a - 1) / 2));
                if (NoteList.Contains(FVC))
                {
                    return (NoteNameList[NoteList.IndexOf(FVC)] + "-" + Octave[a].ToString());
                }
            }
            return "null";
        }
        public static Double NoteReversed(string NoteName)
        {
            char[] delimiterChars = { '-', '.', ',', '_', '/' };
            Note = NoteName.Split(delimiterChars);
            if (NoteNameList.Contains(Note[0]))
            {
                return Convert.ToDouble(Math.Pow(NoteList[NoteNameList.IndexOf(Note[0])], Convert.ToInt32(Octave[Convert.ToInt32(Note[1])]) / 2));
            }
            else
            {
                return 440;
            }
        }
        public static string Duration(int Duration)
        {
            if (DurationList.Contains(Duration))
            {
                return (DurationNameList[DurationList.IndexOf(Duration)]);
            }
            return "null";
        }
        public static Double DurationReversed(string Duration)
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
            DurationList = new List<int>(11) { (int)BeatLength * 4, (int)BeatLength * 3, (int)BeatLength * 2, (int)Convert.ToDouble(BeatLength * 1.5), (int)BeatLength, (int)BeatLength / 2, (int)BeatLength / 4, (int)BeatLength / 8, (int)BeatLength / 16, (int)BeatLength / 32, (int)BeatLength / 64 };
            DurationNameList = new List<string>(11) { "Whole", "Dotted Half", "Half", "Dotted Quarter", "Quarter", "8th", "16th", "32th", "64th", "128th", "256th" };
            return;
        }
        public static int InteractMenu(int OptionNum, int Select, string[] Options, string Type, string text)
        {
            Console.WriteLine(text);
            Console.WriteLine();
            int StaticOPTNUM = OptionNum;
            bool done = false;
            while (!done)
            {
                for (int i = 0; i < OptionNum; i++)
                {
                    if (Select == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("> ");
                        if (Type == "Oct")
                        {
                            Console.Beep(Convert.ToInt32(Fr * (Math.Pow(2, Select + 1) / 2)), 250);
                        }
                        else if (Type == "Dur")
                        {
                            Console.Beep(500, Convert.ToInt32(DurationList[Select]));
                        }
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    if (Type == "Oct")
                    {
                        Console.WriteLine(Options[i + 2] + "\t" + Fr * (Math.Pow(2, (i + 2) - 1)) / 2);
                        Console.ResetColor();
                    }
                    else if (Type == "Freq")
                    {
                        Console.WriteLine(Options[i] + "\t" + NoteList[i]);
                        Console.ResetColor();
                    }
                    else if (Type == "Sel")
                    {
                        Console.WriteLine(Options[i]);
                        Console.ResetColor();
                    }
                    else if (Type == "Dur")
                    {
                        Console.WriteLine(Options[i] + "\t" + DurationList[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        return -1;
                    }
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
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorTop = Console.CursorTop - StaticOPTNUM - 3;
            Console.ForegroundColor = ConsoleColor.Black;
            for (int z = 0; z < StaticOPTNUM + 2; z++)
            {
                Console.Write("999999999999999999999999999999999999999999999999999999999999999999999999999999999999");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorTop = Console.CursorTop - StaticOPTNUM - 2;
            return Select;
        }
        protected static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
        protected static void DualWriteLine(string LineText)
        {
            /*PRESES.Add(LineText);
            using (StreamWriter psfsw = new StreamWriter("PreviousSession.txt"))
            {
                foreach (string T in PRESES)
                {
                    psfsw.WriteLine(T);
                }
            }
            Console.WriteLine(LineText);*/

        }
        protected static void DualWrite(string LineText)
        {
            PRESES.Add(LineText);
            Console.Write(LineText);
        }
        public static string IntToString(double d)
        {
            return d.ToString();
        }
    }
}