using FunctionsDemo.Domain.Models;
using FunctionsDemo.Infrastructure;
using MediatR;

namespace FunctionsDemo.Application.Commands
{
    public class SaveSomeDataCommand : IRequest<SomeData>
    {
        public SomeData Data { get; set; }
    }

    public class SaveSomeDataCommandHandler : IRequestHandler<SaveSomeDataCommand, SomeData>
    {
        private readonly IRepository<SomeData> _repository;

        public SaveSomeDataCommandHandler(IRepository<SomeData> repository)
        {
            _repository = repository;
        }

        public async Task<SomeData> Handle(SaveSomeDataCommand request, CancellationToken cancellationToken)
        {
            request.Data.PartitionKey = "Partition-Key";
            request.Data.RowKey = Guid.NewGuid().ToString();

            await _repository.AddAsync(request.Data);

            return request.Data;
        }
    }
}
