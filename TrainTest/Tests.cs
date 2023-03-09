using System;
using System.Linq;
using TrainProject;
using Xunit;

namespace TrainTest
{
    public class Tests
    {
        [Fact]
        public void Test_ExistTrain()
        {
            Train expected = new Train { NameDestination = "Moscow", NumTrain = "44A", DepartTime = new DateTime(2023, 2, 24) };

            Station st = new Station();
            Train actual = st.GetTrain(0);

            Assert.Equal(expected.NumTrain, actual.NumTrain);
            Assert.Equal(expected.DepartTime, actual.DepartTime);
            Assert.Equal(expected.NameDestination, actual.NameDestination);
        }

        [Fact]
        public void Test_CountToTrainByDestination()
        {
            Station st = new Station();
            Assert.Equal(st.GetTrainByDestination("Moscow").Count, 2);
        }
        
        [Fact]
        public void Test_ExistTrainByTime()
        {
            Station st = new Station();
            DateTime dateTime = new DateTime(2023, 2, 24);
            var station = st.GetTrainByTime(dateTime);
            Assert.Equal(station[0].NameDestination, "Moscow");
            Assert.Equal(station[0].NumTrain, "44A"); 
            Assert.Equal(station[0].DepartTime, new DateTime(2023, 2, 24));
        }
        
        [Fact]
        public void Test_NotFoundTrainByDestination()
        {
            Station st = new Station();
            Assert.Null(st.GetTrainByDestination("Chebocksary"));
        }
        
        [Fact]
        public void Test_NotExistTrainByTime()
        {
            Station st = new Station();
            DateTime dateTime = new DateTime(2099, 6, 12);
            Assert.Null(  st.GetTrainByTime(dateTime));
        }
        
        [Fact]
        public void Test_ListTrainsNotNull()
        {
            Station st = new Station();
            Assert.NotNull(  st.GetTrains());
        }
        
        [Fact]
        public void Test_UniqueTrains()
        {
            Station st = new Station();
            var trains =   st.GetTrains();
            var uniqueTrains = trains.FirstOrDefault().NumTrain;
            Assert.Equal(uniqueTrains.Length, 3);
        }
        
        [Fact]
        public void Test_PropertyNameDestinationGetSet()
        {
            Train train = new Train();
            train.NameDestination = "Ufa";
            String changeName = train.NameDestination;
            
            Assert.Equal(train.NameDestination, "Ufa");
            Assert.Equal(changeName, "Ufa");
        }
        
        [Fact]
        public void Test_PropertyNumTrainGetSet()
        {
            Train train = new Train();
            train.NumTrain = "30A";
            String changeNumTrain = train.NumTrain;
            
            Assert.Equal(train.NumTrain, "30A");
            Assert.Equal(changeNumTrain, "30A");
        }
        
        [Fact]
        public void Test_PropertyDepartTimeGetSet()
        {
            Train train = new Train();
            train.DepartTime =  new DateTime(2023, 2, 3);
            DateTime changeNumTrain = train.DepartTime;
            
            Assert.Equal(train.DepartTime, new DateTime(2023, 2, 3));
            Assert.Equal(changeNumTrain, new DateTime(2023, 2, 3));
        }

        [Fact]
        public void Test_DepartTimeYear()
        {
            Station st = new Station();
            var trains =   st.GetTrains();

            foreach (var train in trains)
            {
                Assert.True(train.DepartTime.Year > 0);
            }
        }
        
        [Fact]
        public void Test_NumTrainEmpty()
        {
            Station st = new Station();
            var trains =   st.GetTrains();

            foreach (var train in trains)
            {
                Assert.False(train.NumTrain == "");
            }
        }
        
        [Fact]
        public void Test_DepartTimeDayBetween()
        {
            Station st = new Station();
            var trains =   st.GetTrains();

            foreach (var train in trains)
            {
                Assert.True(train.DepartTime.Day >= 1);
                Assert.True(train.DepartTime.Day <= 31);
            }
        }
        
        [Fact]
        public void Test_DepartTimeMonthBetween()
        {
            Station st = new Station();
            var trains =   st.GetTrains();

            foreach (var train in trains)
            {
                Assert.True(train.DepartTime.Month >= 1);
                Assert.True(train.DepartTime.Month <= 12);
            }
        }
        
        [Fact]
        public void Test_NameDestinationEmpty()
        {
            Station st = new Station();
            var trains =   st.GetTrains();

            foreach (var train in trains)
            {
                Assert.False(train.NameDestination == "");
            }
        }
        
        [Fact]
        public void Test_NotExistIndex()
        {
            Station st = new Station();
            Train actual = st.GetTrain(-1);
            Assert.Null(actual);
        }
    }
}