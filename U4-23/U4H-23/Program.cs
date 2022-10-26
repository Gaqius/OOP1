using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace U4H_23
{
    class Program
    {
        
        static void Main(string[] args)
        {
            const string CF1 = "Knyga1.txt";
            const string CF2 = "Knyga2.txt";
            const string CF3 = "Rodikliai.txt";
            char[] punctuation = { ',', '.', ',', '!', ' ', '?', ':', ';', '(', ')' };
            char[] sentenceEnd = { '.', '?', '!' };
            List<string> words = TaskUtils.CalculateNotMatchingWords(CF1, CF2, punctuation);
            List<Tuple<string, int>> repetitions = TaskUtils.FindTopRepetitions(words);
            Tuple<string, int> shortest = TaskUtils.FindShortestSentence(CF1, CF2, sentenceEnd, punctuation, CF3);
            InOut.write(repetitions, CF3, shortest.Item1, shortest.Item1.Length, TaskUtils.GetSentenceLenghtWords(shortest.Item1, punctuation), shortest.Item2);
        }
    }
    class InOut
    {
        public static List<string> Read(string f,char[] punctuation)
        {            
            List<string> A = new List<string>();
            using (StreamReader reader = new StreamReader(f))
            {
                string line;                
                while ((line=reader.ReadLine())!= null)
                {
                    string[] Words = line.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
                    A.AddRange(Words);
                }                
            }
            return A;
        }
        public static List<Tuple<string, int>> ReadSentence(string f, char[] sentenceEnd)
        {
            List<Tuple<string, int>> B = new List<Tuple<string, int>>();
            using (StreamReader reader = new StreamReader(f))
            {
                string line;
                string partialSentence = "";
                int lineCounter = 0;
                while ((line=reader.ReadLine())!= null)
                {
                    lineCounter++;
                    string[] Sentences = line.Split(sentenceEnd, StringSplitOptions.RemoveEmptyEntries);
                    Sentences[0] = partialSentence + Sentences[0];
                    partialSentence = "";
                    if (!Regex.IsMatch(line, @"[.!?]+$"))
                    {
                        partialSentence += Sentences[Sentences.Length - 1] + " ";
                        for (int i = 0; i < Sentences.Length - 1; i++)
                        {
                            B.Add(new Tuple<string, int>(Sentences[i], lineCounter));
                        }
                    }
                    else
                    {
                        foreach (var item in Sentences)
                        {
                            B.Add(new Tuple<string, int>(item, lineCounter));
                        }                        
                    }
                }
            }
            return B;
        }
        public static void write (List<Tuple<string, int>> f, string rez, string sentence, int charCount, int wordCount, int lineNumber)
        {
            using (StreamWriter writer = new StreamWriter(rez))
            {
                for (int i = 0; i < Math.Min(10, f.Count); i++)
                {
                    writer.WriteLine("{0, 15} | {1, 0}", f[i].Item1, f[i].Item2);
                }
                writer.WriteLine("{0} {1} {2} {3}", sentence, charCount, wordCount, lineNumber);
            }
        }
    }
    class TaskUtils 
    {
        public static List<string> CalculateNotMatchingWords(string f1, string f2, char[] punctuation)
        {
            List<string> words1 = InOut.Read(f1, punctuation);
            List<string> words2 = InOut.Read(f2, punctuation);
            List<string> result = new List<string>();
            foreach (var word in words1)
            {
                if (!words2.Contains(word))
                {
                    result.Add(word);
                }
            }
            foreach (var word in words2)
            {
                if (!words1.Contains(word))
                {
                    result.Add(word);
                }
            }
            return result;
        }
        public static Tuple<string, int> FindShortestSentence(string f1, string f2, char[] sentenceEnd,char[] punctuation, string rez)
        {
            Tuple<string, int> shortest = null;
            List<Tuple<string, int>> sentences1 = new List<Tuple<string, int>>(InOut.ReadSentence(f1, sentenceEnd));
            List<Tuple<string, int>> sentences2 = new List<Tuple<string, int>>(InOut.ReadSentence(f2, sentenceEnd));
            using (StreamWriter writer = new StreamWriter(rez))
            {
                for (int i = 0;i < sentences1.Count; i++)
                {
                    for (int j = 0; j < sentences2.Count; j++)
                    {
                        if (sentences1[i].Item1 == (sentences2[j].Item1) && GetSentenceLenghtWords(sentences1[i].Item1, punctuation) > 3)
                        {
                            if (shortest == null)
                            {
                                shortest = sentences1[i];
                            }
                            else if (GetSentenceLenghtWords(shortest.Item1, punctuation) > GetSentenceLenghtWords(sentences1[i].Item1, punctuation))
                            {
                                shortest = sentences1[i];
                            }                            
                        }
                    }
                }
            }
            return shortest;
        }
        public static int GetSentenceLenghtWords(string sentence, char[] punctuation)
        {
            return (new List<string>(sentence.Split(punctuation, StringSplitOptions.RemoveEmptyEntries))).Count;
        }
        public static Dictionary<string, int> FindRepetitions(List<string> words)
        {
            Dictionary<string, int> repetitions = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (!repetitions.ContainsKey(word))
                {
                    repetitions.Add(word, 0);
                }
                repetitions[word]++;
            }
            return repetitions;
        }
        public static List<Tuple<string, int>> FindTopRepetitions(List<string> words)
        {
            Dictionary<string, int> repetitions = FindRepetitions(words);
            var repetitionList = repetitions.ToList();
            repetitionList.Sort((pair1, pair2) => -pair1.Key.Length.CompareTo(pair2.Key.Length));
            List<Tuple<string, int>> result = new List<Tuple<string, int>>();
            for (int i = 0; i < Math.Min(10, repetitionList.Count); i++)
            {
                result.Add(new Tuple<string, int>(repetitionList[i].Key, repetitionList[i].Value));
            }
            return result;
        }
    }
}