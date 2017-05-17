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
            // WHEN Temperature Is Lower

            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(19);
            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(20);

            // AND Heater Is Not Started

            _heater.Stub(x => x.IsStarted).Return(false);

            // Should Start Heater

            _thermostat.Check();

            _heater.AssertWasCalled(x => x.Start());
        }

        [Fact]
        public void Check_WhenTemperatureIsLowerAndHeaterIsStarted_ShouldNotStartHeater()
        {
            // WHEN Temperature Is Lower

            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(19);
            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(20);

            // AND Heater Is Started

            _heater.Stub(x => x.IsStarted).Return(true);

            // Should Not Start Heater

            _thermostat.Check();

            _heater.AssertWasNotCalled(x => x.Start());
        }

        [Fact]
        public void Check_WhenTemperatureIsAsRequestedAndHeaterIsNotStarted_ShouldNotStartHeater()
        {
            // WHEN Temperature Is As Requested

            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(20);
            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(20);

            // AND Heater Is Not Started

            _heater.Stub(x => x.IsStarted).Return(false);

            // Should Not Start Heater

            _thermostat.Check();

            _heater.AssertWasNotCalled(x => x.Start());
        }

        [Fact]
        public void Check_WhenTemperatureIsAsRequestedAndHeaterIsStarted_ShouldStopHeater()
        {
            // WHEN Temperature Is As Requested

            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(20);
            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(20);

            // AND Heater Is Started

            _heater.Stub(x => x.IsStarted).Return(true);

            // Should Stop Heater

            _thermostat.Check();

            _heater.AssertWasCalled(x => x.Stop());
        }

        [Fact]
        public void Check_WhenTemperatureIsHigherAndHeaterIsStarted_ShouldStopHeater()
        {
            // WHEN Temperature Is Higher

            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(21);
            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(20);

            // AND Heater Is Started

            _heater.Stub(x => x.IsStarted).Return(true);

            // Should Stop Heater

            _thermostat.Check();

            _heater.AssertWasCalled(x => x.Stop());
        }

        [Fact]
        public void Check_WhenTemperatureIsHigherAndHeaterIsNotStarted_ShouldNotStopHeater()
        {
            // WHEN Temperature Is Higher

            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(21);
            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(20);

            // AND Heater Is Not Started

            _heater.Stub(x => x.IsStarted).Return(false);

            // Should Stop Heater

            _thermostat.Check();

            _heater.AssertWasNotCalled(x => x.Stop());
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