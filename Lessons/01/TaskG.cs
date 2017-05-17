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
            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(19);
            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(20);
            
            //unsure how to make sure heater was already running. Can't figure this out!
            _thermostat.Check();
            _heater.AssertWasNotCalled(x => x.Start());
        }

        [Fact]
        public void Check_WhenTemperatureIsAsRequestedAndHeaterIsNotStarted_ShouldNotStartHeater()
        {
            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(20);
            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(20);

            _thermostat.Check();
            _heater.AssertWasNotCalled(x => x.Start());
        }

        [Fact]
        public void Check_WhenTemperatureIsAsRequestedAndHeaterIsStarted_ShouldStopHeater()
        {
            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(20);
            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(20);

            _thermostat.Check();
            _heater.AssertWasCalled(x => x.Stop());
        }

        [Fact]
        public void Check_WhenTemperatureIsHigherAndHeaterIsStarted_ShouldStopHeater()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Check_WhenTemperatureIsHigherAndHeaterIsNotStarted_ShouldNotStopHeater()
        {
            throw new NotImplementedException();
        }
    }

    public class Thermostat
    {
        private readonly ICurrentTemperatureProvider _currentTemperatureProvider;
        private readonly ITemperatureSettingsProvider _temperatureSettingsProvider;
        private readonly IHeater _heater;

        public Thermostat(
            ICurrentTemperatureProvider currentTemperatureProvider, 
            ITemperatureSettingsProvider temperatureSettingsProvider, 
            IHeater heater)
        {
            _currentTemperatureProvider = currentTemperatureProvider;
            _temperatureSettingsProvider = temperatureSettingsProvider;
            _heater = heater;
        }

        public void Check()
        {
            var currentTemperature = _currentTemperatureProvider.GetTemperature();
            var requestedTemperature = _temperatureSettingsProvider.GetRequestedTemperature();

            if (currentTemperature >= requestedTemperature && _heater.IsStarted)
            {
                _heater.Stop();
            }

            if (currentTemperature < requestedTemperature && !_heater.IsStarted)
            {
                _heater.Start();
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