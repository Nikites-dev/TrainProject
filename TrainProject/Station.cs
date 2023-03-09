using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject
{
    public class Station
    {
        private Train[] trains = new[]
        {
            new Train { NameDestination = "Moscow", NumTrain = "44A", DepartTime = new DateTime(2023, 2, 24) },
            new Train { NameDestination = "Volgograd", NumTrain = "43A", DepartTime = new DateTime(2023, 3, 21) },
            new Train { NameDestination = "Kazan", NumTrain = "4B", DepartTime = new DateTime(2023, 2, 3) },
            new Train { NameDestination = "Kaliningrad", NumTrain = "1EB", DepartTime = new DateTime(2023, 5, 10) },
            new Train { NameDestination = "Moscow", NumTrain = "VAB3", DepartTime = new DateTime(2023, 1, 10) },
            new Train { NameDestination = "Kazan", NumTrain = "4B", DepartTime = new DateTime(2023, 12, 10) },
            new Train { NameDestination = "Samara", NumTrain = "44A", DepartTime = new DateTime(2023, 4, 15) },
            new Train { NameDestination = "Sochi", NumTrain = "4B", DepartTime = new DateTime(2023, 11, 8) }
        };


        public Train GetTrain(int index)
        {
            try
            {
                return trains[index];
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Train[] GetTrains()
        {
            return trains;
        }
        
        public List<Train> GetTrainByTime(DateTime time)
        {
            List<Train> selectTrains = new List<Train>();
            bool isAvaliable = false;
            
            foreach (var train in trains)
            {
                if (time == train.DepartTime)
                {
                    isAvaliable = true;
                    selectTrains.Add(train);
                }
            }
            
            if (isAvaliable)
            {
                return selectTrains; 
            }
            
            return null;
        }

        public List<Train> GetTrainByDestination(String nameDest)
        {
            List<Train> selectTrains = new List<Train>();
            bool isAvaliable = false;
            foreach (var train in trains)
            {
                if (nameDest == train.NameDestination)
                {
                    isAvaliable = true;
                    selectTrains.Add(train);
                }
            }

            if (isAvaliable)
            {
                return selectTrains; 
            }
            return null;
        }
    }
}
