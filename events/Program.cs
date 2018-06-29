using System;

namespace Play
{
    class TrainSignal
    {
        public delegate void DelRunThis();
        public event DelRunThis del_run_this;

        public void TrainIsComing()
        {
            // stop the car or whatever object wants to cross
            if (del_run_this != null)
            {
                del_run_this();
            }
        }
    }

    class Car
    {
        public Car(TrainSignal trainSignal)
        {
            trainSignal.del_run_this += StopTheCar;
        }


        void StopTheCar()
        {
            Console.WriteLine("Screeeeeeetch");
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            TrainSignal trainSignal = new TrainSignal();

            new Car(trainSignal);
            new Car(trainSignal);
            new Car(trainSignal);
            new Car(trainSignal);
            new Car(trainSignal);

            trainSignal.del_run_this += null;

            trainSignal.TrainIsComing();
            Console.Read();
        }
    }


}
