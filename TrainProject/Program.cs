using System;
using System.Collections.Generic;

namespace TrainProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Station st = new Station();
            DateTime dateTime = new DateTime(2023, 2, 24);
            ShowList(st.GetTrainByTime(dateTime));
        
            ShowList(st.GetTrainByDestination("Moscow"));
            var dsf = st.GetTrainByDestination("Moscow2");
        
            Console.Write("true");
        }


        private static void Show(Train train)
        {
            Console.WriteLine($"[ {train.NameDestination} | {train.NumTrain} | {train.DepartTime} ]");
        }

        private static void ShowList(List<Train> trains)
        {
            trains.Sort((x, y) => DateTime.Compare(x.DepartTime, y.DepartTime));
            foreach (var train in trains)
            {
                Console.WriteLine($"[ {train.NameDestination} | {train.NumTrain} | {train.DepartTime} ]");
            }
        }
    }
}