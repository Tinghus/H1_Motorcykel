using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Motorcykel
{
    internal class MotorcycleClass
    {
        public string Name { get; set; }

        private bool _engineIsStarted;
        private int _currentRpm;
        private int _currentGear;

        public MotorcycleClass()
        {
            Name = string.Empty;
            _engineIsStarted = false;
            _currentGear = 0;
            _currentRpm = 0;
        }

        public MotorcycleClass(string name, bool engineIsStarted)
        {
            Name = name;
            _engineIsStarted = engineIsStarted;

            _currentRpm = _engineIsStarted ? 1000 : 0;
        }

        public bool SetRpm(int rpm)
        {
            if (!_engineIsStarted)
            {
                return false;
            }

            if (rpm > 8000)
            {
                _currentRpm = 8000;
            }

            if (rpm < 1000)
            {
                StopEngine();
                return false;
            }

            _currentRpm = rpm;
            return true;
        }

        public int GetRpm()
        {
            return _currentRpm;
        }

        public void StartEngine()
        {
            if (_engineIsStarted)
            {
                return;
            }

            _engineIsStarted = true;
            _currentRpm = 1000;
            _currentGear = 0;
        }

        public bool IsStarted()
        {
            return _engineIsStarted;
        }

        public void StopEngine()
        {
            _engineIsStarted = false;
            _currentRpm = 0;
            _currentGear = 0;
        }

        public string GetSpeed()
        {
            return (_currentGear * _currentRpm / 200).ToString("0.00");
        }

        public bool ShiftGearUp()
        {
            if (_engineIsStarted && _currentGear < 5)
            {
                _currentGear++;
                return true;
            }

            return false;
        }

        public bool ShiftGearDown(int newGear)
        {
            if (newGear < _currentGear && newGear > 0) // We should also allow them to place the motor in idle
            {
                _currentGear = newGear;
                return true;
            }

            return false;
        }

        public string toString(int padding = 16)
        {
            string output =
                "Name:".PadRight(padding) + Name + Environment.NewLine +
                "Is running:".PadRight(padding) + _engineIsStarted.ToString() + Environment.NewLine +
                "Current Speed:".PadRight(padding) + GetSpeed() + Environment.NewLine +
                "Current Gear:".PadRight(padding) + _currentGear + Environment.NewLine +
                "Current RPM:".PadRight(padding) + _currentRpm;

            return output;
        }


    }
}
