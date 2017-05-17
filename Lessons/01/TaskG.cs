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

        //to remove some seem like theory may be better here
        public void PrepareStubs(int currentTemperature, int requestedTemperature, bool heaterIsRunning)
        {
            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(currentTemperature);
            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(requestedTemperature);
            _heater.Stub(x => x.IsStarted).Return(heaterIsRunning);
        }

        [Fact]
        public void Check_WhenTemperatureIsLowerAndHeaterIsNotStarted_ShouldStartHeater()
        {
            PrepareStubs(19, 20, false);

            _thermostat.Check();

            _heater.AssertWasCalled(x => x.Start());
        }

        [Fact]
        public void Check_WhenTemperatureIsLowerAndHeaterIsStarted_ShouldNotStartHeater()
        {
            PrepareStubs(19, 20, true);

            _thermostat.Check();

            _heater.AssertWasNotCalled(x => x.Start());
        }

        [Fact]
        public void Check_WhenTemperatureIsAsRequestedAndHeaterIsNotStarted_ShouldNotStartHeater()
        {
            PrepareStubs(20, 20, false);

            _thermostat.Check();

            _heater.AssertWasNotCalled(x => x.Start());
        }

        [Fact]
        public void Check_WhenTemperatureIsAsRequestedAndHeaterIsStarted_ShouldStopHeater()
        {
            PrepareStubs(20, 20, true);

            _thermostat.Check();

            _heater.AssertWasCalled(x => x.Stop());
        }

        [Fact]
        public void Check_WhenTemperatureIsHigherAndHeaterIsStarted_ShouldStopHeater()
        {
            PrepareStubs(21, 20, true);

            _thermostat.Check();

            _heater.AssertWasCalled(x => x.Stop());
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

            if (currentTemperature > requestedTemperature && _heater.IsStarted)
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