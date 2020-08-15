namespace Ax3.IMS.Domain.Messages
{
    public interface ICommand<out TResponse> : IMessage
    {
    }
}