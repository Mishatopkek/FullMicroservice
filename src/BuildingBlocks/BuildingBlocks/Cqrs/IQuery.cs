using MediatR;

namespace BuildingBlocks.Cqrs;

public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
{
    
}