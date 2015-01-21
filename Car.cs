using System;

namespace CarLibrary
{
    public class Car
    {
        public string CarName { private set; get; }
        public short MaxSpeed { private set; get; }
        public byte Acceleration { private set; get; }
        public short CurrSpeed { private set; get; }
        bool isEngineOn;
        public bool IsEngineOn
        {
            set
            {
                if (!value)
                    CurrSpeed = 0;
                isEngineOn = value;
            }

            get
            {
                return isEngineOn;
            }

        }

        /// <summary>
        /// Condtructor
        /// </summary>
        public Car()
            : this("Bugatti")
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="carName"></param>
        /// <param name="maxSpeed"></param>
        /// <param name="acceleration"></param>
        public Car(string carName, short maxSpeed = 180, byte acceleration = 10)
        {
            this.CarName = carName;
            this.MaxSpeed = maxSpeed;
            this.Acceleration = acceleration;
            IsEngineOn = false;
            CurrSpeed = 0;
        }

        public bool SpeedUp()
        {
            // Если двигатель включен и текущая скорость не превышает максимальную скорость, то увеличиваем текущую скорость.
            if (IsEngineOn && CurrSpeed < MaxSpeed)
            {
                CurrSpeed += Acceleration;
                // Если текущая скорость превышает максимальную, устанавливаем текущую скорость равную максимальной.
                CurrSpeed = CurrSpeed > MaxSpeed ? MaxSpeed : CurrSpeed;
                return true;
            }
            else
                // если двигатель не заведен, или текущая скорость равна максимальной, увеличение скорости не возможно, возвращаю false.
                return false;
        }

        /// <summary>
        /// Method counts down car's speed
        /// </summary>
        /// <param name="stepDown"></param>
        /// <returns></returns>
        public bool SpeedDown(byte stepDown = 10)
        {
            CurrSpeed -= Acceleration;
            if (CurrSpeed < 0) CurrSpeed = 0;
            return true;
        }
    }
}