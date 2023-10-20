
namespace WorkOrderManager.Infrastructure.TimeProvider;

using System;

using WorkOrderManager.Application.Services.TimeProvider;
public class TimeProvider : IDateTimeService
{
    public DateTime DateTime => DateTime.UtcNow;
}