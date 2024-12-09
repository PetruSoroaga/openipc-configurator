using Moq;
using OpenIPC_Config.Events;
using OpenIPC_Config.Services;
using Serilog;

namespace OpenIPC_Config.Tests.ViewModels;

public abstract class ViewModelTestBase
{
    protected Mock<ILogger> LoggerMock { get; private set; }
    protected Mock<IEventAggregator> EventAggregatorMock { get; private set; }
    protected Mock<ISshClientService> SshClientServiceMock { get; private set; }
    protected Mock<WfbConfContentUpdatedEvent> WfbConfContentUpdatedEventMock { get; private set; }
    protected Mock<AppMessageEvent> AppMessageEventMock { get; private set; }

    // xUnit does not have [SetUp], so use a constructor for initialization.
    protected ViewModelTestBase()
    {
        SetUpMocks();
    }

    private void SetUpMocks()
    {
        LoggerMock = new Mock<ILogger>();
        EventAggregatorMock = new Mock<IEventAggregator>();
        SshClientServiceMock = new Mock<ISshClientService>();
        WfbConfContentUpdatedEventMock = new Mock<WfbConfContentUpdatedEvent>();
        AppMessageEventMock = new Mock<AppMessageEvent>();

        EventAggregatorMock
            .Setup(x => x.GetEvent<WfbConfContentUpdatedEvent>())
            .Returns(WfbConfContentUpdatedEventMock.Object);

        EventAggregatorMock
            .Setup(x => x.GetEvent<AppMessageEvent>())
            .Returns(AppMessageEventMock.Object);
    }
}


