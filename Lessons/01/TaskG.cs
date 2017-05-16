using System;
using Rhino.Mocks;
using Xunit;

namespace Lessons._01
{
    /// <summary>
    /// Complete the tests without implementation according to their names.
    /// Run the tests and check if the implementation of Thermostat is correct. If not, fix it.
    /// </summary>
    public class TaskG
    {
        private readonly ICurrentTemperatureProvider _currentTemperatureProvider;
        private readonly ITemperatureSettingsProvider _temperatureSettingsProvider;
        private readonly IHeater _heater;
        private readonly Thermostat _thermostat;

        public TaskG()
        {
            _currentTemperatureProvider = MockRepository.GenerateMock<ICurrentTemperatureProvider>();
            _temperatureSettingsProvider = MockRepository.GenerateMock<ITemperatureSettingsProvider>();
            _heater = MockRepository.GenerateMock<IHeater>();

            _thermostat = new Thermostat(_currentTemperatureProvider, _temperatureSettingsProvider, _heater);
        }

        [Fact]
        public void Check_WhenTemperatureIsLowerAndHeaterIsNotStarted_ShouldStartHeater()
        {
            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(19);
            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(20);

            _thermostat.Check();

            _heater.AssertWasCalled(x => x.Start());
        }

        [Fact]
        public void Check_WhenTemperatureIsLowerAndHeaterIsStarted_ShouldNotStartHeater()
        {
            _heater.Stub(x => x.IsStarted).Return(true);

            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(20);
            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(21);

            _thermostat.Check();

            _heater.AssertWasNotCalled(x => x.Start());
        }

        [Fact]
        public void Check_WhenTemperatureIsAsRequestedAndHeaterIsNotStarted_ShouldNotStartHeater()
        {
            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(20);
            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(20);

            _thermostat.Check();

            _heater.AssertWasNotCalled(x => x.Start());
        }

        [Fact]
        public void Check_WhenTemperatureIsAsRequestedAndHeaterIsStarted_ShouldStopHeater()
        {
            _heater.Stub(x => x.IsStarted).Return(true);

            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(20);
            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(20);

            _thermostat.Check();

            _heater.AssertWasCalled(x => x.Stop());
        }

        [Fact]
        public void Check_WhenTemperatureIsHigherAndHeaterIsStarted_ShouldStopHeater()
        {
            _heater.Stub(x => x.IsStarted).Return(true);

            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(20);
            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(22);

            _thermostat.Check();

            _heater.AssertWasCalled(x => x.Stop());
        }

        [Fact]
        public void Check_WhenTemperatureIsHigherAndHeaterIsNotStarted_ShouldNotStopHeater()
        {
            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(24);
            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(20);

            _thermostat.Check();

            _heater.AssertWasNotCalled(x => x.Stop());
        }
    }

    public class Thermostat
    {
        private readonly ICurrentTemperatureProvider _currentTemperatureProvider;
        private readonly ITemperatureSettingsProvider _temperatureSettingsProvider;
        private readonly IHeater _heater;

        private event EventHandler onTemperatureHigher = delegate { };
        public event EventHandler OnTemperatureHigher
        {
            add
            {
                lock (onTemperatureHigher)
                {
                    onTemperatureHigher += value;
                }
            }
            remove
            {
                lock (onTemperatureHigher)
                {
                    onTemperatureHigher -= value;
                }
            }
        }

        private event EventHandler onTemperatureLowerOrEqual = delegate { };
        public event EventHandler OnTemperatureLowerOrEqual
        {
            add
            {
                lock (onTemperatureLowerOrEqual)
                {
                    onTemperatureLowerOrEqual += value;
                }
            }
            remove
            {
                lock (onTemperatureLowerOrEqual)
                {
                    onTemperatureLowerOrEqual -= value;
                }
            }
        }

        public Thermostat(
            ICurrentTemperatureProvider currentTemperatureProvider, 
            ITemperatureSettingsProvider temperatureSettingsProvider, 
            IHeater heater)
        {
            _currentTemperatureProvider = currentTemperatureProvider;
            _temperatureSettingsProvider = temperatureSettingsProvider;
            _heater = heater;

            OnTemperatureHigher += (sender, e) => _heater.Start();
            OnTemperatureLowerOrEqual += (sender, e) => _heater.Stop();
        }

        public void Check()
        {
            var currentTemperature = _currentTemperatureProvider.GetTemperature();
            var requestedTemperature = _temperatureSettingsProvider.GetRequestedTemperature();

            if (currentTemperature >= requestedTemperature && _heater.IsStarted)
            {
                onTemperatureLowerOrEqual(this, new EventArgs());
            }

            if (currentTemperature < requestedTemperature && !_heater.IsStarted)
            {
                onTemperatureHigher(this, new EventArgs());
            }
        }
    }

    public interface IHeater
    {
        bool IsStarted { get; }

        void Start();
        void Stop();
    }

    public interface ITemperatureSettingsProvider
    {
        decimal GetRequestedTemperature();
    }

    public interface ICurrentTemperatureProvider
    {
        decimal GetTemperature();
    }
}